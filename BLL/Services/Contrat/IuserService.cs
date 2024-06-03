using DAL.InnovTouch.DOMAIN.Models.Role;
 using Shared.DTO.InnovTouch.DTO.Role;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Contrat
{
    public interface IuserService
    {
       Response<bool> AddUser(Utilisateur user);
       Response<bool> UpdateUser(Utilisateur user);
       Response<bool> DeleteUser(Utilisateur user);
       Response<List<Utilisateur>> GetAllUser();
    }
}
