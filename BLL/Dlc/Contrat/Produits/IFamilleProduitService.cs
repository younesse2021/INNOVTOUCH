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
    public interface IFamilleProduitService
    {
        Task<Response<FamilleProduitDto>> GetByCodeAsync(string code);
        Task<Response<List<FamilleProduitDto>>> GetAllAsync();
        Task<Response<FamilleProduitDto>> GetOrCreateByCodeAsync(string code);
        Task<Response<bool>> UpdateAsync(FamilleProduitDto familleProduit);
    }
}
