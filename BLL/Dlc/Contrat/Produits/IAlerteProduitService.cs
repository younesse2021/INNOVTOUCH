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
    public interface IAlerteProduitService
    {
        Task<Response<List<AlerteProduitDto>>> AllAsync();
        Task<Response<List<AlerteProduitDto>>> AllByFiltreAsync(int? enseigneId, int? familleProduitId);
        Task<Response<int>> CreateAsync(AlerteProduitDto alerteDto);
        Task<Response<bool>> UpdateAsync(AlerteProduitDto alerte);
        Task<Response<bool>> DeleteByIdAsync(int id);
        Task<Response<AlerteProduitDto>> GetByIdAsync(int id);
    }
}
