using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class RatingLivraison
    {
        public string Date { get; set; }
        public string Commentaire { get; set; }
        public int Rating1 { get; set; }
        public int Rating2 { get; set; }
        public int Rating3 { get; set; }
        public int RatingNull { get; set; }
        public long CustomerId { get; set; }
        public string CustomerUuid { get; set; }
        public string CustomerFullname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public long OrderId { get; set; }
        public string OrderUuid { get; set; }
        public string OrderReference { get; set; }
    }
}
