using InnovTouch_BO.Client.Models;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Helper;

namespace DLC_BO.Client.Service.Entite
{
    public class EnseigneService : BaseService<EnseigneDto>, ICRUDService<EnseigneDto>
    {

        private readonly string urlController = "api/enseignes";
        public EnseigneService(HttpClient httpClient, AppStateContainer appStateContainer) : base(httpClient, appStateContainer)
        {
        }

        public Task<Response<int>> Add(EnseigneDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> Edit(EnseigneDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<EnseigneDto>>> GetAll()
        {
            return await All(urlController);
        }

        public Task<Response<EnseigneDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
