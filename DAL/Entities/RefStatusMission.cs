using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class RefStatusMission
    {
        public RefStatusMission()
        {
            MissionHeader = new HashSet<MissionHeader>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MissionHeader> MissionHeader { get; set; }
    }
}
