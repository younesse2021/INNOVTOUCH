using BlazorFileSaver;
using DLC_BO.Client.Service;
using InnovTouch_BO.Client.Models;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Inventaire;

namespace InnovTouch_BO.Client.Service.DetailsLotService
{
    public class DetailLotService :BaseService<DetailsLotDto>, ICRUDService<DetailsLotDto>
    {
        private readonly string _urlController = "inventaire/";

        private readonly IBlazorFileSaver _blazorFileSaver;
        public DetailLotService(HttpClient httpClient, AppStateContainer appStateContainer, IBlazorFileSaver blazorFileSaver) : base(httpClient, appStateContainer)
        {
            _blazorFileSaver = blazorFileSaver;
        }

        public Task<Response<int>> Add(DetailsLotDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> Edit(DetailsLotDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<DetailsLotDto>>> GetAll()
        {
            return await All($"{_urlController}GetAllLot");
        }

        public Task<Response<DetailsLotDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
