using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Rupture1
    {
        public string WyndOrderHeaderReference { get; set; }
        public string Statuscode { get; set; }
        public string Entitylabel { get; set; }
        public string PreparationState { get; set; }
        public int ProductexternalId { get; set; }
        public string Label { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime UpdatedAt { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string Statut { get; set; }
        public int Rupture { get; set; }
        public int Collecté { get; set; }
        public int Substitution { get; set; }
        public int Annulation { get; set; }
        public int Commandé { get; set; }
        public double? QteStock { get; set; }
        public string Rayon { get; set; }
        public string Pareto { get; set; }
        public string Categorie { get; set; }
        public string UuidOrder { get; set; }
    }
}
