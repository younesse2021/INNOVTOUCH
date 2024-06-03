using Shared.DTO.InnovTouch.DTO.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.Contrat.Oracle
{
    public interface IService
    {
        public Task<Response<string[]>> GetDepartementsByLoginAsync(string login);
    }
}
