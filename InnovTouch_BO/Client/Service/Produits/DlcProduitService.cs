using InnovTouch_BO.Client.Models;
using Shared.DTO.DLC.DTO.Produit;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Helper;
using BlazorFileSaver;
using Shared.DTO.InnovTouch.DTO.Inventaire;

namespace DLC_BO.Client.Service.Produits
{
    public class DlcProduitService : BaseService<DlcProduitDto>, ICRUDService<DlcProduitDto>
    {
        private readonly string _urlController = "Inventaire";
        private readonly IBlazorFileSaver _blazorFileSaver;

        public DlcProduitService(HttpClient httpClient, AppStateContainer appStateContainer, IBlazorFileSaver blazorFileSaver) : base(httpClient, appStateContainer)
        {
            _blazorFileSaver = blazorFileSaver;
        }
        #region "NotImplemented"
        public Task<Response<int>> Add(DlcProduitDto model)
        {
            throw new NotImplementedException();
        }
        public Task<Response<bool>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Response<bool>> Edit(DlcProduitDto model)
        {
            throw new NotImplementedException();
        }
        public Task<Response<DlcProduitDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Response<List<DlcProduitDto>>> GetAll()
        {
            throw new NotImplementedException();
        }
        #endregion

        public Task<Response<List<DlcProduitDto>>> GetAllByFiltre(FiltreDto filtre)
        {
            return base.AllWithModel($"{_urlController}/controle/filtre", filtre);
        }
        public async Task DowloadExport(int filtre)
        {
            var response = await base.DowloadFileWithModel($"{_urlController}/controle/export/filtre", filtre);
            await _blazorFileSaver.SaveAsBase64("InovTouch produit.xlsx", Convert.ToBase64String(response.Data), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task DowloadExport(List<AddInfentaireDto> filtre)
        {
            var response = await base.DowloadFileWithModel($"{_urlController}/controle/export/filtre", filtre);
            await _blazorFileSaver.SaveAsBase64("dlc produit.xlsx", Convert.ToBase64String(response.Data), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}
