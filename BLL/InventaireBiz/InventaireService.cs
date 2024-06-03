using Shared.Models.IN;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;
using AutoMapper;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using System.Linq;
using BLL.Services.Contrat;
using Shared.DTO.InnovTouch.DTO.Inventaire;
using Shared.DTO.InnovTouch.DTO.Entite;
using Microsoft.Extensions.Configuration;
using Shared.Models.OUT.Inventaires;
using DAL.InnovTouch.DOMAIN.Models.Inventaire;

namespace BLL
{
    public class InventaireService : BaseService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;
        private readonly IInentaireServicecs _IInentaireServicecs;
        private readonly IConfiguration _IIConfiguration;
        public InventaireService(IUnitOfWork iUnitOfWork, IMapper mapper, IInentaireServicecs inentaireServicecs, IConfiguration iConfiguration)
        {
            _IUnitOfWork = iUnitOfWork;
            _mapper = mapper;
            _IInentaireServicecs = inentaireServicecs;
            this._IIConfiguration = iConfiguration;
        }
        public async Task<Response<Inventories>> Inventaires(InventairesModel model)
        {
            try
            {
                Inventories list = new Inventories();
                List<Shared.Models.OUT.Inventaires.Inventory> ListOfInn = new List<Shared.Models.OUT.Inventaires.Inventory>();
                Shared.Models.OUT.Inventaires.Inventory Invenatir = new Shared.Models.OUT.Inventaires.Inventory();

                var ListOfIn = _IUnitOfWork.Inventory.All();

                if (ListOfIn.Count() != 0)
                {
                    var Responce = new Response<Inventories>();
                    Responce.Succeeded = true;
                    Responce.Errors = null;

                    foreach (var item in ListOfIn)
                    {
                        ListOfInn.Add(new Shared.Models.OUT.Inventaires.Inventory()
                        {
                            number = item.number,
                            description = item.description,
                            stockPosition = item.stockPosition,
                            valorisationDate = item.valorisationDate
                        });
                    }

                    list.inventory = ListOfInn;
                    Responce.Data = list;
                    return Responce;
                }
                else
                {
                    var Responce = new Response<Inventories>();
                    Responce.Succeeded = false;
                    Responce.Errors = new List<string>() { "Acune item inventaire" };
                    Responce.Data = null;
                    return Responce;
                }
            }
            catch (Exception ex)
            {
                var Responce = new Response<Inventories>();
                Responce.Succeeded = false;
                Responce.Errors = new List<string>() { "Acune item inventaire" };
                Responce.Data = null;
                Responce.Message = $"{ex.Message}";
                return Responce;
            }
        }
        public async Task<Response<bool>> CreateInventaire(CreateInventaireModel model)
        {
            try
            {
                return await _IInentaireServicecs.AddInventaire(model);
            }
            catch (Exception ex)
            {
                return new Response<bool>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public async Task<Response<List<ExportExcelModelDto>>> GetAll()
        {
            try
            {
                return await _IInentaireServicecs.GetAll();
            }
            catch (Exception ex)
            {
                return new Response<List<ExportExcelModelDto>>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public async Task<Response<List<MagasinDto>>> GetAllMagasin()
        {
            try
            {
                return await _IInentaireServicecs.GetAllMagsin();
            }
            catch (Exception ex)
            {
                return new Response<List<MagasinDto>>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public Response<int> AddInventaire(InventoryDTO model)
        {
            try
            {
                return _IInentaireServicecs.AddInventaire(model);
            }
            catch (Exception ex)
            {
                return new Response<int>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public Response<List<DAL.InnovTouch.DOMAIN.Models.Inventaire.Rayone>> GetAllRayone()
        {
            try
            {
                return _IInentaireServicecs.GetAllRayone();
            }
            catch (Exception ex)
            {
                return new Response<List<DAL.InnovTouch.DOMAIN.Models.Inventaire.Rayone>>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public Response<List<DAL.InnovTouch.DOMAIN.Models.Inventaire.Inventory>> GetAllInventaire()
        {
            try
            {
                return _IInentaireServicecs.GetAllInventaire();
            }
            catch (Exception ex)
            {
                return new Response<List<DAL.InnovTouch.DOMAIN.Models.Inventaire.Inventory>>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public Response<bool> EditInventaire(InventoryDTO model)
        {
            try
            {
                return _IInentaireServicecs.EditInventaire(model);
            }
            catch (Exception ex)
            {
                return new Response<bool>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public Response<int> CreateEmplacement(Emplacement model)
        {
            try
            {
                return _IInentaireServicecs.CreateEmplacement(model);
            }
            catch (Exception ex)
            {
                return new Response<int>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public Response<bool> ValidationLot(InventairesModel model)
        {
            try
            {
                return _IInentaireServicecs.ValidationLot(model);
            }
            catch (Exception ex)
            {
                return new Response<bool>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public Response<List<Emplacement>> GetAllEmplacement()
        {
            try
            {
                return _IInentaireServicecs.GetAllEmplacement();
            }
            catch (Exception ex)
            {
                return new Response<List<Emplacement>>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public Response<int> EditEmplacement(Emplacement model)
        {
            try
            {
                return _IInentaireServicecs.EditEmplacement(model);
            }
            catch (Exception ex)
            {
                return new Response<int>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public Response<int> DeleteEmplacement(Emplacement id)
        {
            try
            {
                return _IInentaireServicecs.DeleteEmplacement(id);
            }
            catch (Exception ex)
            {
                return new Response<int>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public Response<List<DetailsLot>> GetAllDetails()
        {
            try
            {
                return _IInentaireServicecs.GetAllDetailsLot();
            }
            catch (Exception ex)
            {
                return new Response<List<DetailsLot>>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public Response<bool> UpdateQentity(ExportExcelModelDto model)
        {
            try
            {
                return _IInentaireServicecs.UpdateQentity(model);
            }
            catch (Exception ex)
            {
                return new Response<bool>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public Response<DetailsLot> GetCodeIn(InventairesModel model)
        {
            try
            {
                return _IInentaireServicecs.GetCodeIn(model);
            }
            catch (Exception ex)
            {
                return new Response<DetailsLot>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
        public Response<bool> DeleteInventaire(int id)
        {
            try
            {
                return _IInentaireServicecs.DeleteInventaire(id);
            }
            catch (Exception ex)
            {
                return new Response<bool>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

    }
}
