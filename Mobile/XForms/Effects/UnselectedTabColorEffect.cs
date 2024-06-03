using Xamarin.Forms;

namespace XForms.Effects
{
    public class UnselectedTabColorEffect : RoutingEffect
    {
        public UnselectedTabColorEffect()
            : base($"AppEffects.{nameof(UnselectedTabColorEffect)}")
        {
        }
    }
}