using Shared.Models.IN;
using Shared.Models.REST;
using Shared.Models;
using System.Threading.Tasks;
using Shared.Models.OUT_.CessionInterRayonsResponse;
using Shared.Models.OUT_.GetInfosArticleCessionInterRayonsResponse;
using Shared.Models.OUT_.GetInfosArticleDestinataireCassionInterRayonsResponse;
using Shared.Models.OUT_;
using Shared.Models.OUT_.ValiderCessionInterRayonsResponse;
using Shared.Models.OUT.GetSequenceNumResponse;

namespace BLL
{
    public class CessionInterRayonsService : BaseService
    {
        public async Task<Response<Header>> Init(string BaseUrl_API, InitCessionInterRayonsModel model)
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
                                              <MethodName>GWSCessIntRayInit</MethodName>
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
                                      <Request_GWSCessIntRayInit xmlns=""http://www.-solutions.com/WebServices/"">
                                          <Description/>
                                      </Request_GWSCessIntRayInit>
                                  </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<CessionInterRayonsResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSCessIntRayInit.Header;


                return new Response<Header>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<Header>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public async Task<Response<ArticleGetInfosArticleCessionInterRayons>> GetInfosArtcileOriginal(string BaseUrl_API, GetInfosArticleOriginalCassionInterRayonsModel model)
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
                                              <MethodName>GWSCessIntRayValCodeO</MethodName>
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
                                      <Request_GWSCessIntRayValCodeO xmlns=""http://www.-solutions.com/WebServices/"">
                                          <Description>
                                              <Orig>
                                                  <Code>{model.code_orig}</Code>
                                              </Orig>
                                              <Dest>
                                                  <Code/>
                                                  <Artcomp/>
                                                  <Listes Count=""0""/>
                                              </Dest>
                                              <SiteGereEnStock>{model.site_gere_en_stock}</SiteGereEnStock>
                                          </Description>
                                      </Request_GWSCessIntRayValCodeO>
                                  </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<GetInfosArticleOriginalCessionInterRayonsResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSCessIntRayValCodeO.Article;


                return new Response<ArticleGetInfosArticleCessionInterRayons>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<ArticleGetInfosArticleCessionInterRayons>("Article inconnu.");
            }
        }

        public async Task<Response<ArticleGetInfosArticleDestinataireCassionInterRayons>> GetInfosArtcileDestinataire(string BaseUrl_API, GetInfosArticleDestinataireCassionInterRayonsModel model)
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
                                              <MethodName>GWSCessIntRayValCodeD</MethodName>
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
                                      <Request_GWSCessIntRayValCodeD xmlns=""http://www.-solutions.com/WebServices/"">
                                          <Description>
                                              <Dest>
                                                  <Code>{model.code_dest}</Code>
                                              </Dest>
                                              <Orig>
                                                  <Code>{model.code_orig}</Code>
                                                  <Artcomp>{model.artcomp}</Artcomp>
                                                  <Listes Count=""0""/>
                                              </Orig>
                                          </Description>
                                      </Request_GWSCessIntRayValCodeD>
                                  </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<GetInfosArticleDestinataireCassionInterRayonsResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSCessIntRayValCodeD.Article;


                return new Response<ArticleGetInfosArticleDestinataireCassionInterRayons>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<ArticleGetInfosArticleDestinataireCassionInterRayons>("Article inconnu.");
            }
        }


        public async Task<Response<CessionValiderCessionInterRayonsResponse>> Valider(string BaseUrl_API, ValiderCessionInterRayonsModel model)
        {
            try
            {
                #region Get new Groupe numbre 
                var bodyGroupeNumbre = $@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                                               <SOAP-ENV:Header>
                                                   <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                                                       <Authentification>
                                                           <Username>{model.username}</Username>
                                                           <Password>{model.password}</Password>
                                                           <Domain>DEFAULT</Domain>
                                                           <MethodName>PDAGetSequence</MethodName>
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
                                                   <Request_PDAGetSequence xmlns=""http://www.-solutions.com/WebServices/"">
                                                       <Description/>
                                                   </Request_PDAGetSequence>
                                               </SOAP-ENV:Body>
                                           </SOAP-ENV:Envelope>";
                var responseGroupeNumbre = await RESTHepler.Run<GetSequenceNumResponse>(BaseUrl_API, bodyGroupeNumbre);
                var new_sequence = responseGroupeNumbre.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAGetSequence.sequence;
                #endregion

                #region Insert Products With API
                var body = @$"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                            <SOAP-ENV:Header>
                                <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                                    <Authentification>
                                        <Username>{model.username}</Username>
                                        <Password>{model.password}</Password>
                                        <Domain>DEFAULT</Domain>
                                        <MethodName>GWSCessIntRayValidate</MethodName>
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
                                <Request_GWSCessIntRayValidate xmlns=""http://www.-solutions.com/WebServices/"">
                                    <Description>
                                        <Cessions>";
                foreach (var item in model.list_articles)
                {
                    body += @$" <Cession>
                        <Orig>
                            <Code validated=""true"">{item.orig.Code}</Code>
                            <CodeRegrpt>{new_sequence}</CodeRegrpt>
                            <Libelle>{item.orig.Libelle}</Libelle>
                            <Cinl>{item.orig.Cinl}</Cinl>
                            <Seqvl>{item.orig.Seqvl}</Seqvl>
                            <PrixVente>{item.orig.PrixVente}</PrixVente>
                            <TVACode>{item.orig.TVACode}</TVACode>
                            <TVADesc>{item.orig.TVADesc}</TVADesc>
                            <TVARate>{item.orig.TVARate}</TVARate>
                            <TVADont/>
                            <StockDispoQte>{item.orig.StockDispoQte}</StockDispoQte>
                            <StockDispoPds>{item.orig.StockDispoPds}</StockDispoPds>
                            <StockUnite>{item.orig.StockUnite}</StockUnite>
                            <Artustk>{item.orig.Artustk}</Artustk>
                            <Arlpmoy>{item.orig.Arlpmoy}</Arlpmoy>
                            <Artcomp>{item.orig.Artcomp}</Artcomp>
                            <Qte>{item.orig.Qte}</Qte>
                            <Poids/>
                            <Listes Count=""0""/>
                        </Orig>
                        <Dest>
                            <Code validated=""true"">{item.dest.Code}</Code>
                            <Libelle>{item.dest.Libelle}</Libelle>
                            <Cinl>{item.dest.Cinl}</Cinl>
                            <Seqvl>{item.dest.Seqvl}</Seqvl>
                            <PrixVente>{item.dest.PrixVente}</PrixVente>
                            <TVACode>{item.dest.TVACode}</TVACode>
                            <TVADesc>{item.dest.TVADesc}</TVADesc>
                            <TVARate>{item.dest.TVARate}</TVARate>
                            <TVADont/>
                            <Artustk>{item.dest.Artustk}</Artustk>
                            <Arlpmoy>{item.dest.Arlpmoy}</Arlpmoy>
                            <Artcomp>{item.dest.Artcomp}</Artcomp>
                            <Qte>{item.dest.Qte}</Qte>
                            <Poids></Poids>
                            <Listes Count=""0""/>
                        </Dest>
                        <PrixCession>{item.prix_cession}</PrixCession>
                    </Cession>";
                }
                body += $@" </Cessions>
                                        </Description>
                                    </Request_GWSCessIntRayValidate>
                                </SOAP-ENV:Body>
                            </SOAP-ENV:Envelope>";

                var response = await RESTHepler.Run<ValiderCessionInterRayonsResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSCessIntRayValidate.Cessions.Cession;
                #endregion

                return new Response<CessionValiderCessionInterRayonsResponse>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<CessionValiderCessionInterRayonsResponse>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }


    }
}
