using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;
using FluentValidation;
using Xamarin.Forms;
using XForms.Interfaces;
using XForms.Models;

namespace XForms.ViewModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class WalkthroughViewModel : BaseViewModel
    {
        public List<WalkthroughModel> WalkthroughList { get; set; }
        public int WalkthroughPosition { get; set; }
        // public ImageSource WalkthroughImageSource => ImageSource.FromResource(WalkthroughList[WalkthroughPosition].Image, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
        public WalkthroughViewModel(INavigation navigation, ILogger logger = null, IValidator validator = null)
        : base(navigation, logger, validator)
        {
            WalkthroughList = new List<WalkthroughModel>()
            {
                new WalkthroughModel()
                {
                    Title = "Bienvenue à Marjane  app!",
                    Description  = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                    Image = ImageSource.FromResource("Walkthrough_1.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly)
                },
                new WalkthroughModel()
                {
                    Title = "Bienvenue à Marjane   app!",
                    Description  = "Quisque scelerisque dignissim molestie",
                    Image = ImageSource.FromResource("Walkthrough_2.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly)

                },
                new WalkthroughModel()
                {
                    Title = "Bienvenue à Marjane   app!",
                    Description  = "Phasellus malesuada, lectus vitae pellentesque imperdiet",
                    Image = ImageSource.FromResource("Walkthrough_3.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly),
                    IsLastStep = true
                }
            };
        }

        public async override void OnAppearing()
        {
            base.OnAppearing();
        }

        #region Commands
        public bool CanCommence { get; set; } = true;
        public ICommand CommenceCommand => new Command(() =>
        {
           try
           {
               CanCommence = false;

                Settings.ClearSettings();
                
               AppHelpers.SetInitialView();
            }
           catch (Exception ex)
           {
               Logger.LogError(ex);
           }
           finally
           {
               CanCommence = true;
           }
       }, () => CanCommence);
        #endregion
    }
}