using DAL.InnovTouch.DOMAIN.Models.Entite;
 using Shared.DTO.InnovTouch.DTO.Entite;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.InnovTouch.DOMAIN.Models.Inventaire
{
    [Table("In_Inventory")]
    public class Inventory
    {
        public int Id { get; set; }
        public string number { get; set; }
        public string description { get; set; }
        public string stockPosition { get; set; }
        public string valorisationDate { get; set; } = "";
        public Magasin Magasin { get; set; }
        public Rayone Rayone { get; set; }
        public ReserveMagasin Type { get; set; }

        [NotMapped]
        public int typeInventaire { get; set; }
        public int NumberEmplacement { get; set; } = 0;
    }
}
