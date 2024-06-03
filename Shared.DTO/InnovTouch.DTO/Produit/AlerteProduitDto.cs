using Shared.DTO.InnovTouch.DTO.Entite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO.InnovTouch.DTO.Produit
{
    public class AlerteProduitDto
    {
        public int Id { get; set; }
        public EnseigneDto? Enseigne { get; set; }
        public int EnseigneId { get; set; }
        public FamilleProduitDto? FamilleProduit { get; set; }
        public int? FamilleProduitId { get; set; }
        public ProduitDto? Produit { get; set; }
        public int? ProduitId { get; set; }
        public string? CodeEnseigne { get; set; }
        public string? CodeMagasin { get; set; }
        public string? CodeDepartement { get; set; }
        public string? CodeRayon { get; set; }
        public string? CodeProduit { get; set; }

        public int NbrJour { get; set; }
        public int NbrJourRetrait { get; set; }

        public override string ToString()
        {
            return $"{{ {nameof(EnseigneId)}={EnseigneId.ToString()}, {nameof(FamilleProduitId)}={FamilleProduitId.ToString()}, {nameof(NbrJour)}={NbrJour.ToString()}}}";
        }
    }
}
