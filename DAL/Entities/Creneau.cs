using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Creneau
    {
        public int CodeSite { get; set; }
        public string Site { get; set; }
        public string Destinationcode { get; set; }
        public DateTime? DateLivPrevue { get; set; }
        public DateTime? DueDateStart { get; set; }
        public DateTime? DueDate { get; set; }
        public string Creneau1 { get; set; }
        public DateTime? DatePreparation { get; set; }
        public DateTime? DateLivraisonEffective { get; set; }
        public int PreparationRespectee { get; set; }
        public int PreparationNonRespectee { get; set; }
        public int LivraisonRespectee { get; set; }
        public string Reference { get; set; }
        public string Statut { get; set; }
    }
}
