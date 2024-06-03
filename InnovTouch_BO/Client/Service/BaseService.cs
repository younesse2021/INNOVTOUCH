using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Radzen;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System;
using InnovTouch_BO.Client.Models;
using Shared.DTO.InnovTouch.DTO.Helper;

namespace DLC_BO.Client.Service
{
    public class BaseService<T>
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            PropertyNameCaseInsensitive = true
        };
        private HttpClient httpClient;

        public BaseService(HttpClient httpClient, AppStateContainer appStateContainer)
        {
            _httpClient = httpClient;
            if(appStateContainer.UtilisateurBo != null)
            {
                _httpClient.DefaultRequestHeaders.Remove("APPBUILDVERSION");
                _httpClient.DefaultRequestHeaders.Add("APPBUILDVERSION", appStateContainer.UtilisateurBo.Token?.Token);
                _httpClient.DefaultRequestHeaders.Remove("user_name");
                _httpClient.DefaultRequestHeaders.Add("user_name", appStateContainer.UtilisateurBo.UserName);
            }
            
        }
        protected async Task<Response<int>> Add(string uri, T model)
        {
            var resulat = new Response<int>(uri);
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync(uri, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                resulat = await httpResponse.ReadAsync<Response<int>>();
            }
            else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                resulat.Succeeded = false;
                resulat.Message = "401 : Non autorisé";
            }
            else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
            {
                resulat.Succeeded = false;
                resulat.Message = "500 : Erreur interne du serveur";
            }
            else
            {
                resulat.Succeeded = false;
                resulat.Message = $"{httpResponse.StatusCode} : Erreur ";
            }
            return resulat;
        }
        protected async Task<Response<bool>> Edit(string uri, T model)
        {
            var resulat = new Response<bool>(uri);
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PutAsync(uri, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                resulat = await httpResponse.ReadAsync<Response<bool>>();
            }
            else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                resulat.Succeeded = false;
                resulat.Message = "401 : Non autorisé";
            }
            else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
            {
                resulat.Succeeded = false;
                resulat.Message = "500 : Erreur interne du serveur";
            }
            else
            {
                resulat.Succeeded = false;
                resulat.Message = $"{httpResponse.StatusCode} : Erreur ";
            }
            return resulat;
        }
        protected async Task<Response<List<T>>> All(string uri)
        {
            Response<List<T>> resulat = new Response<List<T>>();
            var httpResponse = await _httpClient.GetAsync(uri);

            if (httpResponse.IsSuccessStatusCode)
            {
                resulat = await httpResponse.ReadAsync<Response<List<T>>>();
            }
            else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                resulat.Succeeded = false;
                resulat.Message = "401 : Non autorisé";
            }
            else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
            {
                resulat.Succeeded = false;
                resulat.Message = "500 : Erreur interne du serveur";
            }
            else
            {
                resulat.Succeeded = false;
                resulat.Message = $"{httpResponse.StatusCode} : Erreur ";
            }
            return resulat;
        }
        protected async Task<Response<T>> GetItem(string uri)
        {
            Response<T> resulat = new Response<T>();
            var httpResponse = await _httpClient.GetAsync(uri);

            if (httpResponse.IsSuccessStatusCode)
            {
                resulat = await httpResponse.ReadAsync<Response<T>>();
            }
            else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                resulat.Succeeded = false;
                resulat.Message = "401 : Non autorisé";
            }
            else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
            {
                resulat.Succeeded = false;
                resulat.Message = "500 : Erreur interne du serveur";
            }
            else
            {
                resulat.Succeeded = false;
                resulat.Message = $"{httpResponse.StatusCode} : Erreur ";
            }
            return resulat;
        }
        protected async Task<Response<bool>> Delete(string uri)
        {
            var resulat = new Response<bool>(uri);
            var httpResponse = await _httpClient.DeleteAsync(uri);
            if (httpResponse.IsSuccessStatusCode)
            {
                resulat = await httpResponse.ReadAsync<Response<bool>>();
            }
            else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                resulat.Succeeded = false;
                resulat.Message = "401 : Non autorisé";
            }
            else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
            {
                resulat.Succeeded = false;
                resulat.Message = "500 : Erreur interne du serveur";
            }
            else
            {
                resulat.Succeeded = false;
                resulat.Message = $"{httpResponse.StatusCode} : Erreur ";
            }
            return resulat;
        }
        protected async Task<Response<List<T>>> AllWithModel<J>(string uri, J model)
        {
            var resulat = new Response<List<T>>(uri);
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync(uri, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                resulat = await httpResponse.ReadAsync<Response<List<T>>>();
            }
            else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                resulat.Succeeded = false;
                resulat.Message = "401 : Non autorisé";
            }
            else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
            {
                resulat.Succeeded = false;
                resulat.Message = "500 : Erreur interne du serveur";
            }
            else
            {
                resulat.Succeeded = false;
                resulat.Message = $"{httpResponse.StatusCode} : Erreur ";
            }
            return resulat;
        }
        protected async Task<Response<List<X>>> AllCostumWithModel<X,J>(string uri, J model)
        {
            var resulat = new Response<List<X>>(uri);
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync(uri, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                resulat = await httpResponse.ReadAsync<Response<List<X>>>();
            }
            else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                resulat.Succeeded = false;
                resulat.Message = "401 : Non autorisé";
            }
            else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
            {
                resulat.Succeeded = false;
                resulat.Message = "500 : Erreur interne du serveur";
            }
            else
            {
                resulat.Succeeded = false;
                resulat.Message = $"{httpResponse.StatusCode} : Erreur ";
            }
            return resulat;
        }
        protected async Task<Response<T>> GetItemWithModel<J>(string uri, J model)
        {
            var resulat = new Response<T>(uri);

            try
            {
                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var httpResponse = await _httpClient.PostAsync(uri, data);
                if (httpResponse.IsSuccessStatusCode)
                {
                    resulat = await httpResponse.ReadAsync<Response<T>>();
                }
                else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    resulat.Succeeded = false;
                    resulat.Message = "401 : Non autorisé";
                }
                else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                {
                    resulat.Succeeded = false;
                    resulat.Message = "500 : Erreur interne du serveur";
                }
                else
                {
                    resulat.Succeeded = false;
                    resulat.Message = $"{httpResponse.StatusCode} : Erreur ";
                }
                return resulat;
            }
            catch (Exception ex )
            {
                resulat.Succeeded = false;
                resulat.Message = $" error : {ex.Message}  ";
                return resulat;
            }
        }
        protected async Task<Response<byte[]>> DowloadFileWithModel<J>(string uri, J model)
        {
            try
            {
                var resulat = new Response<byte[]>(uri);
                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var httpResponse = await _httpClient.PostAsync(uri, data);
                if (httpResponse.IsSuccessStatusCode)
                {
                    resulat.Data = await httpResponse.Content.ReadAsByteArrayAsync();
                    resulat.Succeeded = true;
                }
                else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    resulat.Succeeded = false;
                    resulat.Message = "401 : Non autorisé";
                }
                else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                {
                    resulat.Succeeded = false;
                    resulat.Message = "500 : Erreur interne du serveur";
                }
                else
                {
                    resulat.Succeeded = false;
                    resulat.Message = $"{httpResponse.StatusCode} : Erreur ";
                }
                return resulat;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
