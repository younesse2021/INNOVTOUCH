using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Inventaire;
using Shared.Models;
using Shared.Models.IN;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Contrat
{
    public interface IInentaireServicecs
    {
        Task<Response<bool>> AddInventaire(CreateInventaireModel addinentair);
        Task<Response<List<Shared.DTO.InnovTouch.DTO.Inventaire.ExportExcelModelDto>>> GetAll();
        Task<Response<List<MagasinDto>>> GetAllMagsin();
        Response<int> AddInventaire(InventoryDTO model);
        Response<bool> EditInventaire(InventoryDTO model);
        Response<List<DAL.InnovTouch.DOMAIN.Models.Inventaire.Rayone>> GetAllRayone();
        Response<List<DAL.InnovTouch.DOMAIN.Models.Inventaire.Inventory>> GetAllInventaire();
        Response<int> CreateEmplacement(Emplacement model);
        Response<List<Emplacement>> GetAllEmplacement();
        Response<int> EditEmplacement(Emplacement model);
        Response<int> DeleteEmplacement(Emplacement id);
        Response<List<DetailsLot>> GetAllDetailsLot();
        Response<bool> UpdateQentity(ExportExcelModelDto model);
        Response<DetailsLot> GetCodeIn(InventairesModel model);
        Response<bool> DeleteInventaire(int id);
        Response<bool> ValidationLot(InventairesModel model);


    }
}
