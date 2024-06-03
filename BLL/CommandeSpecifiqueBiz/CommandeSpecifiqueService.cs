using Shared.Models;
using Shared.Models.IN.CommandeSpecifique;
using Shared.Models.OUT_;
using Shared.Models.OUT_.CommandeSpecifique;
using Shared.Models.OUT_.GetLotsCmdPdaResponse;
using Shared.Models.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CommandeSpecifiqueService : BaseService
    {
        public async Task<Response<GetLotsCmdPdaResponse>> GetLots(string BaseUrl_API, GetLotsCmdPdaModel model)
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
                                <MethodName>mjGWSgetLotsCmdPda</MethodName>
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
                        <Request_mjGWSgetLotsCmdPda xmlns=""http://www.-solutions.com/WebServices/"">
                            <Description/>
                        </Request_mjGWSgetLotsCmdPda>
                    </SOAP-ENV:Body>
                </SOAP-ENV:Envelope>";


                try
                {
                    var response = await RESTHepler.Run<GetCmdLotsResponseGetLotsCmdPdaResponse>(BaseUrl_API, body);
                    var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_mjGWSgetLotsCmdPda;
                    return new Response<GetLotsCmdPdaResponse>(resultOutput, response.Message);

                }
                catch (Exception)
                {

                    var response = await RESTHepler.Run<GetCmdLotsResponseGetLotsCmdPdaResponse2>(BaseUrl_API, body);
                    var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_mjGWSgetLotsCmdPda;

                    var resultOutput2 = new GetLotsCmdPdaResponse()
                    {
                        DATA = new DATAGetLotsCmdPdaResponse()
                        {
                            lot = new List<GetLotsResponseGetLotsCmdPdaResponse>() { resultOutput.DATA.lot}
                        }
                    };

                    return new Response<GetLotsCmdPdaResponse>(resultOutput2, response.Message);
                }
            }
            catch (Exception ex)
            {
                return new Response<GetLotsCmdPdaResponse>(ex.ToString());
            }
        }



        public async Task<Response<ArticleGWSInfoCmdPdaResponse>> GWSInfoCmd(string BaseUrl_API, GWSInfoCmdPdaModel model)
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
                                              <MethodName>mjGWSInfoCmdPda</MethodName>
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
                                      <Request_mjGWSInfoCmdPda xmlns=""http://www.-solutions.com/WebServices/"">
                                          <mjGWSInfoCmdPda>
                                              <CINV>
                                                  <![CDATA[{model.CINV}]]>
                                              </CINV>
                                              <MODE>
                                                  <![CDATA[{model.MODE}]]>
                                              </MODE>
                                              <NLOT>
                                                  <![CDATA[{model.NLOT}]]>
                                              </NLOT>
                                          </mjGWSInfoCmdPda>
                                      </Request_mjGWSInfoCmdPda>
                                  </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<ArticleResponseGWSInfoCmdPdaResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_mjGWSInfoCmdPda.article;

                return new Response<ArticleGWSInfoCmdPdaResponse>(resultOutput, "success");
            }
            catch (Exception ex)
            {
                //return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                return new Response<ArticleGWSInfoCmdPdaResponse>(ex.ToString());
            }
        }





        public async Task<Response<SaveCmdPdaResponseSaveCmdPdaResponse>> SaveCmda(string BaseUrl_API, SaveCmdPdaModel model)
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
                                                <MethodName>mjGWSsaveCmdPda</MethodName>
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
                                        <Request_mjGWSsaveCmdPda xmlns=""http://www.-solutions.com/WebServices/"">
                                            <article>
                                                <nolot>{model.article.nolot}</nolot>
                                                <cinr>{model.article.cinr}</cinr>
                                                <cinl>{model.article.cinl}</cinl>
                                                <orderable>{model.article.orderable}</orderable>
                                                <label>{model.article.label}</label>
                                                <nCmd>{model.article.nCmd}</nCmd>
                                                <existCmd>{model.article.existCmd}</existCmd>
                                                <existInLot>{model.article.existInLot}</existInLot>
                                                <stockNormal>{model.article.stockNormal}</stockNormal>
                                                <stonbrjour>{model.article.stonbrjour}</stonbrjour>
                                                <encoursCmd>{model.article.encoursCmd}</encoursCmd>
                                                <encoursjour>{model.article.encoursjour}</encoursjour>
                                                <stockEntrepot>{model.article.stockEntrepot}</stockEntrepot>
                                                <moyhebvte>{model.article.moyhebvte}</moyhebvte>
                                                <vtedersem>{model.article.vtedersem}</vtedersem>
                                                <qteProposee>{model.article.qteProposee}</qteProposee>
                                                <cinv>{model.article.cinv}</cinv>
                                                <etat>{model.article.etat}</etat>
                                                <etatlibl>{model.article.etatlibl}</etatlibl>
                                                <orderableUnit>{model.article.orderableUnit}</orderableUnit>
                                                <orderableUnitLabel>{model.article.orderableUnitLabel}</orderableUnitLabel>
                                                <UAUVC>{model.article.UAUVC}</UAUVC>
                                                <SEQVL>{model.article.SEQVL}</SEQVL>
                                                <EAN>{model.article.EAN}</EAN>
                                                <refreshFunction>{model.article.refreshFunction}</refreshFunction>
                                            </article>
                                        </Request_mjGWSsaveCmdPda>
                                    </SOAP-ENV:Body>
                                </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<SaveCmdPdaResponseResponseSaveCmdPda>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_mjGWSsaveCmdPda;

                return new Response<SaveCmdPdaResponseSaveCmdPdaResponse>(resultOutput, "success");
            }
            catch (Exception ex)
            {
                //return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                return new Response<SaveCmdPdaResponseSaveCmdPdaResponse>(ex.ToString());
            }
        }



        public async Task<Response<ResponsePDAValiderArticlePdaResponse>> GWSValiderArticleCmd(string BaseUrl_API, ValiderArticlePdaModel model)
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
                                                        <MethodName>mjGWSvaliderArticleCmd</MethodName>
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
                                                <Request_mjGWSvaliderArticleCmd xmlns=""http://www.-solutions.com/WebServices/"">
                                                    <mjGWSvaliderArticleCmd>
                                                        <nolot>
                                                            <![CDATA[{model.nolot}]]>
                                                        </nolot>
                                                    </mjGWSvaliderArticleCmd>
                                                </Request_mjGWSvaliderArticleCmd>
                                            </SOAP-ENV:Body>
                                        </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<ArticleResponseValiderArticlePdaResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_mjGWSvaliderArticleCmd;

                return new Response<ResponsePDAValiderArticlePdaResponse>(resultOutput, "success");
            }
            catch (Exception ex)
            {
                return new Response<ResponsePDAValiderArticlePdaResponse>(ex.StackTrace);
                //return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                
            }
        }

    }
}
