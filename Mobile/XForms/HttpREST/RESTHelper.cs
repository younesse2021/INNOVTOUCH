//using XForms.Models;
//using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using Shared.Models;
using Shared.Models.OUT;
using XForms.Enums;

namespace XForms.HttpREST
{
    public static class RESTHelper
    {
        #region Login Method
        public static async Task<List<AuthResponse>> POSTLoginResultModel(AuthModel loginModel)
        {
            try
            {

                #region IsConnected
                if (!AppHelpers.IsConnected())
                {
                    //return new List<AuthResponse>() { error_description = "Vous n'êtes pas connéctés !" };
                    return null;
                }
                #endregion

                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });

                //var handler = new HttpClientHandler();
                //handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                //handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => { return true; };

                var loginUrl = new Uri(AppUrls.POSTLogin);

                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = loginUrl;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.TryAddWithoutValidation("APIKEY", AppUrls.APIKEY);

                    var formEncodedContent = new FormUrlEncodedContent(new[]
                    {
                     new KeyValuePair<string, string>("grant_type", "password"),
                     new KeyValuePair<string, string>("username", loginModel.login),
                     new KeyValuePair<string, string>("password", loginModel.password),
                });

                    var responseMessage = await client.PostAsync(loginUrl, formEncodedContent);

                    var stringResponseJson = await responseMessage.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<List<AuthResponse>>(stringResponseJson);

                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public static async Task<LoginResultModel> PostRefreshLoginResultModel(string refresh_step, string userRole = "")
        //{
        //    try
        //    {
        //        //#region Is valid model
        //        //if (loginModel == null || string.IsNullOrWhiteSpace(loginModel?.Username) || string.IsNullOrWhiteSpace(loginModel?.Password))
        //        //    return new LoginResultModel() { Error = "Invalid input", ErrorDescription = "Invalid username/ password" };
        //        //#endregion

        //        #region IsConnected
        //        if (!AppHelpers.IsConnected())
        //            return new LoginResultModel() { error_description = "Vous n'êtes pas connéctés !" };
        //        #endregion

        //        var loginUrl = new Uri(AppUrls.POSTLogin);

        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = loginUrl;
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            client.DefaultRequestHeaders.TryAddWithoutValidation("APIKEY", AppUrls.APIKEY);

        //            var formEncodedContent = new FormUrlEncodedContent(new[]
        //            {
        //                 new KeyValuePair<string, string>("grant_type", "refresh_token"),
        //                 new KeyValuePair<string, string>("refresh_token", Settings.RefreshToken),

        //                 //new KeyValuePair<string, string>("refresh_step", refresh_step),
        //                 //new KeyValuePair<string, string>("user_mode", userRole),
        //            });

        //            var responseMessage = await client.PostAsync(loginUrl, formEncodedContent);

        //            var stringResponseJson = await responseMessage.Content.ReadAsStringAsync();

        //            LoginResultModel result = JsonConvert.DeserializeObject<LoginResultModel>(stringResponseJson);

        //            return result;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new LoginResultModel() { error = "Error", error_description = ex.Message };
        //    }
        //}

        #endregion

        #region Authenticated Http Image
        public class AuthenticatedHttpImageClientHandler : HttpClientHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {

                //var handler = new HttpClientHandler() { CookieContainer = CookieContainer = App.MRHSessionCookies };

                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (var client = new HttpClient(clientHandler))
                {
                    //setup client
                    Uri uri = request.RequestUri;
                    #region Setting Attachements

                    #endregion
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Settings.AccessToken);
                    //client.DefaultRequestHeaders.TryAddWithoutValidation("From", AppUrls.AppHash);

                    //make request
                    HttpResponseMessage response = new HttpResponseMessage();

                    var cachedImage = await client.GetAsync(uri);

                    return cachedImage;
                }
            }
        }
        #endregion

        #region GetRequest GetParams as NameValueCollection
        public static async Task<RESTServiceResponse<T>> GetRequest<T>(string url, HttpVerbs method = HttpVerbs.GET, NameValueCollection getParams = null, object postObject = null, string contentType = "application/json")
        {
            try
            {
                #region Check Is Device Connected
                if (!AppHelpers.IsConnected())
                {
                    return new RESTServiceResponse<T>(false, Localizable.NO_CONNEXION);
                }
                #endregion

                # region Skip Certificate Validation
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });
                #endregion

                #region  Http Client 
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (var client = new HttpClient(clientHandler))
                {
                    //setup client
                    Uri uri = new Uri(url);
                    #region Setting Attachements

                    if (method == HttpVerbs.GET && getParams != null)
                    {
                        uri = uri.AttachParameters(getParams);
                    }

                    #endregion
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

                    client.DefaultRequestHeaders.TryAddWithoutValidation("APPBUILDVERSION", AppConstants.AppVersion);

                    //client.DefaultRequestHeaders.TryAddWithoutValidation("apikey", "1.0");
                    //client.DefaultRequestHeaders.TryAddWithoutValidation("BUILDVERSION", Xamarin.Essentials.VersionTracking.CurrentVersion);
                    //client.DefaultRequestHeaders.Add(HttpRequestHeader.Authorization.ToString(), "Bearer " + Settings.AccessToken);

                    //make request
                    HttpResponseMessage response = new HttpResponseMessage();

                    switch (method)
                    {
                        case HttpVerbs.GET:
                            response = await client.GetAsync(uri);
                            break;
                        case HttpVerbs.POST:
                            var json = JsonConvert.SerializeObject(postObject,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
                            var content = new StringContent(json, Encoding.UTF8, contentType);
                            response = await client.PostAsync(uri, content);
                            break;
                        case HttpVerbs.PUT:
                            var json2 = JsonConvert.SerializeObject(postObject,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
                            var content2 = new StringContent(json2, Encoding.UTF8, contentType);
                            response = await client.PutAsync(uri, content2);
                            break;
                        default:
                            break;
                    }

                    var stringResponseJson = await response.Content.ReadAsStringAsync();

                    
                    var result = JsonConvert.DeserializeObject<RESTServiceResponse<T>>(stringResponseJson);

                    return result;
                }
                #endregion

            }
            catch (Exception Ex)
            {
                Crashes.TrackError(Ex);
                return new RESTServiceResponse<T>(false, Ex.Message);
            }
        }
        
        #endregion

        #region GetRequest Json
        public static async Task<T> GetRequestJson<T>(string url, HttpVerbs method = HttpVerbs.GET, NameValueCollection getParams = null, object postObject = null, string contentType = "application/json")
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //setup client
                    Uri uri = new Uri(url);
                    #region Setting Attachements

                    if (method == HttpVerbs.GET && getParams != null)
                    {
                        uri = uri.AttachParameters(getParams);
                    }

                    #endregion
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Settings.AccessToken);
                    //client.DefaultRequestHeaders.TryAddWithoutValidation("From", AppUrls.AppHash);

                    //make request
                    HttpResponseMessage response = new HttpResponseMessage();
                    switch (method)
                    {
                        case HttpVerbs.GET:
                            response = await client.GetAsync(uri);
                            break;
                        case HttpVerbs.POST:
                            var content = new StringContent(JsonConvert.SerializeObject(postObject), Encoding.UTF8, contentType);
                            response = await client.PostAsync(uri, content);
                            break;
                        default:
                            break;
                    }

                    var stringResponseJson = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<T>(stringResponseJson);

                    return result;
                }
            }
            catch (Exception ex)
            {
                //Send Exception To AppCenter
                Crashes.TrackError(ex);

                return default;
            }
        }
        #endregion
    }
}