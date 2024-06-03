//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Support.Design.Widget;
//using Android.Views;
//using Android.Widget;
//using Google.Android.Material.Tabs;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android.AppCompat;
//using XForms.Controls;
//using XForms.Droid.Renderers;
//using View = Android.Views.View;


//[assembly: ExportRenderer(typeof(CustomBottomNavTabPage), typeof(CustomBottomNavTabPageRenderer))]

//namespace XForms.Droid.Renderers
//{
//    public class CustomBottomNavTabPageRenderer : TabbedPageRenderer
//    {
//        private bool _isShiftModeSet;

//        public CustomBottomNavTabPageRenderer(Context context)
//            : base(context)
//        {

//        }

//        CustomBottomNavTabPage element = null;


//        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
//        {
//            base.OnElementPropertyChanged(sender, e);

//            if (this.Element == null) return;

//            element = (CustomBottomNavTabPage)Element;

//            if (e.PropertyName == CustomBottomNavTabPage.IsHiddenroperty.PropertyName)
//            {
//                TabLayout TabsLayout = null;

//                for (int i = 0; i < ChildCount; ++i)
//                {
//                    Android.Views.View view = (Android.Views.View)GetChildAt(i);
//                    if (view is TabLayout)
//                        TabsLayout = (TabLayout)view;
//                }
//                if (element.IsHidden)
//                {
//                    TabsLayout.Visibility = ViewStates.Invisible;
//                }
//                else
//                {
//                    TabsLayout.Visibility = ViewStates.Visible;
//                }
//            }
//        }

//        //protected override void OnLayout(bool changed, int l, int t, int r, int b)
//        //{
//        //    base.OnLayout(changed, l, t, r, b);
//        //    try
//        //    {
//        //        if (!_isShiftModeSet)
//        //        {
//        //            var children = GetAllChildViews(ViewGroup);

//        //            if (children.SingleOrDefault(x => x is CustomBottomNavigationView) is CustomBottomNavigationView bottomNav)
//        //            {
//        //                bottomNav.Visi(false, false);
//        //                _isShiftModeSet = true;
//        //            }
//        //        }
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        Console.WriteLine($"Error setting ShiftMode: {e}");
//        //    }
//        //}

//        //private List<View> GetAllChildViews(View view)
//        //{
//        //    if (!(view is ViewGroup group))
//        //    {
//        //        return new List<View> { view };
//        //    }

//        //    var result = new List<View>();

//        //    for (int i = 0; i < group.ChildCount; i++)
//        //    {
//        //        var child = group.GetChildAt(i);

//        //        var childList = new List<View> { child };
//        //        childList.AddRange(GetAllChildViews(child));

//        //        result.AddRange(childList);
//        //    }

//        //    return result.Distinct().ToList();
//        //}
//        //}
//    }
//}