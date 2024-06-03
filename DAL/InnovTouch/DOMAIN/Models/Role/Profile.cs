using DAL.InnovTouch.DOMAIN.Models.Entite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Role
{
    [Table("Ro_Profile")]
    public class Profile
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public List<DroitProfile> DroitsProfiles { get; set; }
        public Enseigne Enseignes { get; set; }
        public int EnseignesId { get; set; }
        public List<Utilisateur> Utilisateurs { get; set; }
    }
}
