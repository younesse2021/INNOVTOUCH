using InnovTouch_BO.Client.Models;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Role;

namespace DLC_BO.Client.Service.Role
{
    public class ProfileService : BaseService<ProfileDto>, ICRUDService<ProfileDto>
    {
        private readonly string urlController = "api/profiles";
        public ProfileService(HttpClient httpClient, AppStateContainer appStateContainer) : base(httpClient, appStateContainer)
        {
        }

        public Task<Response<int>> Add(ProfileDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> Edit(ProfileDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ProfileDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Response<ProfileDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Response<List<ProfileDto>>> GetAllByEnseigneId(int enseigneId)
        {
            return await All($"{urlController}/enseigne/{enseigneId}");
        }
    }
}
