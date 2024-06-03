using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using GraphQL;
using Xamarin.Forms;
using XForms.Interfaces;
using XForms.Models;

namespace XForms.ViewModels.Store
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class StoreViewModel : BaseViewModel
    {
        public bool IsStoresLoading { get; set; }

        public RefItemModel CitySelectedItem { get; set; }

        public List<StoreModel> StoresList { get; set; }
        public IEnumerable<StoreModel> StoresListData { get; set; }
        public List<RefItemModel> CitiesList { get; set; }

        public StoreViewModel(INavigation navigation, ILogger logger = null, IValidator validator = null)
      : base(navigation, logger, validator)
        {
            CanRefresh = true;

            PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName == nameof(CitySelectedItem))
                {
                    Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await GetSuggestionsData(SuggestionsSearchText);
                    });
                }
            };
            CitySelectedItem
        }

        public async override void OnAppearing()
        {
            base.OnAppearing();

            if (StoresList == null)
            {
                await GetStoresData();
            }
        }

        #region Data Fonctions

        #region Store
        public async Task GetStoresData()
        {
            try
            {
                IsStoresLoading = true;

                var postRequest = new GraphQLRequest
                {
                    Query = "{ fulfillmentCenters { ffmcenter_id name city city_id image phone_number address description opening_hours latitude longitude }}",
                };

                var result = await App.AppServices.GetStores(postRequest);

                if (result != null)
                {
                    StoresListData = result.FulfillmentCenters;
                    StoresList = StoresListData.ToList();

                    CitiesList = new List<RefItemModel>()
                    {
                        new RefItemModel() }
                    {
                        
                    }
                };

                CitiesList = StoresListData.Select(x => new RefItemModel()
                {
                    Id = x.CityId,
                    Name = x.City
                }).Distinct().ToList();
            }
                else
            {
                //AppHelpers.Alert(result);
            }
        }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                IsStoresLoading = false;
            }
        }

        //public async Task GetRegionsData()
        //{
        //    try
        //    {
        //        var postRequest = new GraphQLRequest
        //        {
        //            Query = @"{country(id: ""MA"") { available_regions { id code name available_cities { id name postcode } } }}",
        //        };

        //        var result = await App.AppServices.GetRegions(postRequest);

        //        if (result != null)
        //        {
        //            CitiesList = result.Country.AvailableRegions.ToList();
        //        }
        //        else
        //        {
        //            //AppHelpers.Alert(result);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //    }
        //}
        #endregion

        #endregion

        #region Commands

        //private bool CanSelectCategory = true;
        //public ICommand SelectCategoryCommand => new Command<long>((order) =>
        //{
        //    try
        //    {
        //        CanSelectCategory = false;

        //        SelectedCategory = order;

        //        foreach (var item in CategoriesList)
        //        {
        //            item.IsSelected = item.Id == SelectedCategory;
        //        }

        //        var subCategoriesList = new List<SubCategoryGroupModel>();

        //        var SelectedCategorySub = CategoriesListData
        //            .FirstOrDefault(x => x.Id == SelectedCategory)
        //            .Children;

        //        if (SelectedCategorySub?.Any() == true)
        //        {
        //            foreach (var item in SelectedCategorySub)
        //            {
        //                subCategoriesList.Add(new SubCategoryGroupModel(item.Name, SelectedCategorySub));
        //            }
        //        }

        //        SubCategoriesList = subCategoriesList;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //    }
        //    finally
        //    {
        //        CanSelectCategory = true;
        //    }
        //}, (_) => CanChangeSubView);
        #endregion
    }
}