using DAL.InnovTouch.DOMAIN.IRepositories.Role;
using DAL.InnovTouch.DOMAIN.Models.Role;
using Ma.Marjane.RPC.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DAL.Repositories.Role
{
    public class DroitRepository : RepositoryBase<Droit>, IDroitRepository
    {
        public DroitRepository(InnovTouchDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
