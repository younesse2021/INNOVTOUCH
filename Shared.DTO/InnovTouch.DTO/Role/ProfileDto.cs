using Shared.DTO.InnovTouch.DTO.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.InnovTouch.DTO.Role
{
    public class ProfileDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;  
        public string Libelle { get; set; } = string.Empty;
        public List<DroitDto>? Droits { get; set; }
        public EnseigneDto? Enseigne { get; set; }
        public int? EnseigneId { get; set; }
        public List<UtilisateurDto>? Utilisateurs { get; set; }
    }
}
