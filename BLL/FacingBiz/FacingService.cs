using Shared.Models.IN;
using Shared.Models.OUT_.CessionInterRayonsResponse;
using Shared.Models.REST;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models.OUT_.FacingGetInfosArticle;
using Shared.Models.OUT_;

namespace BLL
{
    public class FacingService : BaseService
    {
        public async Task<Response<ArticleFacingGetInfosArticleResponse>> GetInfosArticle(string BaseUrl_API, FacingGetInfosArticleModel model)
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
                                              <MethodName>GWSGetArticleParam</MethodName>
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
                                      <Request_GWSGetArticleParam xmlns=""http://www.-solutions.com/WebServices/"">
                                          <GWSGetArticleParam>
                                              <barCode>
                                                  <![CDATA[{model.barCode}]]>
                                              </barCode>
                                          </GWSGetArticleParam>
                                      </Request_GWSGetArticleParam>
                                  </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<FacingGetInfosArticleResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSGetArticleParam.DATA.article;

                return new Response<ArticleFacingGetInfosArticleResponse>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<ArticleFacingGetInfosArticleResponse>("Article inconnu.");
            }
        }

        public async Task<Response<string>> UpdateInfosArticle(string BaseUrl_API, FacingUpdateInfosArticleModel model)
        {
            try
            {
                #region Ns1GWSUpdateContenance
                var bodyNs1GWSUpdateContenance = @$"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                                  <SOAP-ENV:Header>
                                      <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                                          <Authentification>
                                              <Username>{model.username}</Username>
                                              <Password>{model.password}</Password>
                                              <Domain>DEFAULT</Domain>
                                              <MethodName>GWSUpdateContenance</MethodName>
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
                                      <Request_GWSUpdateContenance xmlns=""http://www.-solutions.com/WebServices/"">
                                          <GWSUpdateContenance>
                                              <Facing>
                                                  <![CDATA[{model.facing}]]>
                                              </Facing>
                                              <Contenance>
                                                  <![CDATA[{model.contenance}]]>
                                              </Contenance>
                                              <CINV>
                                                  <![CDATA[{model.cinv}]]>
                                              </CINV>
                                          </GWSUpdateContenance>
                                      </Request_GWSUpdateContenance>
                                  </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var responseNs1GWSUpdateContenance = await RESTHepler.Run<FacingUpdateInfosArticleResponse>(BaseUrl_API, bodyNs1GWSUpdateContenance);
                var Ns1GWSUpdateContenance = responseNs1GWSUpdateContenance.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSUpdateContenance.Ns1GWSUpdateContenance;
                #endregion

                #region Ns1GWSUpdateStockPresentation
                var bodyNs1GWSUpdateStockPresentation = @$"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                                           <SOAP-ENV:Header>
                                               <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                                                   <Authentification>
                                                       <Username>{model.username}</Username>
                                                       <Password>{model.password}</Password>
                                                       <Domain>DEFAULT</Domain>
                                                       <MethodName>GWSUpdateStockPresentation</MethodName>
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
                                               <Request_GWSUpdateStockPresentation xmlns=""http://www.-solutions.com/WebServices/"">
                                                   <GWSUpdateStockPresentation>
                                                       <Stock>
                                                           <![CDATA[{model.stock}]]>
                                                       </Stock>
                                                       <CINV>
                                                           <![CDATA[{model.cinv}]]>
                                                       </CINV>
                                                       <NivDef>
                                                           <![CDATA[{model.nivdef}]]>
                                                       </NivDef>
                                                   </GWSUpdateStockPresentation>
                                               </Request_GWSUpdateStockPresentation>
                                           </SOAP-ENV:Body>
                                       </SOAP-ENV:Envelope>";
                var responseNs1GWSUpdateStockPresentation = await RESTHepler.Run<UpdateFacingInfosStockPresArticleResponse>(BaseUrl_API, bodyNs1GWSUpdateStockPresentation);
                var Ns1GWSUpdateStockPresentation = responseNs1GWSUpdateStockPresentation.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSUpdateStockPresentation.Ns1GWSUpdateStockPresentation;
                #endregion

                if (Ns1GWSUpdateContenance != null && Ns1GWSUpdateStockPresentation != null)
                {
                    return new Response<string>("La mise à jour des paramètres s'est terminée avec succès.", "Success");
                }
                else
                {
                    return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                }
            }
            catch
            {
                return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
    }
}
