using BLL;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.IN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class DemandeEtiquetteController : BaseController
    {
        [HttpPost("api/eti/article")]
        public async Task<IActionResult> ArticleByEAN(ArticleByEANModel model)
        {
            var biz = new DemandeEtiquetteService();
            var response = await biz.ArticleInfos(Base.Init().BaseUrlImage, Base.Init().BaseUrlAPI, model);
            return Ok(response);
        }

        [HttpPost("api/eti/formats")]
        public async Task<IActionResult> Formats(FormatsModel model)
        {
            var biz = new DemandeEtiquetteService();
            var response = await biz.Formats(Base.Init().BaseUrlAPI, model);
            return Ok(response);
        }

        [HttpPost("api/eti/create")]
        public async Task<IActionResult> CreateEtiquette(CreateEtiquetteModel model)
        {
            var biz = new DemandeEtiquetteService();
            var response = await biz.CreateEtiquette(Base.Init().BaseUrlAPI, model);
            return Ok(response);
        }

        [HttpPost("api/eti/imprimer")]
        public async Task<IActionResult> ImprimerEtiquette(ImprimerEtiquetteModel model)
        {
            var biz = new DemandeEtiquetteService();
            var response = await biz.Imprimertiquette(Base.Init().Host_SSH, Base.Init().Username_SSH, Base.Init().Password_SSH, model);
            return Ok(response);
        }

    }
}
