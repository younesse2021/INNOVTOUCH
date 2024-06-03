using Shared.DTO;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Produit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.Contrat.Produits
{
    public interface IProduitService
    {
        Task<Response<ProduitDto>> GetByCodeAsync(string code);
        Task<Response<ProduitDto>> GetOrCreateByCodeAsync(string code);
    }
}
