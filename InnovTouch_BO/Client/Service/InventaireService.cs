using BlazorFileSaver;
using DLC_BO.Client.Service;
using InnovTouch_BO.Client.Models;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Inventaire;

namespace InnovTouch_BO.Client.Service
{
    public class InventaireService : BaseService<ExportExcelModelDto>, ICRUDService<ExportExcelModelDto>
    {
        private readonly string _urlController = "inventaire/";
        private readonly IBlazorFileSaver _blazorFileSaver;
        public InventaireService(HttpClient httpClient, AppStateContainer appStateContainer, IBlazorFileSaver blazorFileSaver) : base(httpClient, appStateContainer)
        {
            _blazorFileSaver = blazorFileSaver;
        }

        #region Implement Servies

        public Task<Response<bool>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> Edit(AddInfentaireDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<AddInfentaireDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Response<AddInfentaireDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region not implemented
        public async Task<Response<List<ExportExcelModelDto>>> GetAllByFiltre()
        {
            return await All($"{_urlController}GetAll");
        }
        Task<Response<List<ExportExcelModelDto>>> ICRUDService<ExportExcelModelDto>.GetAll()
        {
            throw new NotImplementedException();
        }
        Task<Response<ExportExcelModelDto>> ICRUDService<ExportExcelModelDto>.GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Response<int>> Add(ExportExcelModelDto model)
        {
            throw new NotImplementedException();
        }
        public async Task<Response<bool>> Edit(ExportExcelModelDto model)
        {
            return await Edit($"{_urlController}EditQentity", model);
        }
        #endregion
    }
}

