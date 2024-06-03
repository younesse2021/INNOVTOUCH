using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;
using FFImageLoading.Svg.Forms;
using FFImageLoading.Forms;

namespace XForms
{
    // You exclude the 'Extension' suffix when using in Xaml markup
    [Preserve(AllMembers = true)]
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            if (Source.EndsWith(".svg"))
            {
                return SvgImageSource.FromResource("XForms.Resources.Images." + Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
            }
         
            // Do your translation lookup here, using whatever method you require
            return ImageSource.FromResource("XForms.Resources.Images." + Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
        }
    }
}