using AutoMapper;
using BLL.InnovTouch.Contrat.Produits;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.Models.Entite;
using DAL.InnovTouch.DOMAIN.Models.Produits;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.DTO;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Produit;
using Shared.DTO.InnovTouch.DTO.Role;
using Shared.Models.OUT.GenererNumeroArrivageResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.Implementation.Produits
{
    public class AlerteProduitService : IAlerteProduitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AlerteProduitService> _logger;
        private readonly IMapper _mapper;

        public AlerteProduitService(IUnitOfWork unitOfWork, ILogger<AlerteProduitService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _logger.LogInformation("AlerteProduitService(...)");
        }

        public async Task<Response<List<AlerteProduitDto>>> AllAsync()
        {
            _logger.LogInformation($"AllAsync()");
            var resultat = new Response<List<AlerteProduitDto>>();
            try
            {
                var alerteProduits = await _unitOfWork.AlerteProduits.AllAsync();
                resultat.Succeeded = true;
                resultat.Data = _mapper.Map<List<AlerteProduitDto>>(alerteProduits);
                resultat.Message = $"AlerteProduits :{alerteProduits.Count}";
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc AllAsync");
            }
            return resultat;
        }
        public async Task<Response<List<AlerteProduitDto>>> AllByFiltreAsync(int? enseigneId, int? familleProduitId)
        {
            _logger.LogInformation($"AllByFiltreAsync()");
            var resultat = new Response<List<AlerteProduitDto>>();
            try
            {
                var alerteProduits = _unitOfWork.AlerteProduits
                    .All()
                    .Include(a => a.Enseigne)
                    .Include(a => a.FamilleProduit)
                    .OrderByDescending(a => a.Id)
                    .Select(a => a);
                if (enseigneId.HasValue)
                {
                    alerteProduits = alerteProduits
                        .Where(a => a.EnseigneId == enseigneId.Value);

                }
                if (familleProduitId.HasValue)
                {
                    alerteProduits = alerteProduits
                        .Where(a => a.FamilleProduitId == familleProduitId.Value);
                }
                resultat.Succeeded = true;
                resultat.Data = _mapper.Map<List<AlerteProduitDto>>(await alerteProduits.ToListAsync());
                resultat.Message = $"AlerteProduits :{resultat.Data.Count}";
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc AllFiltreAsync");
            }
            return resultat;
        }
        public async Task<Response<int>> CreateAsync(AlerteProduitDto alerteDto)
        {
            _logger.LogInformation($"CreateAsync({alerteDto})");
            var resultat = new Response<int>();
            try
            {
                var alerte = GererPropNavigation(_mapper.Map<AlerteProduit>(alerteDto));
                var alerteExist = await _unitOfWork.AlerteProduits
                    .AnyAsync(a => a.EnseigneId == alerte.EnseigneId
                            && a.FamilleProduitId == alerte.FamilleProduitId);
                if (alerteExist)
                {
                    resultat.Succeeded = true;
                    resultat.Message = "Alerte existe déjà";
                    return resultat;
                }
                
                await _unitOfWork.AlerteProduits.CreateAsync(alerte);
                resultat.Succeeded = true;
                if (await _unitOfWork.SaveAsync() > 0)
                {
                    resultat.Message = "Alerte bien crée";
                    resultat.Data = alerte.Id;
                }
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc CreateAsync");
            }
            return resultat;
        }
        public async Task<Response<bool>> UpdateAsync(AlerteProduitDto alerte)
        {
            _logger.LogInformation($"UpdateAsync({alerte})");
            var resultat = new Response<bool>();
            try
            {
                var alerteExist = await _unitOfWork.AlerteProduits
                    .AnyAsync(a => a.EnseigneId == alerte.EnseigneId
                            && a.FamilleProduitId == alerte.FamilleProduitId);
                if (!alerteExist)
                {
                    resultat.Succeeded = true;
                    resultat.Message = "Alerte n'existe pas";
                    return resultat;
                }
                _unitOfWork.AlerteProduits.Update(GererPropNavigation(_mapper.Map<AlerteProduit>(alerte)));

                resultat.Succeeded = true;
                if (await _unitOfWork.SaveAsync() > 0)
                {
                    resultat.Message = "Alerte bien modifié";
                    resultat.Data = true;
                }
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc UpdateAsync");
            }
            return resultat;
        }
        public async Task<Response<bool>> DeleteByIdAsync(int id)
        {
            _logger.LogInformation($"DeleteAsync(id:{id})");
            var resultat = new Response<bool>();
            try
            {
                var alerte = await _unitOfWork.AlerteProduits
                    .Where(a => a.Id == id).FirstOrDefaultAsync();
                if (alerte == null)
                {
                    resultat.Succeeded = true;
                    resultat.Message = "Alerte n'existe pas";
                    return resultat;
                }

                _unitOfWork.AlerteProduits.Delete(alerte);
                resultat.Succeeded = true;
                if (await _unitOfWork.SaveAsync() > 0)
                {
                    _logger.LogInformation($"Alerte bien supprimé enseigneId:{alerte.EnseigneId}, FamilleProduitId:{alerte.FamilleProduitId}");
                    resultat.Message = "Alerte bien supprimé";
                    resultat.Data = true;
                }
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc DeleteAsync");
            }
            return resultat;
        }
        private AlerteProduit GererPropNavigation(AlerteProduit alerteProduit)
        {
            if (alerteProduit.Enseigne != null)
            {
                alerteProduit.EnseigneId = alerteProduit.Enseigne.Id;
                alerteProduit.Enseigne = null;
            }
            if (alerteProduit.FamilleProduit != null)
            {
                alerteProduit.FamilleProduitId = alerteProduit.FamilleProduit.Id;
                alerteProduit.FamilleProduit = null;
            }
            return alerteProduit;
        }

        public async Task<Response<AlerteProduitDto>> GetByIdAsync(int id)
        {
            _logger.LogInformation($"GetByIdAsync(id:{id})");
            var resultat = new Response<AlerteProduitDto>();
            try
            {
                var alerte = await _unitOfWork.AlerteProduits
                    .Where( a => a.Id == id)
                    .Include(a => a.Enseigne)
                    .Include(a => a.FamilleProduit)
                    .FirstOrDefaultAsync();
                if (alerte == null)
                {
                    resultat.Succeeded = true;
                    resultat.Message = "Alerte n'existe pas";

                    return resultat;
                }
                resultat.Succeeded = true;
                resultat.Data = _mapper.Map<AlerteProduitDto>(alerte);
                resultat.Message = $"AlerteProduits :{resultat.Data}";
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc AllFiltreAsync");
            }
            return resultat;
        }
    }
}
