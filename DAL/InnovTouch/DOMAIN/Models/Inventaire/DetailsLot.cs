using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Inventaire
{
    [Table("Dt_DetailsLot")]
    public class DetailsLot
    {
        public int Id { get; set; }
        public int IdInventaire { get; set; }
        public int IdRayone { get; set; }
        public int Type { get; set; }
        public int NumberLot { get; set; }
        public string  Libbele { get; set; }
        public string  CodeIn { get; set; }
        public string  CodeOut { get; set; }
        public bool  IsScanned { get; set; }

        [NotMapped]
        public string  NomInventaire { get; set; }

        [NotMapped]
        public string Nomrayone { get; set; }
        [NotMapped]
        public string StatusLOt { get; set; }
    }
}
