using InnovTouch_BO.Client.Models;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Produit;

namespace DLC_BO.Client.Service.Produits
{
    public class AlerteProduitService : BaseService<AlerteProduitDto>, ICRUDService<AlerteProduitDto>
    {
        private readonly string urlController = "alerteproduits/";
        public AlerteProduitService(HttpClient httpClient, AppStateContainer appStateContainer) : base(httpClient, appStateContainer)
        {
        }

        public Task<Response<int>> Add(AlerteProduitDto model)
        {
            return base.Add(urlController, model);
        }
        public Task<Response<bool>> DeleteById(int id)
        {
            return base.Delete($"{urlController}/DeleteInventaire/{id}");
        }
        public Task<Response<bool>> Edit(AlerteProduitDto model)
        {
            return base.Edit(urlController, model);
        }
        public Task<Response<List<AlerteProduitDto>>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<Response<List<AlerteProduitDto>>> GetAllByFiltre(int? enseigneId, int? familleProduitId)
        {
            return base.All($"{urlController}/enseigne/{(!enseigneId.HasValue? "all":enseigneId)}/familleproduit/{(!familleProduitId.HasValue ? "all" : familleProduitId)}");
        }
        public Task<Response<List<AlerteProduitDto>>> GetAllByFiltreDto(FiltreDto? filtre)
        {
            return base.AllWithModel($"{urlController}/filtre", filtre);
        }
        public Task<Response<AlerteProduitDto>> GetById(int id)
        {
            return base.GetItem($"{urlController}/{id}");
        }
    }
}
