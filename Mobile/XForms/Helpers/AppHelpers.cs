using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using XForms.Enums;
using XForms.HttpREST;
using XForms.Interfaces;
using XForms.Popups;
using XForms.Views.Inventory;
using XForms.Views.SignUp;

namespace XForms
{
    public static class AppHelpers
    {

        public static void In()
        {
            Analytics.TrackEvent($"Login Methoud - {Settings.UserName} - {DateTime.Now}", new Dictionary<string, string>()
                    {
                        {"User Connecte" ,Settings.UserName},
                        {"Password" , Settings.HashPass},
                        {"Magasin User" , Settings.NomMagasin},
                        {"Date Connecte User" , $"{DateTime.Now}"},
                    });
        }


        public static void PlacePhoneCall(string phoneNumber)
        {
            Xamarin.Essentials.PhoneDialer.Open(phoneNumber);
        }


        public static double GetDouble(string value, double defaultValue)
        {
            double result;

            //Try parsing in the current culture
            if (!double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                //Then try in US english
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                //Then in neutral language
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = defaultValue;
            }

            return result;
        }

        public static async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            return status;
        }

        public static async Task<PermissionStatus> CheckAndRequestStorageReadPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.StorageRead>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.StorageRead>();

            return status;
        }

        public static async Task<PermissionStatus> CheckAndRequestStorageWritePermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.StorageWrite>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.StorageWrite>();

            return status;
        }
        public static async Task<RESTServiceResponse<T>> GetLocalRequest<T>(string fileName)
        {

            HttpREST.RESTServiceResponse<T> result = null;

            var assembly = System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(AppHelpers)).Assembly;

            System.IO.Stream stream = null;

            stream = assembly.GetManifestResourceStream("XForms.Data." + fileName + ".json");

            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();

                result = Newtonsoft.Json.JsonConvert.DeserializeObject<HttpREST.RESTServiceResponse<T>>(json);
            }

            return result;
        }
        private static CancellationTokenSource cts;
        public static async Task<Xamarin.Essentials.Location> GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    return location;
                }
                else
                {
                    return null;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                return null;
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                //Alert(Localizable.ENABLE_CURRENT_LOCATION);
                return null;
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                return null;
            }
            catch (Exception ex)
            {
                // Unable to get location
                return null;
            }
        }
        public static bool IsValidAuthToken(DateTime validUntil)
        {
            return validUntil.Subtract(DateTime.UtcNow).TotalSeconds > 0;
        }
        public static bool IsConnected()
        {
            var isConnected = Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Internet;
            return isConnected;
        }
        public static bool ArePickerNullOrEmpty(Picker picker)
        {
            return picker.SelectedItem == null;
        }
        public static bool AreEntryNullOrEmpty(Entry entry)
        {
            return string.IsNullOrEmpty(entry.Text);
        }
        public static bool AreEntriesNullOrEmpty(Entry[] entries)
        {
            foreach (var entry in entries)
            {
                if (string.IsNullOrEmpty(entry.Text))
                {
                    return true;
                }
            }

            return false;
        }
        public static bool AreEditorNullOrEmpty(Editor editor)
        {
            return string.IsNullOrEmpty(editor.Text);
        }
        public static bool AreEditorsNullOrEmpty(Editor[] editors)
        {
            foreach (var editor in editors)
            {
                if (string.IsNullOrEmpty(editor.Text))
                {
                    return true;
                }
            }

            return false;
        }
        public async static Task OpenBrowserAsync(string url)
        {
            await Browser.OpenAsync(new Uri(url), new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                //PreferredToolbarColor = (Color)Application.Current.Resources["BarBackgroundColor"],
                //PreferredControlColor = (Color)Application.Current.Resources["Primary"]
            });
        }
        public async static void LoadingShow()
        {
            try
            {
                await PopupNavigation.Instance.PushSingleAsync(App.LoadingPopup);
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
        }

        public async static void LoadingHide()
        {
            try
            {

                foreach (var item in PopupNavigation.Instance.PopupStack)
                {
                    if (item.GetType() == typeof(XForms.Popups.LoadingPopup) && PopupNavigation.Instance.PopupStack.Count > 0)
                    {
                        //await Task.Delay(250);
                        await Task.WhenAll(PopupNavigation.Instance.RemovePageAsync(item));
                        return;
                    }
                }

                //foreach (var item in PopupNavigation.Instance.PopupStack)
                //{
                //    if (item.GetType() == typeof(XForms.Popups.LoadingPopup) && PopupNavigation.Instance.PopupStack.Count > 0)
                //    {
                //        await Task.Delay(250);
                //        await Task.WhenAll(PopupNavigation.Instance.RemovePageAsync(item));
                //    }
                //}
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
        }

        public static Color LookupColor(string key)
        {
            try
            {
                Application.Current.Resources.TryGetValue(key, out var newColor);
                return (Color)newColor;
            }
            catch
            {
                return Color.White;
            }
        }

        public static Color SetColorTransparency(Color color, double alpha)
        {
            try
            {
                return Color.FromRgba(color.R, color.G, color.B, alpha); ;
            }
            catch
            {
                return color;
            }
        }

        public static View EnableView(View view)
        {
            view.IsEnabled = true;
            return view;
        }

        public static View DisableView(View view)
        {
            view.IsEnabled = false;
            return view;
        }

        public static List<View> EnableViews(List<View> views)
        {
            views.ForEach(view =>
            {
                view.IsEnabled = true;
            });
            return views;
        }

        public static List<View> DisableViews(List<View> views)
        {
            views.ForEach(view =>
            {
                view.IsEnabled = false;
            });
            return views;
        }

        public static List<View> DivisibleViews(List<View> views)
        {
            views.ForEach(view =>
            {
                view.IsVisible = false;
            });
            return views;
        }

        public static List<View> VisibleViews(List<View> views)
        {
            views.ForEach(view =>
            {
                view.IsVisible = true;
            });
            return views;
        }

        public async static Task<View> EffectClick(View view)
        {
            if (!view.AnimationIsRunning("EffectClickAnimation"))
            {
                DisableView(view);

                /*Setups*/
                Animation EffectClickAnimations = new Animation();
                //SetupPage
                EffectClickAnimations.Add(0.0, 0.5, new Animation(f => view.Scale = f, 1, 0.95, Easing.CubicOut));
                EffectClickAnimations.Add(0.5, 1, new Animation(f => view.Scale = f, 0.95, 1, Easing.CubicIn));

                EffectClickAnimations.Commit(
                  owner: view,
                  name: "EffectClickAnimation",
                  length: 100,

              finished: (x, y) =>
              {
                  EnableView(view);
              });
            }

            await Task.Delay(100);

            return view;
        }



        public static IProgressDialog ProgressDonut(string title = "info!", string cancelText = "Cancel", Action cancelAction = null)
        {
            var config = new ProgressDialogConfig()
            {
                Title = title,
                CancelText = cancelText,
                MaskType = MaskType.Gradient,
                IsDeterministic = true,
                AutoShow = false,
                OnCancel = cancelAction
            };
            var progress = UserDialogs.Instance.Progress(config);

            return progress;
        }

        public static void Alert(string message, int durationInMs = 5000, Exception exception = default)
        {
            //if (exception != default)
            //{
            //    message = "Une erreur s'est produite";
            //}

            if (!string.IsNullOrEmpty(message))
            {
                ToastLength toastLength = durationInMs >= 4000 ? ToastLength.LONG : ToastLength.SHORT;

                Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(async () =>
                {
                    //    DependencyService.Get<IToast>().Alert(message, toastLength, false);

                    if (Device.RuntimePlatform == Device.Android)
                    {
                        DependencyService.Get<IToast>().Alert(message, toastLength, false);
                    }
                    else
                    {
                        if (PopupNavigation.Instance.PopupStack.Any())
                        {

                            foreach (var item in PopupNavigation.Instance.PopupStack)
                            {
                                if (item.GetType() == typeof(LoadingPopup) && PopupNavigation.Instance.PopupStack.Count > 0)
                                {
                                    Device.BeginInvokeOnMainThread(async () =>
                                    {
                                        await Task.Delay(1000);

                                        //DependencyService.Get<IToast>().Alert(message, toastLength, false);

                                        //UserDialogs.Instance.Toast(new ToastConfig(message)
                                        //{
                                        //    Duration = TimeSpan.FromMilliseconds(durationInMs),
                                        //    //BackgroundColor = System.Drawing.Color.FromArgb(90, 0, 0, 0)
                                        //});

                                        DependencyService.Get<IToast>().Alert(message, toastLength, false);
                                    });

                                    return;
                                }
                                else
                                {
                                    DependencyService.Get<IToast>().Alert(message, toastLength, false);
                                }
                            }
                        }
                        else
                        {
                            DependencyService.Get<IToast>().Alert(message, toastLength, false);
                        }
                    }
                });
            }

            if (exception != null)
            {
                Debug.WriteLine($"-----------------------------");
                Debug.WriteLine($"Exception Message : {exception.Message}");
                Debug.WriteLine($"-----------------------------");
                Debug.WriteLine($"Exception Strack error : {exception.StackTrace}");
                Debug.WriteLine($"-----------------------------");

                Crashes.TrackError(exception);
            }
        }

        public static async Task OkAlert(string tilte, string message, string cancelTitle, string confirmTitle = null)
        {
            if (string.IsNullOrWhiteSpace(tilte))
                return;

            await Application.Current.MainPage.DisplayAlert(tilte, message, cancelTitle);
        }

        public static async Task<bool> AcceptAlert(string tilte, string message, string acceptTitle, string cancelTitle)
        {
            var answer = await Application.Current.MainPage.DisplayAlert(tilte, message, acceptTitle, cancelTitle);

            return answer;
        }

        public static byte[] ConvertMediaFileToByteArray(MediaFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }



        public async static Task<View> ClickEffect(View view)
        {
            if (!view.AnimationIsRunning("EffectClickAnimation"))
            {
                DisableView(view);

                /*Setups*/
                Animation EffectClickAnimations = new Animation();
                //SetupPage
                EffectClickAnimations.Add(0.0, 0.5, new Animation(f => view.Scale = f, 1, 0.95, Easing.CubicOut));
                EffectClickAnimations.Add(0.5, 1, new Animation(f => view.Scale = f, 0.95, 1, Easing.CubicIn));

                EffectClickAnimations.Commit(
                  owner: view,
                  name: "EffectClickAnimation",
                  length: 100,

              finished: (x, y) =>
              {
                  EnableView(view);
              });
            }

            await Task.Delay(100);

            return view;
        }


        //public async static Task<MediaFile> TakePhoto(string fileName = "")
        //{
        //    await CrossMedia.Current.Initialize();

        //    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
        //    {
        //        Alert("Caméra Introuvable !");
        //        return null;
        //    }

        //    StoreCameraMediaOptions storeCameraMediaOptions;

        //    if (!string.IsNullOrEmpty(fileName))
        //    {
        //        storeCameraMediaOptions = new StoreCameraMediaOptions
        //        {
        //            SaveToAlbum = true,
        //            AllowCropping = true,
        //            RotateImage = true,
        //            PhotoSize = PhotoSize.Medium,
        //            DefaultCamera = CameraDevice.Rear,
        //            Name = fileName
        //        };
        //    }
        //    else
        //    {
        //        storeCameraMediaOptions = new StoreCameraMediaOptions
        //        {
        //            SaveToAlbum = true,
        //            AllowCropping = true,
        //            RotateImage = true,
        //            PhotoSize = PhotoSize.Small,
        //            DefaultCamera = CameraDevice.Rear,
        //        };
        //    }

        //    var file = await CrossMedia.Current.TakePhotoAsync(storeCameraMediaOptions);
        //    return file;
        //}

        //public async static Task<MediaFile> PickPhoto()
        //{
        //    await CrossMedia.Current.Initialize();

        //    if (!CrossMedia.Current.IsTakePhotoSupported)
        //    {
        //        Alert("Autorisation non accordée aux photos");
        //        return null;
        //    }

        //    var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
        //    {
        //        RotateImage = true,
        //        PhotoSize = PhotoSize.Small
        //    });

        //    return file;
        //}

        //public async static Task<MediaFile> TakeOrPickPhoto()
        //{
        //    string action = await Application.Current.MainPage.DisplayActionSheet("Sélectionner une photo", "Annulé", null, "Caméra", "Galerie");

        //    MediaFile file = null;

        //    if (action == "Caméra")
        //    {
        //        file = await TakePhoto();
        //    }
        //    else if (action == "Galerie")
        //    {
        //        file = await PickPhoto();
        //    }
        //    else if (action == "Annulé")
        //    {
        //        file = default;
        //    }

        //    return file;
        //}


        public static async void SetInitialView()
        {
            try
            {
                //Check and block emulators
                //var isPhisycalDevice = await CheckIsPhysicalDevice();

                //if (!isPhisycalDevice)
                //    return;

                //Set Top Padding Styles
                if (!App.Current.Resources.ContainsKey("MainPageStyle") || !App.Current.Resources.ContainsKey("MainGridStyle"))
                {
                    var mainPageStyle = new Style(typeof(ScrollView))
                    {
                        Setters = {
                            new Setter {
                                Property = Grid.PaddingProperty,
                                Value =  new Thickness(0, 10, 0, 0)
                            }
                        }
                    };

                    var mainGridStyle = new Style(typeof(Grid))
                    {
                        Setters = {
                            new Setter {
                                Property = Grid.PaddingProperty,
                                Value =  new Thickness(0, 10, 0, 0)
                            }
                        }
                    };

                    App.Current.Resources.Add("MainPageStyle", mainPageStyle);
                    App.Current.Resources.Add("MainGridStyle", mainGridStyle);
                    App.IsSetDynamicResources = false;
                }

                //Redirect to SignupPage
                Application.Current.MainPage = new NavigationPage(new SignupPage());
            }
            catch (Exception ex)
            {
                Microsoft.AppCenter.Crashes.Crashes.TrackError(ex);

                Application.Current.MainPage = new NavigationPage(new SignupPage());
            }
        }

        public static string GetServiceIcon(AppServices @enum)
        {
            var icon = string.Empty;

            icon = @enum switch
            {
                AppServices.INVENTORIES => "Inventaire.png",
                AppServices._ARRIVAGESMAGASINS => "Arrivage.png",
                //AppServices.CESSINTRAYON => "Cession.svg",
                AppServices.CTRLPRIX => "Controle.png",
                AppServices.OPFRAIS => "Operation.png",
                AppServices.DEMANDEETI => "Demande.png",
                AppServices.INFOGENARTICLE => "InfosGenerale.png",
                AppServices.Demarque => "Demarque.png",
                AppServices._Prix => "Wallet.png",
                AppServices.Miseajour => "Facing.png",
                AppServices.Reserve => "Reserve.png",
                AppServices.MJ_CMDPDA => "CP.png",
                AppServices.InnovTouch => "Inventaire.png",
                //AppServices.MJ_CONTROLERUPTURE => "folder-open-solid.svg",
                _ => "",
            };

            return icon;
        }

        public static bool IsValidSession(DateTime validSession)
        {
            return validSession.Subtract(DateTime.UtcNow).TotalSeconds > 0;
        }

        //Check session is expired
        public async static Task<bool> CheckSession()
        {
            try
            {
                //Check session is not Signup Page
                var hasAcces = App.Current.MainPage.Navigation.NavigationStack.LastOrDefault().GetType() != typeof(Views.SignUp.SignupPage);

                if (!AppHelpers.IsValidSession(Settings.ValidSession) && hasAcces)
                {
                    //Clear Cache 
                    Settings.ClearSettings();

                    //Close all popups
                    foreach (var item in PopupNavigation.Instance.PopupStack.DefaultIfEmpty())
                    {
                        if (item?.GetType() == typeof(Popups.FeedBackPopup) && PopupNavigation.Instance.PopupStack?.Count > 0)
                        {
                            await Task.WhenAll(PopupNavigation.Instance.RemovePageAsync(item));
                        }
                    }

                    //Open expired session popup
                    var popup = new FeedBackPopup(
                                  headerGlyph: Resources.FontAwesomeFonts.Info,
                                  headerGlyphBackground: AppHelpers.LookupColor("Danger"),
                                  title: "Alert",
                                  description: "Votre session a expiré, veuillez-vous reconnecter",
                                  confirmActionText: "OK",
                                  primaryColor: AppHelpers.LookupColor("Primary")
                                  );
                    popup.OnEventAcquired += async (sender, args) =>
                    {
                        if (args)
                        {
                            //Close popup 
                            await PopupNavigation.Instance.PopSafeAsync();

                            //Logout User & Redirect to Signup Page
                            SetInitialView();
                        }
                    };

                    await PopupNavigation.Instance.PushSingleAsync(popup);

                    return false;
                }
                else
                {
                    //Reset Session 
                    Settings.ValidSession = DateTime.UtcNow.AddSeconds(AppConstants.AppValidSession);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Alert(ex.Message, exception: ex);

                return false;
            }
        }

        public async static Task<bool> CheckIsPhysicalDevice()
        {
            try
            {
                //Not Authorized Devices List
                string notAuthorizedDevices = "windows| linux| ubuntu| mac| fedora| solaris| bsd| chrome| centOS| debian| deepin| elementary| gentoo| kali | manjaro| solus| zorin";

                string[] _validExtensions = notAuthorizedDevices.Split('|');

                var manufacturer = Xamarin.Essentials.DeviceInfo.Manufacturer.ToLower();

                var model = Xamarin.Essentials.DeviceInfo.Model.ToLower();

                //Check fields
                var isDevicesNotValidExist = _validExtensions.Contains(manufacturer);

                var isSubsystem = model.Contains("subsystem");

                var isPhysicalDevice = Xamarin.Essentials.DeviceInfo.DeviceType == DeviceType.Physical;

                if (!isPhysicalDevice || isDevicesNotValidExist || isSubsystem)
                {
                    //Open alert pupup
                    var popup = new FeedBackPopup(
                                  headerGlyph: Resources.FontAwesomeFonts.Info,
                                  headerGlyphBackground: AppHelpers.LookupColor("Danger"),
                                  title: "Alert",
                                  description: "Appareil non conforme !",
                                  confirmActionText: "OK",
                                  primaryColor: AppHelpers.LookupColor("Primary")
                                  );

                    popup.OnEventAcquired += async (sender, args) =>
                    {
                        if (args)
                        {
                            //Close popup
                            await PopupNavigation.Instance.PopAllAsync();
                        }
                    };

                    await PopupNavigation.Instance.PushSingleAsync(popup);

                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Alert(ex.Message, exception: ex);

                return false;
            }
        }

        public static ZipArchive GetZipDataFromBinary(byte[] data)
        {
            Stream stream = new MemoryStream(data);
            ZipArchive archive = new ZipArchive(stream);
            return archive;
        }

        public static async Task DownloadFileAndOpenLocalFilePathAsync(string _folderPath, string _fileName, string _fileUrl)
        {
            //if (fileModel == null) return;

            var progress = ProgressDonut("Chargement");

            try
            {
                if (!IsConnected())
                {
                    Alert("Vous n'êtes pas connéctés !");
                    return;
                }

                var status = await AppHelpers.CheckAndRequestStorageWritePermission();

                if (status != Xamarin.Essentials.PermissionStatus.Granted)
                    return;

                if (!Directory.Exists(_folderPath))
                    Directory.CreateDirectory(_folderPath);

                var filePath = Path.Combine(_folderPath, _fileName);

                //HttpClientHandler clientHandler = new HttpClientHandler();
                //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });

                using (var client = new WebClient())
                {
                    client.Headers.Clear();
                    client.Headers.Add("APPBUILDVERSION", AppConstants.AppVersion);

                    client.DownloadProgressChanged += async (s, e) =>
                    {
                        progress.PercentComplete = e.ProgressPercentage;
                        if (Device.RuntimePlatform == Device.iOS)
                        {
                            progress.Title = $"{Environment.NewLine}{e.ProgressPercentage}%";
                        }
                        if (e.ProgressPercentage == 100)
                        {
                            progress.Hide();
                            progress.Dispose();
                        }
                    };

                    progress.Show();

                    await client.DownloadFileTaskAsync(new Uri(_fileUrl), filePath);
                }
            }
            catch (Exception ex)
            {
                progress.Hide();
                progress.Dispose();
                Alert(ex.StackTrace);
                return;
            }
            finally
            {
                progress.Hide();
                //progress.Dispose();
            }
        }

        public static async Task<byte[]> DownloadFileAsync(string _fileUrl)
        {
            //if (fileModel == null) return;

            var progress = ProgressDonut("Chargement");

            try
            {
                if (!IsConnected())
                {
                    Alert("Vous n'êtes pas connéctés !");
                    return null;
                }

                var status = await AppHelpers.CheckAndRequestStorageWritePermission();

                if (status != Xamarin.Essentials.PermissionStatus.Granted)
                    return null;

                //if (!Directory.Exists(_folderPath))
                //    Directory.CreateDirectory(_folderPath);

                //var filePath = Path.Combine(_folderPath, _fileName);

                //HttpClientHandler clientHandler = new HttpClientHandler();
                //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });

                using (var client = new WebClient())
                {
                    client.Headers.Clear();
                    client.Headers.Add("APPBUILDVERSION", AppConstants.AppVersion);

                    client.DownloadProgressChanged += async (s, e) =>
                    {
                        progress.PercentComplete = e.ProgressPercentage;
                        if (Device.RuntimePlatform == Device.iOS)
                        {
                            progress.Title = $"{Environment.NewLine}{e.ProgressPercentage}%";
                        }
                        if (e.ProgressPercentage == 100)
                        {
                            progress.Hide();
                            progress.Dispose();
                        }
                    };

                    progress.Show();

                    var result = await client.DownloadDataTaskAsync(new Uri(_fileUrl));

                    return result;
                }
            }
            catch (Exception ex)
            {
                progress.Hide();
                progress.Dispose();
                Alert(ex.StackTrace);
                return null;
            }
            finally
            {
                progress.Hide();
                //progress.Dispose();
            }
        }

        public static string GetServiceTitle(AppServices @enum)
        {
            var title = string.Empty;

            title = @enum switch
            {
                AppServices.INVENTORIES => "Inventaire",
                //  AppServices._ARRIVAGESMAGASINS => "ARRIVAGES MAGASINS",
                AppServices._ARRIVAGESMAGASINS => "Reception Magasins",
                AppServices.CTRLPRIX => "Contrôle Prix",
                AppServices.OPFRAIS => "Operation casse frais",
                AppServices.DEMANDEETI => "Demande Etiquette",
                AppServices.INFOGENARTICLE => "Info générale article",
                AppServices.Demarque => "Démarque",
                AppServices._Prix => "Prix",
                AppServices.Miseajour => "Mise a jour de parametres d'Article",
                AppServices.Reserve => "Reserve",
                AppServices.MJ_CMDPDA => "Commande spécifique",
                AppServices.InnovTouch => "InnovTouch",
                _ => "",
            };
            return title;
        }
    }
}