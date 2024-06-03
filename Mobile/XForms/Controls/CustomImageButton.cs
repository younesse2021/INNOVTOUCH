using System;
using Xamarin.Forms;
using XForms.Enums;

namespace XForms.Controls
{
    public class CustomImageButton : ImageButton
    {
        public ControlStyleCorner StyleCorner { get; set; } = ControlStyleCorner.RoundCorner;

        public CustomImageButton()
        {
            this.SizeChanged += (object sender, EventArgs e) =>
            {
                switch (StyleCorner)
                {
                    case ControlStyleCorner.Circle:
                        this.WidthRequest = this.Height;
                        this.CornerRadius = (int)this.Height / 2;
                        break;
                    case ControlStyleCorner.RoundCorner:
                        this.CornerRadius = (int)this.Height / 2;
                        break;
                }
            };
        }
    }
}