using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class MissionDetail
    {
        public long Id { get; set; }
        public long CodeArticle { get; set; }
        public long MissionHeaderId { get; set; }
        public double? Poids { get; set; }
        public DateTime? DateScanPoids { get; set; }

        public virtual MissionHeader MissionHeader { get; set; }
    }
}
