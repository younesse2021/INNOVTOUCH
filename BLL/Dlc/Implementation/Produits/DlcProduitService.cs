using AutoMapper;
using BLL.InnovTouch.Contrat.Produits;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DAL.DOMAIN.Repositories;
using DAL.InnovTouch.DOMAIN.Models.Produits;
using Shared.DTO.InnovTouch.DTO.Models.Helper;
using Shared.DTO.InnovTouch.DTO.Produit;
using Microsoft.Extensions.Logging;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Shared.DTO.InnovTouch.DTO.Helper;
using BLL.InnovTouch.Contrat.Oracle;
using Shared.Models.OUT.GenererNumeroArrivageResponse;
using BLL.InnovTouch.Contrat.Entite;

namespace BLL.InnovTouch.Implementation.Produits
{
    public class InnovTouchProduitService : IInnovTouchProduitService
    {

        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;
        public readonly ILogger<InnovTouchProduitService> _logger;
        public readonly IService _Service;
        public readonly IMagasinService _magasinService;


        public InnovTouchProduitService(IMapper mapper, ILogger<InnovTouchProduitService> logger, IUnitOfWork unitOfWork, IMagasinService magasinService, IService Service)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _magasinService = magasinService;
            _Service = Service;
            _logger.LogInformation("InnovTouchProduitService(...)");
        }

        public async Task<Response<int>> CreateAsync(InnovTouchProduitDto InnovTouchProduit)
        {
            _logger.LogInformation($"CreateAsync(id:{InnovTouchProduit.Id},CodeProduit:{InnovTouchProduit.Produit.Code},InnovTouch:{InnovTouchProduit.InnovTouch.ToShortDateString()},CodeMagasin:{InnovTouchProduit.Magasin?.Code})");
            Response<int> resultat = new Response<int>();
            try
            {
                //Check if existe InnovTouch pour meme produit,date et magasin 
                var IsInnovTouchExiste = await _unitOfWork.InnovTouchProduits.AnyAsync(InnovTouch => InnovTouch.ProduitId == InnovTouchProduit.ProduitId
                                                                            && InnovTouch.InnovTouch.Date == InnovTouchProduit.InnovTouch.Date
                                                                            && InnovTouch.MagasinId == InnovTouchProduit.MagasinId);
                if (IsInnovTouchExiste)
                {
                    resultat.Succeeded = true;
                    resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                    _logger.LogWarning($"Echèc création du InnovTouch produit, code produit : {InnovTouchProduit.CodeProduit}, InnovTouch : {InnovTouchProduit.InnovTouch.ToShortDateString()}, existe");
                    return resultat;
                }
                var InnovTouch = GererPropNavigation(_mapper.Map<InnovTouchProduit>(InnovTouchProduit));

                await _unitOfWork.InnovTouchProduits.CreateAsync(InnovTouch);
                await _unitOfWork.SaveAsync();
                resultat.Succeeded = true;
                resultat.Message = "InnovTouch produit bien crée";
                resultat.Data = InnovTouch.Id;
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc CreateAsync");
            }
            return resultat;
        }
        public async Task<Response<bool>> UpdateAsync(InnovTouchProduitDto InnovTouchProduit)
        {
            _logger.LogInformation($"UpdateAsync(id:{InnovTouchProduit.Id},CodeProduit:{InnovTouchProduit.Produit.Code},InnovTouch:{InnovTouchProduit.InnovTouch.ToShortDateString()},CodeMagasin:{InnovTouchProduit.Magasin?.Code})");
            Response<bool> resultat = new Response<bool>();
            try
            {
                var InnovTouchProduitExist = await _unitOfWork.InnovTouchProduits.AnyAsync(InnovTouch => InnovTouch.Id == InnovTouchProduit.Id);
                if (!InnovTouchProduitExist)
                {
                    resultat.Succeeded = true;
                    resultat.Message = $"InnovTouch produit n'existe pas, Id:{InnovTouchProduit.Id}";
                    resultat.Data = false;
                    return resultat;
                }

                var InnovTouch = GererPropNavigation(_mapper.Map<InnovTouchProduit>(InnovTouchProduit));

                var res = _unitOfWork.InnovTouchProduits.Update(InnovTouch);
                await _unitOfWork.SaveAsync();
                resultat.Succeeded = true;
                resultat.Message = $"InnovTouch produit modifié {res} ";
                resultat.Data = res;
            }

            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc CreateAsync");
            }
            return resultat;
        }
        public async Task<Response<List<InnovTouchProduitDto>>> GetAllAsync()
        {
            _logger.LogInformation($"GetAllAsync()");
            Response<List<InnovTouchProduitDto>> resultat = new Response<List<InnovTouchProduitDto>>();
            try
            {
                var InnovTouchProduits = await _unitOfWork.InnovTouchProduits.All()
                    .Include(InnovTouch => InnovTouch.Produit)
                    .ThenInclude(p => p.FamilleProduit)
                    .Include(InnovTouch => InnovTouch.Agent)
                    //.ThenInclude(ag => ag.Profile)
                   // .ThenInclude(pr => pr.Enseignes)
                    .Include(InnovTouch => InnovTouch.Magasin)
                    // .ThenInclude(m => m.Enseigne)
                    .Include(InnovTouch => InnovTouch.RespRemise)
                    .Include(InnovTouch => InnovTouch.RespRemiseValidation)
                    .Include(InnovTouch => InnovTouch.RespRetrait)
                    .Include(InnovTouch => InnovTouch.RespRetraitValidation)

                    .ToListAsync();
                resultat.Data = _mapper.Map<List<InnovTouchProduitDto>>(InnovTouchProduits);
                resultat.Succeeded = true;
                resultat.Message = $"Count : {resultat.Data.Count}";

            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, " Echèc GetAllAsync");
            }
            return resultat;
        }
        public async Task<Response<List<InnovTouchProduitDto>>> GetAllByFilter(FiltreInnovTouchDto filtre, DateTime today)
        {
            _logger.LogInformation($"GetAllByFilter({filtre})");
            Response<List<InnovTouchProduitDto>> resultat = new Response<List<InnovTouchProduitDto>>();
            //try
            //{
            //    var departementsResponse =  await _Service.GetDepartementsByLoginAsync(filtre.UserName);
            //    if (!departementsResponse.Succeeded)
            //    {
            //        resultat.Succeeded= false;
            //        resultat.Message = departementsResponse.Message;
            //        return resultat;
            //    }
            //    IQueryable<InnovTouchProduit> InnovTouchProduitsQuery = GetAllInnovTouchProduit(filtre.CodeMagasin, departementsResponse.Data);

            //    InnovTouchProduitsQuery = InnovTouchProduitsQuery.Join(
            //        _unitOfWork.AlerteProduits.All(),
            //        InnovTouch => InnovTouch.Produit.FamilleProduitId,
            //        alerte => alerte.FamilleProduitId,
            //        (InnovTouch, alerte) => new { InnovTouchProduit = InnovTouch, AlerteProduit = alerte })
            //        .Where(dp => dp.AlerteProduit.EnseigneId == dp.InnovTouchProduit.Magasin &&
            //                    (today.Date == dp.InnovTouchProduit.InnovTouch.Date ||
            //                     DateTime.Compare(today, dp.InnovTouchProduit.InnovTouch.AddDays(-dp.AlerteProduit.NbrJour)) >= 0))

            //        .Select(dp =>
            //        dp.InnovTouchProduit
            //        );

            //    #region old query for alrte
            //    //var result = InnovTouchProduitsQuery
            //    //    .Join(
            //    //        _unitOfWork.Produits.All(),
            //    //        InnovTouch => InnovTouch.ProduitId,
            //    //        prod => prod.Id,
            //    //        (InnovTouch, prod) => new { InnovTouchProduit = InnovTouch, Produit = prod })
            //    //    .Join(
            //    //        _unitOfWork.AlerteProduits.All(),
            //    //        dp => dp.Produit.FamilleProduitId,
            //    //        alerte => alerte.FamilleProduitId,
            //    //        (dp, alerte) => new { InnovTouchProduit = dp.InnovTouchProduit, AlerteProduit = alerte })
            //    //    .Where(dp => dp.AlerteProduit.EnseigneId == dp.InnovTouchProduit.Magasin.EnseigneId &&
            //    //                (today.Date == dp.InnovTouchProduit.InnovTouch.Date ||
            //    //                 DateTime.Compare(
            //    //                     today,
            //    //                     dp.InnovTouchProduit.InnovTouch.AddDays(-dp.AlerteProduit.NbrJour)) >= 0))
            //    //    .Select(dp => dp.InnovTouchProduit);
            //    #endregion


            //    if (!string.IsNullOrEmpty(filtre.CodeFamilleProduit))
            //    {
            //        InnovTouchProduitsQuery = InnovTouchProduitsQuery
            //            .Where(InnovTouch => filtre.CodeFamilleProduit.ToUpper().Equals(InnovTouch.CodeFamilleProduit.ToUpper()));
            //    }
            //    if (!string.IsNullOrEmpty(filtre.CodeProduit))
            //    {
            //        InnovTouchProduitsQuery = InnovTouchProduitsQuery
            //            .Where(InnovTouch => filtre.CodeProduit.ToUpper().Equals(InnovTouch.CodeProduit.ToUpper()));
            //    }
            //    if (filtre.DateInnovTouch != null)
            //    {
            //        InnovTouchProduitsQuery = InnovTouchProduitsQuery
            //            .Where(InnovTouch => filtre.DateInnovTouch.GetValueOrDefault().Date == InnovTouch.InnovTouch.Date);
            //    }
            //    if (filtre.ActionProduit == ActionProduit.Retrait)
            //    {
            //        InnovTouchProduitsQuery = InnovTouchProduitsQuery
            //            .Where(InnovTouch => InnovTouch.InnovTouch.Date == today.Date);
            //    }

                
            //    var InnovTouchProduits = await InnovTouchProduitsQuery.ToListAsync();
                
            //    resultat.Data = CalculerPropriete(InnovTouchProduits,today); 
            //    resultat.Succeeded = true;
            //    resultat.Message = $"Count:{resultat.Data.Count}";

            //}
            //catch (Exception ex)
            //{
            //    resultat.Succeeded = false;
            //    resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
            //    _logger.LogError(ex, " Echèc GetAllByFilter");
            //}
            return resultat;
        }

        private List<InnovTouchProduitDto> CalculerPropriete(List<InnovTouchProduit> InnovTouchProduits, DateTime today)
        {
            var InnovTouchProduitsDto = _mapper.Map<List<InnovTouchProduitDto>>(InnovTouchProduits);
            InnovTouchProduitsDto.ForEach(InnovTouch =>
            {
                int nbrJourRestant = (InnovTouch.InnovTouch - today).Days;
                ActionProduit action = ActionProduit.Rien;
                string actionAFaire = "";
                string codeCouleur = "#ffffff";

                if (nbrJourRestant <= 0)
                {
                    action = ActionProduit.Retrait;
                    actionAFaire = "Retrait";
                    codeCouleur = "#E90000";
                }
                else if (nbrJourRestant > 0)
                {
                    action = ActionProduit.Remise;
                    actionAFaire = "Remise";
                    codeCouleur = "#F4D03F";
                }

                InnovTouch.NbrJourRestant = nbrJourRestant;
                InnovTouch.Action = action;
                InnovTouch.ActionAFaire = actionAFaire;
                InnovTouch.CodeCouleur = codeCouleur;
            });
            return InnovTouchProduitsDto;
        }
        private IQueryable<InnovTouchProduit> GetAllInnovTouchProduit(string codeMagasin, string[] departements)
        {
            return _unitOfWork.InnovTouchProduits
                     .Where(InnovTouch => InnovTouch.CodeMagasin == codeMagasin && departements.Contains(InnovTouch.Produit.CodeDepartement))
                     .Include(InnovTouch => InnovTouch.Produit)
                     .ThenInclude(p => p.FamilleProduit)
                     .Include(InnovTouch => InnovTouch.Agent)
                     //.ThenInclude(ag => ag.Profile)
                     //.ThenInclude(pr => pr.Enseignes)
                     .Include(InnovTouch => InnovTouch.Magasin)
                     // .ThenInclude(m => m.Enseigne)
                     .Include(InnovTouch => InnovTouch.RespRemise)
                     .Include(InnovTouch => InnovTouch.RespRemiseValidation)
                     .Include(InnovTouch => InnovTouch.RespRetrait)
                     .Include(InnovTouch => InnovTouch.RespRetraitValidation);
        }
        private InnovTouchProduit GererPropNavigation(InnovTouchProduit InnovTouchProduit)
        {
            if (InnovTouchProduit.Produit != null)
            {
                InnovTouchProduit.ProduitId = InnovTouchProduit.Produit.Id;
                InnovTouchProduit.CodeProduit = InnovTouchProduit.Produit.Code;
                InnovTouchProduit.LibelleProduit = InnovTouchProduit.Produit.Libelle;
                if (InnovTouchProduit.Produit.FamilleProduit != null)
                {
                    InnovTouchProduit.CodeFamilleProduit = InnovTouchProduit.Produit.FamilleProduit.Code;
                    InnovTouchProduit.LibelleFamilleProduit = InnovTouchProduit.Produit.FamilleProduit.Libelle;
                }
                InnovTouchProduit.Produit = null;
            }
            if (InnovTouchProduit.Agent != null)
            {
                InnovTouchProduit.AgentId = InnovTouchProduit.Agent.Id;
                InnovTouchProduit.Agent = null;
            }
            if (InnovTouchProduit.RespRemise != null)
            {
                InnovTouchProduit.RespRemiseId = InnovTouchProduit.RespRemise.Id;
                InnovTouchProduit.RespRemise = null;
            }
            if (InnovTouchProduit.RespRemiseValidation != null)
            {
                InnovTouchProduit.RespRemiseValidationId = InnovTouchProduit.RespRemiseValidation.Id;
                InnovTouchProduit.RespRemiseValidation = null;
            }
            if (InnovTouchProduit.RespRetrait != null)
            {
                InnovTouchProduit.RespRetraitId = InnovTouchProduit.RespRetrait.Id;
                InnovTouchProduit.RespRetrait = null;
            }
            if (InnovTouchProduit.RespRetraitValidation != null)
            {
                InnovTouchProduit.RespRetraitValidationId = InnovTouchProduit.RespRetraitValidation.Id;
                InnovTouchProduit.RespRetraitValidation = null;
            }
            if (InnovTouchProduit.Magasin != null)
            {
                InnovTouchProduit.MagasinId = InnovTouchProduit.Magasin.Id;
                InnovTouchProduit.CodeMagasin = InnovTouchProduit.Magasin.Code;
                InnovTouchProduit.Magasin = null;
            }
            return InnovTouchProduit;
        }

        public async Task<Response<List<InnovTouchProduitDto>>> GetAllInnovTouchByProduit(string userName, string codeMagasin, string codeBarre, DateTime today)
        {
            _logger.LogInformation($"GetAllInnovTouchByProduit(userName:{userName}, codeMagasin: {codeMagasin}, codeBarre:{codeBarre})");
            Response<List<InnovTouchProduitDto>> resultat = new Response<List<InnovTouchProduitDto>>();
            try
            {
                var departementsResponse = await _Service.GetDepartementsByLoginAsync(userName);
                if (!departementsResponse.Succeeded)
                {
                    resultat.Succeeded = false;
                    resultat.Message = departementsResponse.Message;
                    return resultat;
                }
                IQueryable<InnovTouchProduit> InnovTouchProduitsQuery = GetAllInnovTouchProduit(codeMagasin, departementsResponse.Data);

                InnovTouchProduitsQuery = InnovTouchProduitsQuery.Where(InnovTouch => InnovTouch.CodeProduit == codeBarre && InnovTouch.QteActualise > 0);

                var InnovTouchProduits = await InnovTouchProduitsQuery.ToListAsync();
               
                resultat.Data = CalculerPropriete(InnovTouchProduits, today); 
                resultat.Succeeded = true;
                resultat.Message = $"Count:{resultat.Data.Count}";

            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, " Echèc GetAllByFilter");
            }
            return resultat;
        }

        public async Task<Response<List<InnovTouchProduitDto>>> GetAllInnovTouchCasseFrais(string userName, string codeMagasin, DateTime today)
        {
            _logger.LogInformation($"GetAllInnovTouchCasseFrais(userName:{userName}, codeMagasin: {codeMagasin})");
            Response<List<InnovTouchProduitDto>> resultat = new Response<List<InnovTouchProduitDto>>();
            try
            {
                var departementsResponse = await _Service.GetDepartementsByLoginAsync(userName);
                if (!departementsResponse.Succeeded)
                {
                    resultat.Succeeded = false;
                    resultat.Message = departementsResponse.Message;
                    return resultat;
                }
                IQueryable<InnovTouchProduit> InnovTouchProduitsQuery = GetAllInnovTouchProduit(codeMagasin, departementsResponse.Data);

                InnovTouchProduitsQuery = InnovTouchProduitsQuery.Where(
                    InnovTouch => InnovTouch.IsRemiseValide == true
                     && (InnovTouch.IsRemiseApplique == false || InnovTouch.IsRemiseApplique == null));
                var InnovTouchProduits = await InnovTouchProduitsQuery.ToListAsync();
                
                resultat.Data = CalculerPropriete(InnovTouchProduits, today); 
                resultat.Succeeded = true;
                resultat.Message = $"Count:{resultat.Data.Count}";
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, " Echèc GetAllInnovTouchCasseFrais");
            }
            return resultat;
        }
    }
}
