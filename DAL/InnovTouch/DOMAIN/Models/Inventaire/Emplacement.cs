using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Inventaire;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Inventaire
{
    [Table("Em_Emplacement")]
    public class Emplacement
    {
        public int Id { get; set; }
        public Inventory Inventory { get; set; }
        public Rayone Rayone { get; set; }
        public int TypeInventaire { get; set; }
        public int NumberEmplacement { get; set; }
    }
}
