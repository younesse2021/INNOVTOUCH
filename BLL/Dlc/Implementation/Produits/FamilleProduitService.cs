using AutoMapper;
using BLL.InnovTouch.Contrat.Produits;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.Models.Produits;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.DTO;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Produit;
using Shared.Models.OUT.GenererNumeroArrivageResponse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.Implementation.Produits
{
    public class FamilleProduitService : IFamilleProduitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FamilleProduitService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkOracle _unitOfWorkOracle;

        public FamilleProduitService(IUnitOfWork unitOfWork, ILogger<FamilleProduitService> logger, IMapper mapper, IUnitOfWorkOracle unitOfWorkOracle = null)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _unitOfWorkOracle = unitOfWorkOracle;
            _logger.LogInformation("FamilleProduitService(...)");
        }

        public async Task<Response<FamilleProduitDto>> GetOrCreateByCodeAsync(string code)
        {
            _logger.LogInformation($"GetOrCreateByCodeAsync(code:{code})");
            Response<FamilleProduitDto> resultat = new Response<FamilleProduitDto>();
            try
            {
                // Vérifié famille produit si existe sur bdd InnovTouch
                var result = await GetByCodeAsync(code);
                var familleProduit = result.Data;
                if (familleProduit == null || familleProduit.Id == 0)
                {
                    //Vérifié sur oracle  si existe 
                    var resOracle = await GetByCodeFromOracleAsync(code);
                    if (!resOracle.Succeeded)
                    {
                        resultat.Succeeded = resOracle.Succeeded;
                        resultat.Message = resOracle.Message;
                        resultat.Data = resOracle.Data;
                        _logger.LogInformation(resOracle.Message);
                        return resultat;
                    }
                    if (resOracle.Data == null)
                    {
                        resultat.Succeeded = true;
                        resultat.Message = $"FamilleProduit:{code} non trouvé";
                        _logger.LogInformation($"FamilleProduit:{code} non trouvé sur base de donnée oracle  et sql server");
                        return resultat;
                    }
                    // sinon le créer s'il existe
                    familleProduit = resOracle.Data;
                    var resultatCreation = await CreateAsync( familleProduit );
                    if (!resultatCreation.Succeeded)
                    {
                        resultat.Succeeded = resOracle.Succeeded;
                        resultat.Message = resOracle.Message;
                        resultat.Data = resOracle.Data;
                        _logger.LogInformation(resOracle.Message);
                        return resultat;
                    }
                    familleProduit.Id = resultatCreation.Data;
                    resultat.Succeeded = true;
                    resultat.Message = $"FamilleProduit:{code} trouvé et crée ";
                    resultat.Data = familleProduit;
                    return resultat;
                }
                resultat.Succeeded = true;
                resultat.Message = $"FamilleProduit:{code} trouvé";
                resultat.Data = _mapper.Map<FamilleProduitDto>(familleProduit);
                _logger.LogInformation($"FamilleProduit:{code} trouvé sur base de donnée sql server");
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetByCode");
            }
            return resultat;
        }
        public async Task<Response<FamilleProduitDto>> GetByCodeFromOracleAsync(string code)
        {
            _logger.LogInformation($"GetByCodeFromOracle(codeBarre:{code})");
            Response<FamilleProduitDto> resultat = new Response<FamilleProduitDto>();
            try
            {
                string req = @"select distinct cext_fam from mj_art_struct WHERE cext_fam = :code ";

                var dt = await _unitOfWorkOracle.GetDataAsync(req,
                    new Dictionary<string, object>() {
                    { "codeBarre", code }
                });
                if (dt == null)
                {
                    resultat.Succeeded = true;
                    resultat.Message = $"Famille produit codebarre:{code} non trouvé sur Oracle  ";
                    _logger.LogInformation(resultat.Message);
                    return resultat;
                }
                DataRow dr = dt.Rows[0];
                FamilleProduitDto produit = new FamilleProduitDto()
                {
                    Id = 0,
                    Code = code,
                    Libelle = Convert.ToString(dr["cext_fam"]) ?? ""
                };
                resultat.Succeeded = true;
                resultat.Message = $"Famille produit codebarre:{code} trouvé sur Oracle  ";
                _logger.LogInformation(resultat.Message);
                resultat.Data = produit;
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetByCodeFromOracle");
            }
            return resultat;
        }   
        public async Task<Response<FamilleProduitDto>> GetByCodeAsync(string code)
        {
            _logger.LogInformation($"GetByCodeAsync(code:{code})");
            Response<FamilleProduitDto> resultat = new Response<FamilleProduitDto>();
            try
            {
                var familleProduit = await _unitOfWork.FamilleProduits
                    .Where(p => code.Trim().Equals(p.Code))
                    .FirstOrDefaultAsync();
                if (familleProduit == null || familleProduit.Id == 0)
                {
                    resultat.Succeeded = true;
                    resultat.Message = $"FamilleProduit:{code} non trouvé";
                    _logger.LogInformation($"FamilleProduit:{code} non trouvé sur base de donnée InnovTouch");
                    return resultat;
                }
                resultat.Succeeded = true;
                resultat.Message = $"FamilleProduit:{code} trouvé";
                resultat.Data = _mapper.Map<FamilleProduitDto>(familleProduit);
                _logger.LogInformation($"FamilleProduit:{code} trouvé sur base de donnée InnovTouch");
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetByCodeAsync");
            }
            return resultat;
        }
        public async Task<Response<int>> CreateAsync(FamilleProduitDto familleProduit)
        {
            _logger.LogInformation($"CreateAsync(Id:{familleProduit.Id},code:{familleProduit.Code})");
            Response<int> resultat = new Response<int>();
            try
            {
                var familleProduitExist = await _unitOfWork.FamilleProduits.AnyAsync(p => p.Code == familleProduit.Code);
                if (familleProduitExist)
                {
                    resultat.Succeeded = true;
                    resultat.Message = "Famille produit existe déjà";
                    return resultat;
                }
                var prd = (_mapper.Map<FamilleProduit>(familleProduit));
                await _unitOfWork.FamilleProduits.CreateAsync(prd);
                await _unitOfWork.SaveAsync();

                resultat.Succeeded = true;
                resultat.Message = "Famille Produit bien crée";
                resultat.Data = prd.Id;
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc CreateAsync");
            }
            return resultat;
        }
        public async Task<Response<List<FamilleProduitDto>>> GetAllAsync()
        {
            _logger.LogInformation($"GetAll()");
            Response<List<FamilleProduitDto>> resultat = new Response<List<FamilleProduitDto>>();
            try
            {
                var familleProduits = await _unitOfWork.FamilleProduits.AllAsync();
                resultat.Succeeded = true;
                resultat.Message = $"FamilleProduits count:{familleProduits.Count}";
                resultat.Data = _mapper.Map<List<FamilleProduitDto>>(familleProduits);
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetAll");
            }
            return resultat;
        }
        public async Task<Response<FamilleProduitDto>> GetByIdAsync(int id)
        {
            _logger.LogInformation($"GetByIdAsync(id:{id})");
            Response<FamilleProduitDto> resultat = new Response<FamilleProduitDto>();
            try
            {
                var familleProduit = await _unitOfWork.FamilleProduits
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
                if (familleProduit == null || familleProduit.Id == 0)
                {
                    resultat.Succeeded = true;
                    resultat.Message = $"FamilleProduit:{id} non trouvé";
                    _logger.LogInformation($"FamilleProduit:{id} non trouvé sur base de donnée InnovTouch");
                    return resultat;
                }
                resultat.Succeeded = true;
                resultat.Message = $"FamilleProduit:{id} trouvé";
                resultat.Data = _mapper.Map<FamilleProduitDto>(familleProduit);
                _logger.LogInformation($"FamilleProduit:{id} trouvé sur base de donnée InnovTouch");
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetByIdAsync");
            }
            return resultat;
        }
        public async Task<Response<bool>> UpdateAsync(FamilleProduitDto familleProduit)
        {
            _logger.LogInformation($"UpdateAsync(id:{familleProduit.Id},Code:{familleProduit.Code})");
            Response<bool> resultat = new Response<bool>();
            try
            {
                var familleProduitExist = await _unitOfWork.FamilleProduits
                    .AnyAsync(f => f.Id == familleProduit.Id);
                if (!familleProduitExist)
                {
                    resultat.Succeeded = true;
                    resultat.Message = $"Famille produit n'existe pas, Id:{familleProduit.Id}";
                    resultat.Data = false;
                    return resultat;
                }
                var familleProd = _mapper.Map<FamilleProduit>(familleProduit);
                var res = _unitOfWork.FamilleProduits.Update(familleProd);
                await _unitOfWork.SaveAsync();

                resultat.Succeeded = true;
                resultat.Message = $"Famille produit modifié {res} ";
                resultat.Data = res;
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc UpdateAsync");
            }
            return resultat;
        }
    }
}
