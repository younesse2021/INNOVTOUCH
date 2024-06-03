using Xamarin.Forms;

namespace XForms.Effects
{
    public class HideTabLabelsEffect : RoutingEffect
    {
        public HideTabLabelsEffect()
            : base($"AppEffects.{nameof(HideTabLabelsEffect)}")
        {
        }
    }
}