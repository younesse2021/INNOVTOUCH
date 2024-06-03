
using Shared.DTO.InnovTouch.DTO.Bo;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Role;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.InnovTouch.Contrat.Role
{
    public interface IUtilisateurService
    {
        Task<Response<UtilisateurDto>> GetBy(string userName, string password);
        Task<Response<UtilisateurDto>> GetByLogin(string login);
        Task<Response<int>> CreateAsync(UtilisateurDto utilisateurDto);
        Task<Response<bool>> UpdateAsync(UtilisateurDto utilisateurDto);
        Task<Response<bool>> DeleteByIdAsync(int id);
        Task<Response<UtilisateurDto>> GetByIdAsync(int id);
        Task<Response<List<UtilisateurDto>>> AllAsync();
        Task<Response<UtilisateurBoDto>> ConnectAsync(string userName, string password);
    }
}
