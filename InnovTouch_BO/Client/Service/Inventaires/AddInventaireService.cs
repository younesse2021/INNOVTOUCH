using BlazorFileSaver;
using DLC_BO.Client.Service;
using InnovTouch_BO.Client.Models;
using Newtonsoft.Json;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Inventaire;

namespace InnovTouch_BO.Client.Service.Inventaires
{
    public class AddInventaireService : BaseService<InventoryDTO>, ICRUDService<InventoryDTO>
    {
        private readonly string _urlController = "inventaire/";
        private readonly IBlazorFileSaver _blazorFileSaver;
        public AddInventaireService(HttpClient httpClient, AppStateContainer appStateContainer, IBlazorFileSaver blazorFileSaver) : base(httpClient, appStateContainer)
        {
            _blazorFileSaver = blazorFileSaver;
        }

        public async Task<Response<int>> Add(InventoryDTO model)
        {
            return await Add($"{_urlController}AddInventaire", model);
        }

        public async Task<Response<bool>> EditInventaire(InventoryDTO model)
        {
            return await Edit($"{_urlController}Edit", model);
        }

        public Task<Response<bool>> DeleteById(int id)
        {
            return Delete($"{_urlController}DeleteInventaire/{id}");
        }

        public async Task<Response<List<InventoryDTO>>> GetAll()
        {
            return await All($"{_urlController}GetAllInventaire");
        }

        public Task<Response<InventoryDTO>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> Edit(InventoryDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
