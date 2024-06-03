using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Assossiation
    {
        public string CreatedAt { get; set; }
        public string Uuid { get; set; }
        public double? CbAmount { get; set; }
        public double? FidelityAmount { get; set; }
        public int? ActionType { get; set; }
        public string TransactionId { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerUuid { get; set; }
        public int StatutDon { get; set; }
    }
}
