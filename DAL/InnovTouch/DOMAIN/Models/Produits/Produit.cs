
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Produits
{
    [Table("Pr_Produits")]
    public class Produit
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public string CodeDepartement { get; set; }
        public string CodeRayon { get; set; }
        public string? CodeFamille { get; set; }
        public string CodeSousFamille { get; set; }
        public string CodeSousSousFamille { get; set; }
        public double Prix { get; set; }
        public DateTime DateMaj { get; set; }
        public FamilleProduit? FamilleProduit { get; set; }
        public Nullable<int> FamilleProduitId { get; set; }
        public List<InnovTouchProduit>? InnovTouchProduits { get; set; }
    }
}
