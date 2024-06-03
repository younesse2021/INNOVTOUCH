using System;
using Xamarin.Forms.Xaml;

namespace XForms
{
    public class SystemTypeExtension : IMarkupExtension
    {
        private object parameter;
        public int Int { set { parameter = value; } }
        public double Double { set { parameter = value; } }
        public float Float { set { parameter = value; } }
        public bool Bool { set { parameter = value; } }
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return parameter;
        }
    }
    
    //Xaml: CommandParameter="{local:SystemType Bool=True}"
}
