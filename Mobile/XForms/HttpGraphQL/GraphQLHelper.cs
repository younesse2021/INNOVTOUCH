////using XForms.Models;
////using Microsoft.AppCenter.Crashes;
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Linq;
//using System.Net;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using GraphQL;
//using GraphQL.Client.Http;
//using Microsoft.AppCenter.Crashes;
//using XForms.Enums;
//using XForms.HttpREST;

//namespace XForms.HttpGraphQL
//{
//    public static class GraphQLHelper
//    {
//        #region GetRequest GetParams as NameValueCollection
//        public static async Task<GraphQLServiceResponse<T>> GetGraphQLRequest<T>(string url, HttpVerbs method = HttpVerbs.POST, GraphQLRequest postRequest = null, bool needUserAcces = false, bool needCartParams = false)
//        {
//            try
//            {
//                #region IsConnected
//                if (!AppHelpers.IsConnected())
//                {
//                    return new GraphQLServiceResponse<T>(default, new List<GraphQLError> { new GraphQLError() { Message = "Vous n'êtes pas connéctés !" } });
//                }
//                #endregion

//                //Skip Certificate Validation
//                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });

//                var uri = new Uri(url);
//                var serializer = new GraphQL.Client.Serializer.Newtonsoft.NewtonsoftJsonSerializer();

//                using (var graphQLClient = new GraphQLHttpClient(uri, serializer))
//                {
//                    //setup client
//                    //graphQLClient.HttpClient.DefaultRequestHeaders.Accept.Clear();

//                    //graphQLClient.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                    graphQLClient.HttpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + AppConstants.BasicAuthorizationHash);

//                    if (needUserAcces)
//                    {
//                        graphQLClient.HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("AuthorizationToken", "Bearer " + Settings.AccessToken);
//                    }

//                    if (needCartParams)
//                    {
//                        var storeSourceIdAppKey = !string.IsNullOrEmpty(Settings.StoreSourceIdAppKey) ? Settings.StoreSourceIdAppKey : "0";
//                        var purchaseMethodAppKey = !string.IsNullOrEmpty(Settings.PurchaseMethodAppKey) ? Settings.PurchaseMethodAppKey : "delivery";

//                        graphQLClient.HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("StoreSourceId", storeSourceIdAppKey);
//                        graphQLClient.HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("PurchaseMethod", purchaseMethodAppKey);
//                    }

//                    //client.DefaultRequestHeaders.TryAddWithoutValidation("APIKEY", AppUrls.APIKEY);

//                    var graphQLResponse = await graphQLClient.SendQueryAsync<T>(postRequest);

//                    //if (response.StatusCode == HttpStatusCode.NotFound ||
//                    //    stringResponseJson.Contains(Constant.F5Expired) ||
//                    //    stringResponseJson.Contains(Constant.F5Error))
//                    //{
//                    //    if (!string.IsNullOrEmpty(Settings.MRHSession))
//                    //    {
//                    //        Settings.ClearSettings();
//                    //        Application.Current.MainPage = new NavigationPage(new Views.Login.LoginF5Page());
//                    //    }
//                    //}

//                    //if (graphQLResponse.Errors.Where( x=> x.Extensions.Keys.FirstOrDefault().)
//                    //{

//                    //}

//                    return new GraphQLServiceResponse<T>(graphQLResponse.Data, graphQLResponse.Errors);
//                }
//            }
//            catch (Exception Ex)
//            {
//                Crashes.TrackError(Ex);

//                //return new GraphQLServiceResponse<T>(default, new List<GraphQLError> { new GraphQLError() { Message = "Une erreur s'est produite" } });
//                return new GraphQLServiceResponse<T>(default, new List<GraphQLError> { new GraphQLError() { Message = Ex.Message } });
//            }
//        }
//        #endregion

//    }
//}