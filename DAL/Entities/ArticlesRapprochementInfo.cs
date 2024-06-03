using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class ArticlesRapprochementInfo
    {
        public long Id { get; set; }
        public string CodeInterne { get; set; }
        public string Ean { get; set; }
        public string CodeWynd { get; set; }
        public string LibelleEcomm { get; set; }
        public string Statut { get; set; }
        public string AttributEnVente { get; set; }
        public string PrixDeVente { get; set; }
        public string Tva { get; set; }
        public string Niv3 { get; set; }
        public string Niv2 { get; set; }
        public string Niv1 { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
