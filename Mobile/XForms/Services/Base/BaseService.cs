using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.DTO.InnovTouch.DTO.Role;
using Shared.Models;
using Shared.Models.OUT;
using XForms.Enums;
using XForms.HttpREST;
using XForms.Interfaces;

namespace XForms.Services
{
    public class BaseService
    {
        private readonly ILogger Logger;
        public BaseService(ILogger logger = null)
        {
            Logger = logger ?? new AppCenterLogger();
        }

        #region SingIn
        //public async Task<List<AuthResponse>> LoginAction(AuthModel postParams)
        //{
        //    return await RESTHelper.POSTLoginResultModel(postParams);
        //}

        public async Task<RESTServiceResponse<UtilisateurDto>> LoginAction(UtilisateurDto postParams)
        {
            return await RESTHelper.GetRequest<UtilisateurDto>(url: AppUrls.POSTLogin, postObject: postParams, method: HttpVerbs.POST);
        }
        #endregion


        #region RefreshToken
        //public async Task<RESTServiceResponse<RefreshTokenResultDataModel>> PostRefreshToken(GraphQLRequest postRequest)
        //{
        //    return await RESTHelper.GetRequest<RefreshTokenResultDataModel>(url: AppUrls.BaseUrl, postRequest: postRequest);
        //}
        #endregion

    }
}