using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class ChangementCatalogueEcom
    {
        public long Id { get; set; }
        public string CodeInterne { get; set; }
        public string Ean { get; set; }
        public string CodeWynd { get; set; }
        public string LibelleEcomm { get; set; }
        public string Lblart { get; set; }
        public string Statut { get; set; }
        public string AttributEnVente { get; set; }
        public string PrixDeVente { get; set; }
        public string AncienPrix { get; set; }
        public string Tva { get; set; }
        public string Niv3 { get; set; }
        public string Niv2 { get; set; }
        public string Niv1 { get; set; }
        public string Departement { get; set; }
        public string Rayon { get; set; }
        public string Famille { get; set; }
        public string Sfamille { get; set; }
        public string Ssfamille { get; set; }
        public string Ub { get; set; }
        public int HorsAssortiment { get; set; }
        public double? Stock1 { get; set; }
        public double? Stock2 { get; set; }
        public double? Stock4 { get; set; }
        public double? Stock5 { get; set; }
        public double? Stock6 { get; set; }
        public double? Stock7 { get; set; }
        public double? Stock8 { get; set; }
        public double? Stock9 { get; set; }
        public double? Stock10 { get; set; }
        public double? Stock12 { get; set; }
        public double? Stock13 { get; set; }
        public double? Stock14 { get; set; }
        public double? Stock15 { get; set; }
        public double? Stock17 { get; set; }
        public double? Stock25 { get; set; }
        public double? Stock39 { get; set; }
        public double? Stock118 { get; set; }
        public double? Stock155 { get; set; }
        public DateTime DateCreation { get; set; }
        public int ValidatedTrueToday { get; set; }
        public int DraftTrueToValidatedTrue { get; set; }
        public int ValidatedFalseToValidatedTrue { get; set; }
        public int ValidatedTrueToValidatedFalse { get; set; }
        public int DraftTrueToday { get; set; }
        public int DraftTrueToValidatedFalse { get; set; }
        public int ChangementPrixDeVente { get; set; }
        public string Date { get; set; }
    }
}
