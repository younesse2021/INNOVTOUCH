using DAL.InnovTouch.DOMAIN.IRepositories.Role;
using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using DAL.InnovTouch.DOMAIN.Models.Role;
using Ma.Marjane.RPC.DAL.Repositories;
using Shared.DTO.InnovTouch.DTO.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DAL.Repositories.Role
{
    public class ZoneRepository : RepositoryBase<Zone>, IZoneRepository
    {
        public ZoneRepository(InnovTouchDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
