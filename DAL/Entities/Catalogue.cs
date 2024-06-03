using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Catalogue
    {
        public long Code { get; set; }
        public string Gencode { get; set; }
        public string Libelle { get; set; }
        public string Dept { get; set; }
        public string Rayon { get; set; }
        public string Famille { get; set; }
        public string Sfamille { get; set; }
        public string Ssfamille { get; set; }
        public string Ub { get; set; }
        public bool FlagWynd { get; set; }
        public string Site { get; set; }
        public DateTime DateStock { get; set; }
        public double Qte { get; set; }
        public double Seuil { get; set; }
        public DateTime? DerniereVente { get; set; }
        public double? QteVendu { get; set; }
        public DateTime? DerniereReception { get; set; }
        public double? QteRecu { get; set; }
        public DateTime? DerniereCommande { get; set; }
        public string Categorie { get; set; }
        public string DisponibiltéAppli { get; set; }
    }
}
