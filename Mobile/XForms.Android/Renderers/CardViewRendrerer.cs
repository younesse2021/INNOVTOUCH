//using Android.Content;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;
//using XForms.Controls;
//using XForms.Droid.Renderers;

//[assembly: ExportRenderer(typeof(CardView), typeof(CardViewRendrerer))]
//namespace XForms.Droid.Renderers
//{
//    public class CardViewRendrerer : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
//    {
//        public CardViewRendrerer(Context context) : base(context)
//        {
//        }

//        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
//        {
//            base.OnElementChanged(e);


//            if (e.NewElement == null) return;

//            var element = (CardView)Element;

//            //int[] colors = { Element.BackgroundColor.ToAndroid(), Element.BackgroundColor.ToAndroid() };
//            //var gradientDrawable = new GradientDrawable(GradientDrawable.Orientation.LeftRight, colors);
//            //gradientDrawable.SetCornerRadius(Element.CornerRadius * 2); // CornerRadius = HeightRequest in my case

//            //this.SetBackground(gradientDrawable);

//            this.Elevation = element.Elevation;

//        }
//    }
//}