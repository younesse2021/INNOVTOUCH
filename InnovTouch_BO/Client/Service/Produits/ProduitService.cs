

using InnovTouch_BO.Client.Models;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Produit;

namespace DLC_BO.Client.Service.Produits
{
    public class ProduitService : BaseService<ProduitDto>, ICRUDService<ProduitDto>
    {
        public readonly string _urlController = "api/produits";
        public ProduitService(HttpClient httpClient, AppStateContainer appStateContainer) : base(httpClient, appStateContainer)
        {
        }

        public Task<Response<int>> Add(ProduitDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> Edit(ProduitDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ProduitDto>>> GetAll()
        {
            return base.All(_urlController);
        }

        public Task<Response<ProduitDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
