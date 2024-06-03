using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class OrderControlDetail
    {
        public OrderControlDetail()
        {
            OrderControlProductEan = new HashSet<OrderControlProductEan>();
        }

        public string Uuid { get; set; }
        public long? Id { get; set; }
        public string HeaderUuid { get; set; }
        public long HeaderId { get; set; }
        public string HeaderReference { get; set; }
        public string ProductUuid { get; set; }
        public long ProductId { get; set; }
        public int ProductStatus { get; set; }
        public double ProductQuantity { get; set; }
        public string OriginalProductUuid { get; set; }
        public long? OriginalProductdId { get; set; }
        public string OriginalProductLabel { get; set; }
        public int? OriginalProductExternalId { get; set; }
        public bool IsControlled { get; set; }
        public DateTime? DateControl { get; set; }
        public bool? IsClientSatisfied { get; set; }

        public virtual OrderControlHeader HeaderUu { get; set; }
        public virtual ICollection<OrderControlProductEan> OrderControlProductEan { get; set; }
    }
}
