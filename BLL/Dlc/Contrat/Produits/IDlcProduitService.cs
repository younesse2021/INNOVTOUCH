using Shared.DTO.InnovTouch.DTO.Helpers;
using Shared.DTO.InnovTouch.DTO.Models.Helper;
using Shared.DTO.InnovTouch.DTO.Produit;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO.InnovTouch.DTO.Helper;

namespace BLL.InnovTouch.Contrat.Produits
{
    public interface IInnovTouchProduitService
    {
        Task<Response<List<InnovTouchProduitDto>>> GetAllAsync();
        Task<Response<List<InnovTouchProduitDto>>> GetAllByFilter(FiltreInnovTouchDto filtre,DateTime today);
        Task<Response<List<InnovTouchProduitDto>>> GetAllInnovTouchByProduit(string userName,string codeMagasin,string codeBarre, DateTime today);
        Task<Response<int>> CreateAsync(InnovTouchProduitDto InnovTouchProduit);
        Task<Response<bool>> UpdateAsync(InnovTouchProduitDto InnovTouchProduit);
        Task<Response<List<InnovTouchProduitDto>>>  GetAllInnovTouchCasseFrais(string userName, string codeMagasin, DateTime today);
    }
}
