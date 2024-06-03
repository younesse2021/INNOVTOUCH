using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Inventaire
{
    [Table("Ra_Rayone")]
    public  class Rayone
    {
        public int Id { get; set; }
        public int IdRayone { get; set; }
        public string  Name { get; set; }
    }
}
