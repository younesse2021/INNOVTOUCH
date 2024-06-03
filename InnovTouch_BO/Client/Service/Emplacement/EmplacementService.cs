using BlazorFileSaver;
using DLC_BO.Client.Service;
using InnovTouch_BO.Client.Models;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Inventaire;

namespace InnovTouch_BO.Client.Service.Emplacement
{
    public class EmplacementService : BaseService<EmplacementDetails>, ICRUDService<EmplacementDetails>
    {
        private readonly string _urlController = "inventaire/";
        private readonly IBlazorFileSaver _blazorFileSaver;
        public EmplacementService(HttpClient httpClient, AppStateContainer appStateContainer, IBlazorFileSaver blazorFileSaver) : base(httpClient, appStateContainer)
        {
            _blazorFileSaver = blazorFileSaver;
        }

        public async Task<Response<int>> Add(EmplacementDetails model)
        {
            return await Add($"{_urlController}CreateEmplacement", model);
        }

        public async Task<Response<int>> DeleteEmplacement(EmplacementDetails model)
        {
            return await Add($"{_urlController}DeleteEmplacement", model);
        }


        public async Task<Response<int>> EditEmplacement(EmplacementDetails model)
        {
            var res =  await Add($"{_urlController}EditEmplacement", model);
            return res;
        }

        public async Task DowloadExport(int filtre)
        {
            var response = await base.DowloadFileWithModel($"{_urlController}controle/export/ExportLot", filtre);
            await _blazorFileSaver.SaveAsBase64("Details Lot.xlsx", Convert.ToBase64String(response.Data), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<Response<bool>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> Edit(EmplacementDetails model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<EmplacementDetails>>> GetAll()
        {
            return await All($"{_urlController}GetAllEmplacement");
        }

        public Task<Response<EmplacementDetails>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
