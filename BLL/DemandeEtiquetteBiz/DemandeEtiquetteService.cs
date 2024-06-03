using Renci.SshNet;
using Shared.Models;
using Shared.Models.IN;
using Shared.Models.OUT.Article;
using Shared.Models.OUT.ArticleByEAN;
using Shared.Models.OUT_;
using Shared.Models.OUT_.ArticleByEANEti;
using Shared.Models.OUT_.Formats;
using Shared.Models.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DemandeEtiquetteService : BaseService
    {
        public async Task<Response<ArticleEti>> ArticleInfos(string BaseUrl_Image, string BaseUrl_API, ArticleByEANModel model)
        {
            try
            {
                var body = @$"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                              <SOAP-ENV:Header>
                              <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                              <Authentification>
                              <Username>{model.username}</Username>
                              <Password>{model.password}</Password>
                              <Domain>DEFAULT</Domain>
                              <MethodName>GWSGetArticleEtiData</MethodName>
                              </Authentification>
                              <Context>
                              <Classe>10</Classe>
                              <Site>{model.site}</Site>
                              <MerchStructID>1</MerchStructID>
                              <CommercialNetworkID>1</CommercialNetworkID>
                              <Language>FR</Language>
                              </Context>
                              </Parameters>
                              </SOAP-ENV:Header><SOAP-ENV:Body>
                              <Request_GWSGetArticleEtiData xmlns=""http://www.-solutions.com/WebServices/"">
                              <GWSGetArticleEtiData>
                              <EAN><![CDATA[{model.ean}]]></EAN>
                              </GWSGetArticleEtiData>
                              </Request_GWSGetArticleEtiData>
                              </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<ArticleByEANEtiResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSGetArticleEtiData.DATA.articleEti;
                //resultOutput.imageUrl = @$"{BaseUrl_Image}/images-articles-msm-resize/{model.ean}.jpg";

                return new Response<ArticleEti>(resultOutput, response.Message);
            }
            catch (Exception ex)
            {
                return new Response<ArticleEti>("Article inconnu.");
            }
        }

        public async Task<Response<List<Etiquette>>> Formats(string BaseUrl_API, FormatsModel model)
        {
            try
            {
                var body = @$"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                             <SOAP-ENV:Header>
                             <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                             <Authentification>
                             <Username>{model.username}</Username>
                             <Password>{model.password}</Password>
                             <Domain>DEFAULT</Domain>
                             <MethodName>GWSGetEtiAllFormats</MethodName>
                             </Authentification>
                             <Context>
                             <Classe>10</Classe>
                             <Site>{model.site}</Site>
                             <MerchStructID>1</MerchStructID>
                             <CommercialNetworkID>1</CommercialNetworkID>
                             <Language>FR</Language>
                             </Context>
                             </Parameters>
                             </SOAP-ENV:Header><SOAP-ENV:Body>
                             <Request_GWSGetEtiAllFormats xmlns=""http://www.-solutions.com/WebServices/"">
                             <GWSGetEtiAllFormats>
                             <Metier><![CDATA[1]]></Metier>
                             </GWSGetEtiAllFormats>
                             </Request_GWSGetEtiAllFormats>
                             </SOAP-ENV:Body></SOAP-ENV:Envelope>";

                var response = await RESTHepler.Run<FormatResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSGetEtiAllFormats.DATA.etiquettes;

                //resultOutput.imageUrl = CurrentBaseUrl + "/api/download/" + model.ean;
                //resultOutput.imageUrl = @$"http://192.168.99.96:8082/eretail/{model.ean}.png";

                return new Response<List<Etiquette>>(resultOutput, response.Message);
            }
            catch (Exception ex)
            {
                return new Response<List<Etiquette>>("Résultats non trouvées.");
            }
        }

        public async Task<Response<string>> CreateEtiquette(string BaseUrl_API, CreateEtiquetteModel model)
        {
            try
            {
                var body = @$"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                              <SOAP-ENV:Header>
                              <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                              <Authentification>
                              <Username>{model.username}</Username>
                              <Password>{model.password}</Password>
                              <Domain>DEFAULT</Domain>
                              <MethodName>GWSPrepareEtiquettes</MethodName>
                              </Authentification>
                              <Context>
                              <Classe>10</Classe>
                              <Site>{model.site}</Site>
                              <MerchStructID>1</MerchStructID>
                              <CommercialNetworkID>1</CommercialNetworkID>
                              <Language>FR</Language>
                              </Context>
                              </Parameters>
                              </SOAP-ENV:Header>
                              <SOAP-ENV:Body>
                              <Request_GWSPrepareEtiquettes xmlns=""http://www.-solutions.com/WebServices/"">
                              <GWSPrepareEtiquettes>
                              <data>";
                foreach (var item in model.listeArticles)
                {
                    body += @$"<etiquette>
                                  <codeEtiquette>{item.codeEtiquette}</codeEtiquette>
                                  <numberOfEtiquettes>{item.numberOfEtiquettes}</numberOfEtiquettes>
                                  <cinr>{item.articleCinr}</cinr>
                                  <cinv>{item.articleCinv}</cinv>
                                  <ean>{item.barCode}</ean>
                                  <formatOfEtiquettes>{item.formatOfEtiquettes}</formatOfEtiquettes>
                                </etiquette>";
                }
                body += @$"</data>
                              </GWSPrepareEtiquettes>
                              </Request_GWSPrepareEtiquettes>
                              </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";

                var response = await RESTHepler.Run<CreateEtiquetteResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSPrepareEtiquettes.data.LotNo;

                //resultOutput.imageUrl = CurrentBaseUrl + "/api/download/" + model.ean;
                //resultOutput.imageUrl = @$"http://192.168.99.96:8082/eretail/{model.ean}.png";

                return new Response<string>(resultOutput, response.Message);
            }
            catch (Exception ex)
            {
                return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public async Task<Response<string>> Imprimertiquette(string ssh_serveur, string ssh_username, string ssh_password, ImprimerEtiquetteModel model)
        {
            try
            {
                SshClient ssh = new SshClient(ssh_serveur, ssh_username, ssh_password);
                ssh.Connect();
                bool conn = ssh.IsConnected;
                if (conn)
                {
                    var cmd = ssh.RunCommand($@"/exec/products/gcent/prod/LIFE/HATIM/HAETISERV {model.site} {model.lot} {model.format_type}");
                    var result = cmd.Result;
                    ssh.Disconnect();
                    ssh.Dispose();
                    return new Response<string>(result, "Success.");
                }
                else
                {
                    return new Response<string>("Problème de connexion.");
                }

            }
            catch 
            {
                return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }


    }
}
