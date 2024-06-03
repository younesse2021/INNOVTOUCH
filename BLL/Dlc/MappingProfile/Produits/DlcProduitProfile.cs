using AutoMapper;
using DAL.InnovTouch.DOMAIN.Models.Produits;
using Shared.DTO.InnovTouch.DTO.Produit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.MappingProfile.Produits
{
    public class InnovTouchProduitProfile:Profile
    {
        public InnovTouchProduitProfile()
        {
            CreateMap<InnovTouchProduitDto, InnovTouchProduit>().ReverseMap();
        }
    }
}
