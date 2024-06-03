using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Produits
{
    [Table("Pr_FamilleProduit")]
    public class FamilleProduit
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public List<Produit>? Produits { get; set; }
        public List<AlerteProduit>? AlerteProduits { get; set; }
    }
}
