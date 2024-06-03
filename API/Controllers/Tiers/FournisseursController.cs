using DAL.InnovTouch.DOMAIN.Models.Produits;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Produit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using System.Threading.Tasks;
using Shared.DTO.InnovTouch.DTO.Helper;

namespace API.Controllers.Tiers
{
    [Route("api/fournisseurs")]
    [ApiController]
    public class FournisseursController : ControllerBase
    {
        [HttpGet("produits/{CodeBarreProduit}")]
        public async Task<IActionResult> GetByCodeProduit(string CodeBarreProduit) {
            FournisseurDto f = new FournisseurDto() {
                Cnuf = "12415",
                RaisonSocial = "Fournisseur Xqw",
                Adresse = "Sidi maarouf",
                Ville = "Casablanca",
                Email = "four@email.com",
                Telephone = "0658745147",
                Patente = 123456
            };

            Response<FournisseurDto> resp = new Response<FournisseurDto>();
            resp.Data = f;
            resp.Succeeded = true;
            return Ok(await Task.FromResult(resp));
        }
    }
}
