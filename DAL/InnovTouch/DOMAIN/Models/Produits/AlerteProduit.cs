using DAL.InnovTouch.DOMAIN.Models.Entite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Produits
{
    [Table("Pr_AlerteProduit")]
    public class AlerteProduit
    {
        public int Id { get; set; }
        public Enseigne? Enseigne { get; set; }
        public int EnseigneId { get; set; }
        public FamilleProduit? FamilleProduit { get; set; }
        public int FamilleProduitId { get; set; }
        public int NbrJour { get; set; }
    }
}
