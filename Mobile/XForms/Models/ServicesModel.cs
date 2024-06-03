using System;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;
using XForms.Enums;

namespace XForms.Models
{
    public class ServiceModel
    {
        public AppServices AppService { get; set; }
         
        public string Title { get; set; }
        public SvgImageSource IconSource { get; set; }

        public string  IconNonRead { get; set; }
    }
}
