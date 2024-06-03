using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.IRepositories
{
    public interface IUnitOfWorkOracle
    {
        Task<DataTable?> GetDataAsync(string req, Dictionary<string, Object> parameters);
    }
}
