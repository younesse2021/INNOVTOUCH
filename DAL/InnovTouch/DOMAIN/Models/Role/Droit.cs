using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Role
{
    [Table("Ro_Droit")]
    public class Droit
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public List<DroitProfile> DroitsProfiles { get; set; }
    }
}
