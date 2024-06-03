using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class SiteCorrespondance
    {
        public SiteCorrespondance()
        {
            MissionHeader = new HashSet<MissionHeader>();
            SiteLex = new HashSet<SiteLex>();
            SitePolygon = new HashSet<SitePolygon>();
            SitePolygonLex = new HashSet<SitePolygonLex>();
            StocksWyndInfo = new HashSet<StocksWyndInfo>();
        }

        public bool? IsTest { get; set; }
        public string DelaiLivraison { get; set; }
        public int SiteCodeWynd { get; set; }
        public int SiteCode { get; set; }
        public string Libsite { get; set; }
        public string IpCaisse { get; set; }
        public string TypeCaisse { get; set; }
        public DateTime DateMaj { get; set; }
        public bool? IsActif { get; set; }
        public bool? Isclickandcollect { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public int? MaxCapacity { get; set; }
        public int? Rayon { get; set; }
        public string UrlMarkerIcon { get; set; }
        public string PolygonColor { get; set; }

        public virtual ICollection<MissionHeader> MissionHeader { get; set; }
        public virtual ICollection<SiteLex> SiteLex { get; set; }
        public virtual ICollection<SitePolygon> SitePolygon { get; set; }
        public virtual ICollection<SitePolygonLex> SitePolygonLex { get; set; }
        public virtual ICollection<StocksWyndInfo> StocksWyndInfo { get; set; }
    }
}
