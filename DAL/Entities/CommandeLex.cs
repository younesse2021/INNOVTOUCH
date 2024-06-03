using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class CommandeLex
    {
        public int CodeSite { get; set; }
        public string Magasin { get; set; }
        public string Site { get; set; }
        public string Destinationcode { get; set; }
        public string Reference { get; set; }
        public string Statut { get; set; }
    }
}
