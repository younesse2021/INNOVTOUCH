using Newtonsoft.Json;
using Shared.Models;
using Shared.Models.IN;
using Shared.Models.OUT;
using Shared.Models.OUT.AddOrUpdateControlePrixResponse;
using Shared.Models.OUT.ControlePrixCloseResponse;
using Shared.Models.OUT.ControlePrixEtiquetteResponse;
using Shared.Models.OUT.DefaultNbrEtiControlePrixResponse;
using Shared.Models.OUT.GenerateCodeControlePrixObjectResponse;
using Shared.Models.OUT.GenerateCodeControlePrixResponse;
using Shared.Models.OUT.InfoArticleControlePrixResponse;
using Shared.Models.OUT.ListControlePrixResponse;
using Shared.Models.OUT_;
using Shared.Models.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ControlePrixService : BaseService
    {
        public async Task<Response<Controls>> ListControlePrix(string BaseUrl_API, ListControlePrixModel model)
        {
            try
            {
                var resultOutput = new Controls();
                var _controls = new List<Control>();
                var body = @$"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                              <SOAP-ENV:Header>
                              <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                              <Authentification>
                              <Username>{model.username}</Username>
                              <Password>{model.password}</Password>
                              <Domain>DEFAULT</Domain>
                              <MethodName>PDAgetInfoControlePrix</MethodName>
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
                              <Request_PDAgetInfoControlePrix xmlns=""http://www.-solutions.com/WebServices/"">
                              <Description>
                              <Informations>
                              <CODE/>
                              <LIBELLE/>
                              <DATEPREPA/>
                              <DATEEFFECTIVE/>
                              </Informations>
                              </Description>
                              </Request_PDAgetInfoControlePrix>
                              </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var json = await RESTHepler.RunString(BaseUrl_API, body);

                try
                {
                    var response = JsonConvert.DeserializeObject<ListControlePrixResponse>(json);
                    resultOutput = response.SOAPENVEnvelope.SOAPENVBody.Response_PDAgetInfoControlePrix.controls;
                    resultOutput.control = resultOutput.control.OrderByDescending(q => Convert.ToDateTime(q.preparationDate.CdataSection)).ToList();

                }
                catch
                {
                    var response = JsonConvert.DeserializeObject<ListControlePrixObjectResponse>(json);
                    if (response.SOAPENVEnvelope.SOAPENVBody.Response_PDAgetInfoControlePrix.controls != null)
                    {
                        _controls.Add(response.SOAPENVEnvelope.SOAPENVBody.Response_PDAgetInfoControlePrix?.controls?.control);
                        resultOutput.control = _controls.OrderByDescending(q => Convert.ToDateTime(q.preparationDate.CdataSection)).ToList();
                    }
                }
                if (resultOutput != null)
                {
                    return new Response<Controls>(resultOutput, "Success.");
                }
                else
                {
                    return new Response<Controls>(resultOutput, "Il n'y a pas de controle de prix.");
                }

            }
            catch
            {
                return new Response<Controls>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public async Task<Response<ControlPrixInfo>> GetInfoOrGenerateControlePrix(string BaseUrl_API, GetInfoOrGenerateControlePrixModel model)
        {
            try
            {
                var resultOutput = new ControlPrixInfo();
                var _articles = new List<ArticlePrixInfo>();
                var _article = new Articles();
                var body = @$"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                               <SOAP-ENV:Header>
                               <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                               <Authentification>
                               <Username>{model.username}</Username>
                               <Password>{model.password}</Password>
                               <Domain>DEFAULT</Domain>
                               <MethodName>PDAControlePrixPreparer</MethodName>
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
                               <Request_PDAControlePrixPreparer xmlns=""http://www.-solutions.com/WebServices/"">
                               <Description>
                               <controlNo>{model.controlNo}</controlNo>
                               </Description>
                               </Request_PDAControlePrixPreparer>
                               </SOAP-ENV:Body>
                               </SOAP-ENV:Envelope>";
                var json = await RESTHepler.RunString(BaseUrl_API, body);
                try
                {
                    var response = JsonConvert.DeserializeObject<GenerateCodeControlePrixResponse>(json);
                    resultOutput = response.SOAPENVEnvelope.SOAPENVBody.Response_PDAControlePrixPreparer.control;
                }
                catch
                {
                    var response = JsonConvert.DeserializeObject<GenerateCodeControlePrixObjectResponse>(json);
                    resultOutput.controlNo = response.SOAPENVEnvelope.SOAPENVBody.Response_PDAControlePrixPreparer.control.controlNo;
                    _articles.Add(response.SOAPENVEnvelope.SOAPENVBody.Response_PDAControlePrixPreparer.control.articles.article);
                    _article.article = _articles;
                    resultOutput.articles = _article;
                }

                return new Response<ControlPrixInfo>(resultOutput, "Success.");
            }
            catch (Exception ex)
            {
                return new Response<ControlPrixInfo>(ex.ToString());
            }
        }

        public async Task<Response<string>> EtiquetteControlePrix(string BaseUrl_API, EtiquetteControlePrixModel model)
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
                              <MethodName>PDAControlePrixEtiquette</MethodName>
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
                              <Request_PDAControlePrixEtiquette xmlns=""http://www.-solutions.com/WebServices/"">
                              <Description>
                              <ControlNo>{model.controlNo}</ControlNo>
                              </Description>
                              </Request_PDAControlePrixEtiquette>
                              </SOAP-ENV:Body></SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<ControlePrixEtiquetteResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAControlePrixEtiquette.LotNo;

                return new Response<string>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public async Task<Response<bool>> CloseControlePrix(string BaseUrl_API, CloseControlePrixModel model)
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
                               <MethodName>PDAControlePrixCloseControl</MethodName>
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
                               <Request_PDAControlePrixCloseControl xmlns=""http://www.-solutions.com/WebServices/"">
                               <Description>
                               <controlNo>{model.controlNo}</controlNo>
                               </Description>
                               </Request_PDAControlePrixCloseControl>
                               </SOAP-ENV:Body>
                               </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<ControlePrixCloseResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAControlePrixCloseControl.Blank;

                return new Response<bool>(true, response.Message);
            }
            catch
            {
                return new Response<bool>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public async Task<Response<ArticleInfo>> InfoArticleControlePrix(string BaseUrl_API, InfoArticleControlePrixModel model)
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
                              <MethodName>PDAControlePrixGetArticle</MethodName>
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
                              <Request_PDAControlePrixGetArticle xmlns=""http://www.-solutions.com/WebServices/"">
                              <Description>
                              <TillCode>{model.codeArticle}</TillCode>
                              </Description>
                              </Request_PDAControlePrixGetArticle>
                              </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<InfoArticleControlePrixResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAControlePrixGetArticle.Detail.article;

                return new Response<ArticleInfo>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<ArticleInfo>("Article inconnu.");
            }
        }

        public async Task<Response<Default>> DefaultNbrEtiControlePrix(string BaseUrl_API, DefaultNbrEtiControlePrixModel model)
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
                              <MethodName>PDAControlePrixGetDefaultNbrEti</MethodName>
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
                              <Request_PDAControlePrixGetDefaultNbrEti xmlns=""http://www.-solutions.com/WebServices/"">
                              <Description>
                              <cinr>{model.cinr}</cinr>
                              </Description>
                              </Request_PDAControlePrixGetDefaultNbrEti>
                              </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<DefaultNbrEtiControlePrixResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAControlePrixGetDefaultNbrEti.Default;

                return new Response<Default>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<Default>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public async Task<Response<bool>> AddOrUpdateControlePrix(string BaseUrl_API, AddOrUpdateControlePrixModel model)
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
                                          <MethodName>PDAControlePrixSaveControl</MethodName>
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
                                  <Request_PDAControlePrixSaveControl xmlns=""http://www.-solutions.com/WebServices/"">
                                      <Description>
                                          <control>
                    <controlNo existintable=""{model.existintable}"">{model.controlNo}</controlNo>
                    <articles>";
                foreach (var article in model.listeArticles)
                {
                    var lib_article = article.TillDesc.Replace('"', '´');
                    body += $@"
                        <article changed=""{article.changed}"" existintable=""{article.existintable}"" known=""1"">
                            <TillCode>
                                <![CDATA[{article.TillCode}]]>            
                            </TillCode>
                            <CaisseCode>
                                <![CDATA[{article.CaisseCode}]]>            
                            </CaisseCode>
                            <TillDesc>
                                <![CDATA[{lib_article}]]>            
                            </TillDesc>
                            <salePriceFile>
                                <![CDATA[{article.CaissePrice}]]>            
                            </salePriceFile>
                            <salePriceInserted>{article.RayonPrice}</salePriceInserted>
                            <LabelNumber>{article.EtiqNumber}</LabelNumber>
                            <SeqNum>
                                <![CDATA[{article.SeqNum}]]>            
                            </SeqNum>
                            <intCodeArticleSale>
                                <![CDATA[{article.intCodeArticleSale}]]>            
                            </intCodeArticleSale>
                            <cinr>
                                <![CDATA[{article.cinr}]]>            
                            </cinr>
                        </article>                         
                    ";
                }

                body += $@"</articles>
                                            </control>
                                        </Description>
                                    </Request_PDAControlePrixSaveControl>
                                </SOAP-ENV:Body>
                            </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<AddOrUpdateControlePrixResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAControlePrixSaveControl.blank;

                return new Response<bool>(true, response.Message);
            }
            catch (Exception ex)
            {
                return new Response<bool>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
    }
}
