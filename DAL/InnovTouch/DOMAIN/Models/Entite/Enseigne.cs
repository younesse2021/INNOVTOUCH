using DAL.InnovTouch.DOMAIN.Models.Produits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Entite
{
    [Table("En_Enseigne")]
    public class Enseigne
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public bool IsValidationRemiseEnabled { get; set; }
        public bool IsValidationRetraitEnabled { get; set; }
        public List<Magasin>? Magasins { get; set; }
        public List<AlerteProduit>? AlerteProduits { get; set; }

    }
}
