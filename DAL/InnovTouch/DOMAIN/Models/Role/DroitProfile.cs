using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Role
{
    public class DroitProfile
    {
        public Droit Droit { get; set; }
        public int DroitId { get; set; }
        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
        
    }
}
