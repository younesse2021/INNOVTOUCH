using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class BalanceOrders
    {
        public string Uuid { get; set; }
        public double? CbAmount { get; set; }
        public double? FidelityAmount { get; set; }
        public int? ActionType { get; set; }
        public string TransactionId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerUuid { get; set; }
        public int? ReceiverId { get; set; }
        public string ReceiverUuid { get; set; }
    }
}
