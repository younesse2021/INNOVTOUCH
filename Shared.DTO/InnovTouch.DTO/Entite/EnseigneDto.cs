using Shared.DTO.InnovTouch.DTO.Produit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.InnovTouch.DTO.Entite
{
    public class EnseigneDto
    {
        public int Id { get; set; }
        public string Code { get; set; }  = string.Empty;
        public string Libelle { get; set; } = string.Empty;
        public bool IsValidationRemiseEnabled { get; set; }
        public bool IsValidationRetraitEnabled { get; set; }
        public List<MagasinDto>? Magasins { get; set; }
        public List<AlerteProduitDto>? AlerteProduits { get; set; }
    }
}
