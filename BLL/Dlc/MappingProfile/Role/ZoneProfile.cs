﻿using AutoMapper;
using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using Shared.DTO.InnovTouch.DTO.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dlc.MappingProfile.Role
{
    public class ZoneProfile : Profile
    {
        public ZoneProfile()
        {
            CreateMap<ZoneDto, Zone>().ReverseMap();
        }
    }
}
