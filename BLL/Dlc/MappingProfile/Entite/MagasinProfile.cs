using AutoMapper;
using DAL.InnovTouch.DOMAIN.Models.Entite;
using Shared.DTO.InnovTouch.DTO.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.MappingProfile.Entite
{
    public class MagasinProfile:Profile
    {
        public MagasinProfile()
        {
            CreateMap<MagasinDto, Magasin>().ReverseMap();
        }
        
    }
}
