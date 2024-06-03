using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;
using XForms.Enums;

namespace XForms.Models
{
    public partial class SectionModel
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }
    }
}

    

    public partial class REFItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public partial class REFItem
    {
        public string Icon { get; set; }
        public string FontFamily { get; set; } = XForms.Resources.MaterialIconsFonts.FontFamily;

        public bool IsSelected { get; set; }

        public Color BackgroundColor => IsSelected ? Color.FromHex("#F2F7FF") : Color.White;
    }

