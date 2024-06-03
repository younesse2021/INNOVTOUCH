using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using DAL.InnovTouch.DOMAIN.Models.Role;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dlc.MappingProfile.Role
{
    public class InventoryProfile : AutoMapper.Profile
    {
        public InventoryProfile()
        {
            CreateMap<InventoryDTO, Inventory>().ReverseMap();
        }
    }
}
