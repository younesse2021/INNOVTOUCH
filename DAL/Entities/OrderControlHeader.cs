using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class OrderControlHeader
    {
        public OrderControlHeader()
        {
            OrderControlDetail = new HashSet<OrderControlDetail>();
            OrderControlSecurity = new HashSet<OrderControlSecurity>();
        }

        public string Uuid { get; set; }
        public long Id { get; set; }
        public string Reference { get; set; }
        public string PrepBillUuid { get; set; }
        public int? PrepBillId { get; set; }
        public string PrepBillReference { get; set; }
        public int SiteCode { get; set; }
        public string PickerUsername { get; set; }
        public string ClientUsername { get; set; }
        public string OrderNumber { get; set; }
        public DateTime DateCreationOrder { get; set; }
        public DateTime DateCreation { get; set; }
        public string CreatedByUsername { get; set; }
        public string ControlledByUsername { get; set; }
        public bool IsControlled { get; set; }
        public DateTime? DateControl { get; set; }
        public int Status { get; set; }

        public virtual ICollection<OrderControlDetail> OrderControlDetail { get; set; }
        public virtual ICollection<OrderControlSecurity> OrderControlSecurity { get; set; }
    }
}
