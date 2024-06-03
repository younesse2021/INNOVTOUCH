using System;
using System.Collections.Generic;
using System.Text;

namespace XForms.Models
{
    public class DetailLot
    {
        public int Id { get; set; }
        public int IdInventaire { get; set; }
        public int IdRayone { get; set; }
        public int Type { get; set; }
        public int NumberLot { get; set; }
        public string Libbele { get; set; }
        public string CodeIn { get; set; }
        public string CodeOut { get; set; }
    }
}
