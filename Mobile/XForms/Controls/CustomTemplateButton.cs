using System;
using Xamarin.Forms;

namespace XForms.Controls
{
    public class CustomTemplateButton : ContentView
    {
        public event EventHandler Clicked;

        public CustomTemplateButton()
        {
            TapGestureRecognizer gestureRecognizer = new TapGestureRecognizer();

            gestureRecognizer.Tapped += async (object sender, EventArgs e) =>
            {
                var view = sender as CustomTemplateButton;

                await AppHelpers.EffectClick(view);
                Clicked?.Invoke(sender, e);
            };

            this.GestureRecognizers.Add(gestureRecognizer);
        }
    }
}
