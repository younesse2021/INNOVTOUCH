using Shared.Models;
using Shared.Models.IN;
using Shared.Models.OUT_;
using Shared.Models.OUT_.CasseFrais;
using Shared.Models.OUT_.CreateCasseFraisResponse;
using Shared.Models.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CasseFraisBiz : BaseService
    {
        public async Task<Response<Article>> ArticleInfos(string BaseUrl_Image, string BaseUrl_API, GetArticleInfosCasseFraisModel model)
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
                               <MethodName>GWSGetArticleCasseFrais</MethodName>
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
                               <Request_GWSGetArticleCasseFrais xmlns=""http://www.-solutions.com/WebServices/"">
                               <Description>
                               <ArticleCode>{model.ean}</ArticleCode>
                               </Description>
                               </Request_GWSGetArticleCasseFrais>
                               </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<InfosArticleCasseFraisResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSGetArticleCasseFrais.Article;
                //resultOutput.imageUrl = @$"{BaseUrl_Image}/images-articles-msm-resize/{model.ean}.jpg";

                return new Response<Article>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<Article>("Article inconnu.");
            }
        }

        public async Task<Response<DATA>> CreateCasseFrais(string BaseUrl_API, CreateCasseFraisModel model)
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
                                      <MethodName>GWSSetArticlesCasseFraisMarj</MethodName>
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
                                      <Request_GWSSetArticlesCasseFraisMarj xmlns=""http://www.-solutions.com/WebServices/"">
                              <Description>
                              <Record>";
                foreach (var item in model.listeArticles)
                {
                    body += @$"<Article Changed=""0"">
                                      <Code><![CDATA[{item.Code}]]></Code>
                                      <TypeCode><![CDATA[{item.TypeCode}]]></TypeCode>
                                      <LiblCaisseC><![CDATA[{item.LiblCaisseC}]]></LiblCaisseC>
                                      <LiblCaisseL><![CDATA[{item.LiblCaisseL}]]></LiblCaisseL>
                                      <Cinv><![CDATA[{item.Cinv}]]></Cinv>
                                      <Cinr><![CDATA[{item.Cinr}]]></Cinr>
                                      <Source><![CDATA[{item.Source}]]></Source>
                                      <PrixVente><![CDATA[{item.PrixVente}]]></PrixVente>
                                      <sitgbal><![CDATA[{item.sitgbal}]]></sitgbal>
                                      <Grat><![CDATA[{item.Grat}]]></Grat>
                                      <WeightOpFrais><![CDATA[{item.WeightOpFrais}]]></WeightOpFrais>
                                      <EtiFormatCode>{item.EtiFormatCode}</EtiFormatCode>
                                      <EtiFormatDesc>{item.EtiFormatDesc}</EtiFormatDesc>
                                      <EtiFormatNbr>{item.EtiFormatNbr}</EtiFormatNbr>
                                      <Remise>{item.Remise}</Remise>
                                      <PrixCasseFrais>{item.PrixCasseFrais}</PrixCasseFrais>
                              </Article>";
                }
                body += @$"</Record>
                           <OperationCode>0</OperationCode>
                           </Description>
                           </Request_GWSSetArticlesCasseFraisMarj>
                           </SOAP-ENV:Body>
                           </SOAP-ENV:Envelope>";

                var response = await RESTHepler.Run<CreateCasseFraisResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSSetArticlesCasseFraisMarj.DATA;

                return new Response<DATA>(resultOutput, response.Message);
            }
            catch (Exception ex)
            {
                return new Response<DATA>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
    }
}
