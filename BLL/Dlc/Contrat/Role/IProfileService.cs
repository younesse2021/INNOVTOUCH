using Shared.DTO;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.Contrat.Role
{
    public interface IProfileService
    {
        Task<Response<ProfileDto>> GetByIdAsync(int id); 
        Task<Response<List<ProfileDto>>> GetAllByEnseigneIdAsync(int id); 
    }
}
