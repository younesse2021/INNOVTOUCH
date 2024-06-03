using AutoMapper;
using DAL.InnovTouch.DOMAIN.Models.Entite;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Produit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.MappingProfile.Entite
{
    public class EnseigneProfile : Profile
    {
        public EnseigneProfile()
        {
            CreateMap<EnseigneDto, Enseigne>().ReverseMap();
        }
    }
}
