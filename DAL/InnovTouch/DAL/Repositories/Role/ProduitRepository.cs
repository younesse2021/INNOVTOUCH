using DAL.InnovTouch.DOMAIN.IRepositories.Produits;
using DAL.InnovTouch.DOMAIN.IRepositories.Role;
using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using Ma.Marjane.RPC.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DAL.Repositories.Role
{
    public class ProduitRepository : RepositoryBase<ProduitInfo>, IProduitRepository
    {
        public ProduitRepository(InnovTouchDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
