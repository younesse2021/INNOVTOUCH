using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.InnovTouch.DTO.Produit
{
    public class ProduitDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Libelle { get; set; } = string.Empty;
        public string CodeDepartement { get; set; } = string.Empty;
        public string? CodeRayon { get; set; }
        public string? CodeFamille { get; set; }
        public string? CodeSousFamille { get; set; }
        public string? CodeSousSousFamille { get; set; }
        public double? Prix { get; set; }
        public DateTime? DateMaj { get; set; }
        public FamilleProduitDto? FamilleProduit { get; set; }
        public int? FamilleProduitId { get; set; }
        public List<InnovTouchProduitDto>? InnovTouchProduits { get; set; }
    }
}
