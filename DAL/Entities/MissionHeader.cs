using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class MissionHeader
    {
        public MissionHeader()
        {
            MissionDetail = new HashSet<MissionDetail>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int SiteCodeWynd { get; set; }
        public long StatutId { get; set; }
        public string ReservedByUuid { get; set; }
        public int? ReservedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string ReservedByFullName { get; set; }

        public virtual SiteCorrespondance SiteCodeWyndNavigation { get; set; }
        public virtual RefStatusMission Statut { get; set; }
        public virtual ICollection<MissionDetail> MissionDetail { get; set; }
    }
}
