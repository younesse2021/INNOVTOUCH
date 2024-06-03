using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class WyndRatingClient
    {
        public long Id { get; set; }
        public DateTime RatingDate { get; set; }
        public int Type { get; set; }
        public bool Resolved { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public long CustomerId { get; set; }
        public string CustomerUuid { get; set; }
        public string CustomerFullname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
    }
}
