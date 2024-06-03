using BlazorFileSaver;
using DLC_BO.Client.Service;
using InnovTouch_BO.Client.Models;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Inventaire;

namespace InnovTouch_BO.Client.Service.Inventaires
{
    public class RayoneService : BaseService<RayoneDto>, ICRUDService<RayoneDto>
    {
        private readonly string _urlController = "inventaire/";
        private readonly IBlazorFileSaver _blazorFileSaver;
        public RayoneService(HttpClient httpClient, AppStateContainer appStateContainer, IBlazorFileSaver blazorFileSaver) : base(httpClient, appStateContainer)
        {
            _blazorFileSaver = blazorFileSaver;
        }

        public Task<Response<int>> Add(RayoneDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> Edit(RayoneDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<RayoneDto>>> GetAll()
        {
            return await All($"{_urlController}GetAllRayone");
        }

        public Task<Response<RayoneDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
