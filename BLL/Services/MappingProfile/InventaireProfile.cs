using AutoMapper;
using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using Shared.DTO.InnovTouch.DTO.Inventaire;

namespace BLL.Services.MappingProfile
{
    public class InventaireProfile :Profile
    {
        public InventaireProfile()
        {
            CreateMap<AddInfentaireDto, AddInventaire>().ReverseMap();
            CreateMap<ProduitListDTO, ProduitList>().ReverseMap();
        }
    }
}
