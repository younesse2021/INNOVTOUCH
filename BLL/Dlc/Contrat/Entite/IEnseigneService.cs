using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.Contrat.Entite
{
    public interface IEnseigneService
    {
        Task<Response<List<EnseigneDto>>> AllAsync();
    }
}
