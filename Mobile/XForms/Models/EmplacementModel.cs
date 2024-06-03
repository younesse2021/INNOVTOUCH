using System.Collections.Generic;
using Newtonsoft.Json;

namespace XForms.Models
{
    public partial class InventoryZoneModel
    {
        public string  CodeExt { get; set; }
        public string  Desc { get; set; }
        public string  Code { get; set; }
        public string Icon { get; set; }
        public string  LocationsAvailable { get; set; }
        public int  NumberEmplacement { get; set; }
    }

    public partial class LocationsAvailable
    {
        [JsonProperty("locationNumber")]
        public List<EmplacementModel> LocationNumber { get; set; }
    }

    public partial class EmplacementModel
    {
        [JsonProperty("value")]
        public SectionModel Value { get; set; }
    }
}
