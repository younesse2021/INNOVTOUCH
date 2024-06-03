

using InnovTouch_BO.Client.Models;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Produit;

namespace DLC_BO.Client.Service.Produits
{
    public class FamilleProduitService : BaseService<FamilleProduitDto>, ICRUDService<FamilleProduitDto>
    {
        private readonly string urlController = "api/familleproduits";
        public FamilleProduitService(HttpClient httpClient, AppStateContainer appStateContainer) : base(httpClient, appStateContainer)
        {
        }

        public Task<Response<int>> Add(FamilleProduitDto model)
        {
            return base.Add($"{urlController}/create", model);  
        }

        public Task<Response<bool>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> Edit(FamilleProduitDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<FamilleProduitDto>>> GetAll()
        {
            return await All(urlController);
        }

        public Task<Response<FamilleProduitDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
