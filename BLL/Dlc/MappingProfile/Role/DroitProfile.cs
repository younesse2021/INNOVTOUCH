using AutoMapper;
using DAL.InnovTouch.DOMAIN.Models.Role;
using Shared.DTO.InnovTouch.DTO.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.MappingProfile.Role
{
    public class DroitProfile: AutoMapper.Profile
    {
        public DroitProfile()
        {
            CreateMap<Droit, DroitDto>().ReverseMap();
        }
    }
}
