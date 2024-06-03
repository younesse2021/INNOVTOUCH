using DAL.InnovTouch.DOMAIN.Models.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Inventaire
{
    [Table("In_Zone")]
    public class Zone
    {
        public int Id { get; set; }
        public string  codeExt { get; set; }
        public string  desc { get; set; }
        public string  code { get; set; }
        public string  locationsAvailable { get; set; }

        // public Utilisateur Utlisateur { get; set; }
        // public Inventory Inventory { get; set; }
    }
}
