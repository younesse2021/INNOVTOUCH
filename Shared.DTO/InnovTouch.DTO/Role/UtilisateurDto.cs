
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Produit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.InnovTouch.DTO.Role
{
    public class UtilisateurDto
    {
        public int Id { get; set; }
        public string? Login { get; set; } 
        public string? Nom { get; set; }  
        public string? Prenom { get; set; }  
        public string? Password { get; set; }  
        public string? Email { get; set; }
        public List<InnovTouchProduitDto>? InnovTouchProduits { get; set; }
        public ProfileDto? Profile { get; set; }
        public int? ProfileId { get; set; }
        public MagasinDto? Magasin { get; set; }
        public int? MagasinId { get; set; }
        public bool IsHaveAccessToApp { get; set; } = true;
        public bool isAdmin { get; set; }
    }
}
