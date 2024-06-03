using DAL.InnovTouch.DOMAIN.Models.Entite;
using DAL.InnovTouch.DOMAIN.Models.Produits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Role
{
    [Table("Ro_Utilisateur")]
    public class Utilisateur : BaseModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public List<InnovTouchProduit>? InnovTouchProduits { get; set; }
        public List<InnovTouchProduit>? InnovTouchProduitsRemise { get; set; }
        public List<InnovTouchProduit>? InnovTouchProduitsRetrait { get; set; }
        public List<InnovTouchProduit>? InnovTouchProduitsValideRemise { get; set; }
        public List<InnovTouchProduit>? InnovTouchProduitsValideRetrait { get; set; }
        public Magasin? Magasin{ get; set; }
        public int? MagasinId { get; set; }
        public bool isAdmin { get; set; }
    }
}
