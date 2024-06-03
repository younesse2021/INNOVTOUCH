using BlazorFileSaver;
using DLC_BO.Client.Service;
using InnovTouch_BO.Client.Models;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Produit;

namespace InnovTouch_BO.Client.Service.Produits
{
    public class MultyDataForm : BaseService<MultipartFormDataContent>, ICRUDService<MultipartFormDataContent>
    {
        private readonly string _urlController = "Inventaire/";
        private readonly IBlazorFileSaver _blazorFileSaver;
        public MultyDataForm(HttpClient httpClient, AppStateContainer appStateContainer, IBlazorFileSaver blazorFileSaver) : base(httpClient, appStateContainer)
        {
            _blazorFileSaver = blazorFileSaver;
        }

        public async Task<Response<int>> Add(MultipartFormDataContent model)
        {
            return await Add($"{_urlController}upload", model);
        }

        public Task<Response<bool>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> Edit(MultipartFormDataContent model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<MultipartFormDataContent>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Response<MultipartFormDataContent>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
