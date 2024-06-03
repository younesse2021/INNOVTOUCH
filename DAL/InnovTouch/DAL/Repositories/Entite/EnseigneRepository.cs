using DAL.InnovTouch.DOMAIN.IRepositories.Entite;
using DAL.InnovTouch.DOMAIN.Models.Entite;
using Ma.Marjane.RPC.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DAL.Repositories.Entite
{
    public class EnseigneRepository : RepositoryBase<Enseigne>, IEnseigneRepository
    {
        public EnseigneRepository(InnovTouchDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
