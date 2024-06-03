



using DLC_BO.Client.Service;
using Shared.DTO.InnovTouch.DTO.Bo;
using Shared.DTO.InnovTouch.DTO.Helper;

namespace InnovTouch_BO.Client.Service.Bo
{
    public class UtilisateurBoService : BaseService<UtilisateurBoDto>
    {
        private readonly string _urlController = "utilisateurs";
        public UtilisateurBoService(HttpClient httpClient, Models.AppStateContainer appStateContainer) : base(httpClient,appStateContainer)
        {
        }
        public async Task<Response<UtilisateurBoDto>> ConnectAsync(UtilisateurBoDto usrBo)
        {
            return await base.GetItemWithModel($"{_urlController}/bo/connect", usrBo);
        }
    }
}
