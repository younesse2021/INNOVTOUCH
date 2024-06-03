using BlazorFileSaver;
using DLC_BO.Client.Service;
using InnovTouch_BO.Client.Models;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Inventaire;
using Shared.DTO.InnovTouch.DTO.Produit;

namespace InnovTouch_BO.Client.Service.Magasin
{
    public class MagasinService : BaseService<MagasinDto>, ICRUDService<MagasinDto>
    {
        private  readonly string _urlController = "inventaire/";

        private readonly IBlazorFileSaver _blazorFileSaver;
        public MagasinService(HttpClient httpClient, AppStateContainer appStateContainer, IBlazorFileSaver blazorFileSaver) : base(httpClient, appStateContainer)
        {
            _blazorFileSaver = blazorFileSaver;
        }
        public async Task<Response<int>> Add(MagasinDto model)
        {
            throw new NotImplementedException();
        }
        public Task<Response<bool>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Response<bool>> Edit(MagasinDto model)
        {
            throw new NotImplementedException();
        }
        public async Task<Response<List<MagasinDto>>> GetAll()
        {
            return await All($"{_urlController}GetAllMagasin");
        }
        public Task<Response<MagasinDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
