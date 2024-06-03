using Xamarin.Forms;

namespace XForms.Views.SharedViews
{
    public partial class SuggestionsNavBarView : BaseContent
    {

        public static readonly BindableProperty HasTitleProperty = BindableProperty.Create(nameof(HasTitle), typeof(bool), typeof(SuggestionsNavBarView), false);
        public bool HasTitle
        {
            get
            {
                return (bool)GetValue(HasTitleProperty);
            }
            set
            {
                SetValue(HasTitleProperty, value);
            }
        }

        public static readonly BindableProperty HasStorePickerProperty = BindableProperty.Create(nameof(HasStorePicker), typeof(bool), typeof(SuggestionsNavBarView), false);
        public bool HasStorePicker
        {
            get
            {
                return (bool)GetValue(HasStorePickerProperty);
            }
            set
            {
                SetValue(HasStorePickerProperty, value);
            }
        }


       

        public static readonly BindableProperty HasReturnActionProperty = BindableProperty.Create(nameof(HasReturnAction), typeof(bool), typeof(SuggestionsNavBarView), false);
        public bool HasReturnAction
        {
            get
            {
                return (bool)GetValue(HasReturnActionProperty);
            }
            set
            {
                SetValue(HasReturnActionProperty, value);
            }
        }


        public static readonly BindableProperty HasLogoutActionProperty = BindableProperty.Create(nameof(HasLogoutAction), typeof(bool), typeof(SuggestionsNavBarView), false);
        public bool HasLogoutAction
        {
            get
            {
                return (bool)GetValue(HasLogoutActionProperty);
            }
            set
            {
                SetValue(HasLogoutActionProperty, value);
            }
        }

        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string), typeof(SuggestionsNavBarView));
        public string TitleText
        {
            get
            {
                return (string)GetValue(TitleTextProperty);
            }
            set
            {
                SetValue(TitleTextProperty, value);
            }
        }

        public SuggestionsNavBarView()
        {
            InitializeComponent();


            //OnPropertyChanged(nameof(WhishlistCountText));

        }

       
    }
}