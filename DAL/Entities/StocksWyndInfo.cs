using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class StocksWyndInfo
    {
        public long Id { get; set; }
        public long? StockTypeId { get; set; }
        public string StockTypeName { get; set; }
        public long? WarehouseId { get; set; }
        public string WarehouseUuid { get; set; }
        public string WarehouseLabel { get; set; }
        public long? ProductId { get; set; }
        public string ProductUuid { get; set; }
        public string ProductDefaultLabel { get; set; }
        public double? Quantity { get; set; }
        public string Unit { get; set; }
        public int? SiteCodeWynd { get; set; }

        public virtual SiteCorrespondance SiteCodeWyndNavigation { get; set; }
    }
}
