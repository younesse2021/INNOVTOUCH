using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class SiteAdresse
    {
        public int SiteCode { get; set; }
        public string CodeAdresse { get; set; }
        public int Ordre { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateMaj { get; set; }
    }
}
