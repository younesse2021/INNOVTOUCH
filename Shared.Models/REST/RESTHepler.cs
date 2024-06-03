using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Shared.Models.REST
{
    public class RESTHepler
    {
        public static async Task<Response<T>> Run<T>(string BaseUrl_API , object model)
        {
            var stringResponseXml = "";
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });
                System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                using (var client = new HttpClient())
                {
                    Uri uri = new Uri(BaseUrl_API);

                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                    HttpResponseMessage response = new HttpResponseMessage();
                    var content = new StringContent(model.ToString(), Encoding.UTF8, "application/xml");
                    response = await client.PostAsync(uri, content);

                    stringResponseXml = await response.Content.ReadAsStringAsync();
                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(stringResponseXml);
                    var fromXml = JsonConvert.SerializeXmlNode(xmldoc);
                    var result = JsonConvert.DeserializeObject<T>(fromXml);

                    return new Response<T>(result, "Success.");
                }
            }
            catch (Exception ex)
            {
                return new Response<T>(message: stringResponseXml);
            }
        }

       

        public static async Task<string> RunString(string BaseUrl_API, object model)
        {
            var stringResponseXml = "";
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });
                System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                using (var client = new HttpClient())
                {
                    Uri uri = new Uri(BaseUrl_API);

                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                    HttpResponseMessage response = new HttpResponseMessage();
                    var content = new StringContent(model.ToString(), Encoding.UTF8, "application/xml");
                    response = await client.PostAsync(uri, content);

                    stringResponseXml = await response.Content.ReadAsStringAsync();
                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(stringResponseXml);
                    var fromXml = JsonConvert.SerializeXmlNode(xmldoc);
                    //var result = JsonConvert.DeserializeObject<T>(fromXml);

                    return fromXml;
                }
            }
            catch (Exception ex)
            {
                return stringResponseXml;
            }
        }
    }
}
