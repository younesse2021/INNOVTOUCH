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
    public class AddinventaireRepository : RepositoryBase<AddInventaire>, IAddInventaireRepository
    {
        public AddinventaireRepository(InnovTouchDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
