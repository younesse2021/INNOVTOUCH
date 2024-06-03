

using InnovTouch_BO.Client.Models;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Role;

namespace DLC_BO.Client.Service.Role
{
    public class UtilisateurService : BaseService<UtilisateurDto>,ICRUDService<UtilisateurDto>
    {
        private readonly string urlController = "utilisateurs";
        public UtilisateurService(HttpClient httpClient, AppStateContainer appStateContainer) : base(httpClient, appStateContainer)
        {
        }
        public async Task<Response<int>> Add(UtilisateurDto model)
        {
            return await base.Add($"{urlController}", model);
        }

        public async Task<Response<bool>> DeleteById(int id)
        {
            return await Delete($"{urlController}/{id}");
        }

        public async Task<Response<bool>> Edit(UtilisateurDto model)
        {
            return await Edit($"{urlController}", model);
        }

        public async Task<Response<List<UtilisateurDto>>> GetAll()
        {
            return await All($"{urlController}/GetAllUser");
        }

        public async Task<Response<UtilisateurDto>> GetById(int id)
        {
            return await GetItem($"{urlController}/{id}");
        }
    }
}
