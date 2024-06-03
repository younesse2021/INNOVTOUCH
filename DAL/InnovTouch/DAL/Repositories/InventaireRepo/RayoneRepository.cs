using DAL.InnovTouch.DAL.Repositories.Inventaire;
using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using Ma.Marjane.RPC.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DAL.Repositories.InventaireRepo
{
    public class RayoneRepository : RepositoryBase<Rayone>, IRayoneRepository
    {
        public RayoneRepository(InnovTouchDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
