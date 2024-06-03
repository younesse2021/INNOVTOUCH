
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.InnovTouch.DTO.Entite
{
    public class FournisseurDto
    {
        public int Id { get; set; }
        public string Cnuf { get; set; } = string.Empty;
        public string RaisonSocial { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public int? Ice { get; set; }
        public string Rc { get; set; } = string.Empty;
        public int? Patente { get; set; }
        public int? If { get; set; }
        public int? Cnss { get; set; }
        public string Observation { get; set; } = string.Empty;
    }
}
