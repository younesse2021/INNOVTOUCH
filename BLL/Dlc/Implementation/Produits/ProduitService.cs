using AutoMapper;
using BLL.InnovTouch.Contrat.Produits;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.Models.Produits;
using Microsoft.AspNetCore.Mvc;
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.Implementation.Produits
{
    public class ProduitService : IProduitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProduitService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkOracle _unitOfWorkOracle;
        private readonly IFamilleProduitService _familleProduitService;


        public ProduitService(IUnitOfWork unitOfWork, ILogger<ProduitService> logger, IMapper mapper, IFamilleProduitService familleProduitService = null, IUnitOfWorkOracle unitOfWorkOracle = null)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _unitOfWorkOracle = unitOfWorkOracle;
            _familleProduitService = familleProduitService;
            _logger.LogInformation("ProduitService(...)");

        }
        public async Task<Response<ProduitDto>> GetOrCreateByCodeAsync(string code)
        {
            _logger.LogInformation($"GetOrCreateAsync(codebarre:{code})");
            Response<ProduitDto> resultat = new Response<ProduitDto>();
            try
            {
                var result = await GetByCodeAsync(code);
                if (!result.Succeeded)
                {
                    resultat.Succeeded = result.Succeeded;
                    resultat.Message = result.Message;
                    return resultat;
                }
                var produit = result.Data;
                if (produit != null && produit.Id > 0)
                {
                    resultat.Succeeded = true;
                    resultat.Message = $"Produit:{code} trouvé";
                    resultat.Data = produit;
                    return resultat;
                }

                result = await GetByCodeFromOracleAsync(code);
                if (!result.Succeeded)
                {
                    resultat.Succeeded = result.Succeeded;
                    resultat.Message = result.Message;
                    return resultat;
                }
                produit = result.Data;
                if (produit == null)
                {
                    resultat.Succeeded = true;
                    resultat.Message = $"Produit:{code} non trouvé";
                    resultat.Data = produit;
                    return resultat;
                }

                var resultCreation = await CreateAsync(produit);
                if (!resultCreation.Succeeded)
                {
                    resultat.Succeeded = resultCreation.Succeeded;
                    resultat.Message = resultCreation.Message;
                    return resultat;
                }
                produit.Id = resultCreation.Data;

                var resultatGet = await GetByCodeAsync(produit.Code);
                if (!resultatGet.Succeeded)
                {
                    resultat.Succeeded = resultCreation.Succeeded;
                    resultat.Message = resultCreation.Message;
                    return resultat;
                }
                resultat.Succeeded = true;
                resultat.Message = "Produit trouvé et crée";
                resultat.Data = resultatGet.Data;
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetByCode");
            }
            return resultat;
        }

        public async Task<Response<ProduitDto>> GetByCodeAsync(string code)
        {
            _logger.LogInformation($"GetByCodeAsync(codebarre:{code})");
            Response<ProduitDto> resultat = new Response<ProduitDto>();
            
            return resultat;
        }
        public async Task<Response<ProduitDto>> GetByCodeFromOracleAsync(string code)
        {
            _logger.LogInformation($"GetByCodeFromOracle(codeBarre:{code})");
            Response<ProduitDto> resultat = new Response<ProduitDto>();
            try
            {
                string req = @"
                select 
                distinct
                       pkartrac.Get_Artcexr(cc.arccinr) article,
                       pkstrucobj.get_desc(cc.arccinr,'FR') lib_article,
                       aviprix PV,
                       cext_dept,
                       cext_ray,
                       cext_fam,
                       cext_sfam,
                       cext_ssfam
                  from aveprix x,avescope av,artcoca cc,mj_art_struct 
                 where av.avontar = x.avintar
                   and x.avicinv = cc.arccinv
                   and mj_art_struct.mascinr = cc.arccinr
                   and cc.arccode = :codeBarre
                   and trunc(sysdate) between trunc(x.aviddeb) and trunc(x.avidfin)
                   and trunc(sysdate) between trunc(av.avoddeb) and trunc(av.avodfin)
                   ORDER BY pkartrac.Get_Artcexr(cc.arccinr)";

                var dt = await _unitOfWorkOracle.GetDataAsync(req,
                    new Dictionary<string, object>() {
                    { "codeBarre", code }
                });
                if (dt == null)
                {
                    resultat.Succeeded = true;
                    resultat.Message = $"Produit codebarre:{code} non trouvé sur Oracle ";
                    _logger.LogInformation(resultat.Message);
                    return resultat;
                }
                DataRow dr = dt.Rows[0];
                ProduitDto produit = new ProduitDto()
                {
                    Id = 0,
                    Code = code,
                    Libelle = Convert.ToString(dr["lib_article"]) ?? "",
                    CodeDepartement = Convert.ToString(dr["cext_dept"]) ?? "",
                    CodeRayon = Convert.ToString(dr["cext_ray"]) ?? "",
                    CodeFamille = Convert.ToString(dr["cext_fam"]) ?? "",
                    CodeSousFamille = Convert.ToString(dr["cext_sfam"]) ?? "",
                    CodeSousSousFamille = Convert.ToString(dr["cext_ssfam"]) ?? "",
                    DateMaj = DateTime.Now
                };
                if (dr["PV"] != null)
                {
                    produit.Prix = Convert.ToDouble(dr["PV"]);
                }
                resultat.Succeeded = true;
                resultat.Message = "Produit codebarre:{code} trouvé sur Oracle ";
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

        public async Task<Response<int>> CreateAsync(ProduitDto produit)
        {
            _logger.LogInformation($"CreateAsync(Id:{produit.Id},codeBarre:{produit.Code})");
            Response<int> resultat = new Response<int>();
            return resultat;
        }

        private async Task<Produit> SetFamilleProduit(Produit produit)
        {
            if (!string.IsNullOrEmpty(produit.CodeFamille) && produit.FamilleProduitId == null)
            {
                var result = await _familleProduitService.GetOrCreateByCodeAsync(produit.CodeFamille);
                if (!(result.Succeeded && result.Data != null))
                {
                    return produit;
                }
                produit.FamilleProduit = _mapper.Map<FamilleProduit>(result.Data);
                produit.FamilleProduitId = produit.FamilleProduit.Id;
            }
            return produit;
        }

        private Produit GererPropNavigation(Produit produit)
        {
            if (produit.FamilleProduit != null)
            {
                produit.FamilleProduitId = produit.FamilleProduit.Id;
                produit.CodeFamille = produit.FamilleProduit.Code;
                produit.FamilleProduit = null;
            }
            return produit;
        }
    }
}
