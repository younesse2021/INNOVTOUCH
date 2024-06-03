using AutoMapper;
using DAL.InnovTouch.DOMAIN.Models.Entite;
using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Inventaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dlc.MappingProfile.Entite
{
    public class EmpalceementProfile :Profile
    {
        public EmpalceementProfile()
        {
            CreateMap<EmplacementDetails, Emplacement>().ReverseMap();
            CreateMap<Emplacement, EmplacementDetails>().ReverseMap();
        }
    }
}
