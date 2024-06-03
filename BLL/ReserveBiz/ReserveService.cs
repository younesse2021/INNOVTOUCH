using Shared.Models;
using Shared.Models.IN;
using Shared.Models.IN.ReserveIn;
using Shared.Models.IN.ReserveModel;
using Shared.Models.OUT_.CheckPaletteResponse;
using Shared.Models.OUT_.CloturerPaletteResponse;
using Shared.Models.OUT_.CreerLotPreparationResponse;
using Shared.Models.OUT_.DescendrePaletteRacksResponse;
using Shared.Models.OUT_.GenererNewNumLotPreResponse;
using Shared.Models.OUT_.GetBornesZoneEmplResponse;
using Shared.Models.OUT_.GetContenuPaletteResponse;
using Shared.Models.OUT_.GetInfoArticleRsvResponse;
using Shared.Models.OUT_.Reserve;
using Shared.Models.OUT_.Reserve.GetArticlePaletteResponse;
using Shared.Models.OUT_.Reserve.MajDetailPaletteResponse;
using Shared.Models.OUT_.StockerPaletteResponse;
using Shared.Models.OUT_.ViderPaletteResponse;
using Shared.Models.REST;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class ReserveService : BaseService
    {
        public async Task<Response<InfoPaletteGenerateNewNumPaletteResponse>> GenererNumeroPalette(string BaseUrl_API, GenerateNewNumPaletteModel model)
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
                                                <MethodName>PDARsvGenererNewNumPaletteMarj</MethodName>
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
                                        <Request_PDARsvGenererNewNumPaletteMarj xmlns=""http://www.-solutions.com/WebServices/"">
                                            <Description/>
                                        </Request_PDARsvGenererNewNumPaletteMarj>
                                    </SOAP-ENV:Body>
                                </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<GenerateNewNumPaletteResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvGenererNewNumPaletteMarj.InfoPalette;

                return new Response<InfoPaletteGenerateNewNumPaletteResponse>(resultOutput, "success");
            }
            catch (Exception ex)
            {
                //return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                return new Response<InfoPaletteGenerateNewNumPaletteResponse>(ex.ToString());
            }
        }



        public async Task<Response<ArticleeGetArticlePaletteResponse>> GetArticlePalette(string BaseUrl_API, GetArticlePaletteModel model)
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
                                                <MethodName>PDARsvGetArticlePaletteMarj</MethodName>
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
                                        <Request_PDARsvGetArticlePaletteMarj xmlns=""http://www.-solutions.com/WebServices/"">
                                            <Description>
                                                <NumPalette>{model.NumPalette}</NumPalette>
                                                <CintPalette>{model.CintPalette}</CintPalette>
                                                <ArticleCode>{model.ArticleCode}</ArticleCode>
                                            </Description>
                                        </Request_PDARsvGetArticlePaletteMarj>
                                    </SOAP-ENV:Body>
                                </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<GetArticlePaletteResponseGetArticlePaletteResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvGetArticlePaletteMarj.Article;

                return new Response<ArticleeGetArticlePaletteResponse>(resultOutput, "success");
            }
            catch (Exception ex)
            {
                return new Response<ArticleeGetArticlePaletteResponse>("Erreur s’est produite lors de l’exécution de l'opération.");
                //return new Response<ArticleeGetArticlePaletteResponse>(ex.ToString());
            }
        }


        public async Task<Response<ResponsePDARsvMajDetailPaletteMarjMajDetailPaletteResponse>> MajDetailPalete(string BaseUrl_API, MajDetailPaletteModel model)
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
                <MethodName>PDARsvMajDetailPaletteMarj</MethodName>
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
        <Request_PDARsvMajDetailPaletteMarj xmlns=""http://www.-solutions.com/WebServices/"">
            <Description>
                <InfoPalette>
                    <NumPalette>{model.NumPalette}</NumPalette>
                    <CintPalette>{model.CintPalette}</CintPalette>
                    <Zone>{model.Zone}</Zone>
                    <EmplacementDto>{model.Emplacement}</EmplacementDto>
                    <EtatPalette>{model.EtatPalette}</EtatPalette>
                    <NbArticles>{model.NbArticles}</NbArticles>
                </InfoPalette>;
                <Record>
                    <Article Changed=""0"">
                        <CodeArticle>{model.CodeArticle}</CodeArticle>
                        <LiblCaisseC>{model.LiblCaisseC}</LiblCaisseC>
                        <LiblCaisseL>{model.LiblCaisseL}</LiblCaisseL>
                        <Cinv>{model.Cinv}</Cinv>
                        <Cinr>{model.Cinr}</Cinr>
                        <Ustk>{model.Ustk}</Ustk>
                        <PdsMoyen>{model.PdsMoyen}</PdsMoyen>
                        <QteStock>{model.QteStock}</QteStock>
                        <PdsStock>{model.PdsStock}</PdsStock>
                        <QtePalette>{model.QtePalette}</QtePalette>
                        <PdsPalette>{model.PdsPalette}</PdsPalette>
                        <QteAjoute>{model.QteAjoute}</QteAjoute>
                        <PdsAjoute>{model.PdsAjoute}</PdsAjoute>
                        <QteRetire>{model.QteRetire}</QteRetire>
                        <PdsRetire>{model.PdsRetire}</PdsRetire>
                        <NewQtePalette>{model.NewQtePalette}</NewQtePalette>
                        <NewPdsPalette>{model.NewPdsPalette}</NewPdsPalette>
                    </Article>
                </Record>
            </Description>
        </Request_PDARsvMajDetailPaletteMarj>
    </SOAP-ENV:Body>
</SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<MajDetailPaletteResponseMajDetailPaletteResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvMajDetailPaletteMarj;

                return new Response<ResponsePDARsvMajDetailPaletteMarjMajDetailPaletteResponse>(resultOutput, "success");
            }
            catch (Exception ex)
            {
                //return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                return new Response<ResponsePDARsvMajDetailPaletteMarjMajDetailPaletteResponse>(ex.ToString());
            }
        }


        public async Task<Response<ResponseGetContenuPaletteGetContenuPaletteResponse>> GetContenuPalette(string BaseUrl_API, GetContenuPaletteModel model)
        {
            try
            {
                var body = @$"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                        <SOAP-ENV:Header>
                            <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                                <Authentification>
                                    <Username>{model.Username}</Username>
                                    <Password>{model.Password}</Password>
                                    <Domain>DEFAULT</Domain>
                                    <MethodName>PDARsvGetContenuPaletteMarj</MethodName>
                                    </Authentification>
                                    <Context>
                                    <Classe>10</Classe>
                                    <Site>{model.Site}</Site>
                                    <MerchStructID>1</MerchStructID>
                                    <CommercialNetworkID>1</CommercialNetworkID>
                                    <Language>FR</Language>
                                </Context>
                                </Parameters>
                                </SOAP-ENV:Header>
                                <SOAP-ENV:Body>
                                <Request_PDARsvGetContenuPaletteMarj xmlns=""http://www.-solutions.com/WebServices/"">
                                <Description>
                                    <InfoPalette>
                                        <NumPalette>{model.NumPalette}</NumPalette>
                                        <CintPalette>{model.CintPalette}</CintPalette>
                                        <Zone>{model.Zone}</Zone>
                                        <EmplacementDto>{model.Emplacement}</EmplacementDto>
                                        <EtatPalette>{model.EtatPalette}</EtatPalette>
                                        <NbArticles>{model.NbArticles}</NbArticles>
                                    </InfoPalette>
                                </Description>
                            </Request_PDARsvGetContenuPaletteMarj>
                        </SOAP-ENV:Body>
                    </SOAP-ENV:Envelope>";

                try
                {
                    var response = await RESTHepler.Run<GetContenuPaletteResponseGetContenuPaletteResponse>(BaseUrl_API, body);
                    var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvGetContenuPaletteMarj;
                    return new Response<ResponseGetContenuPaletteGetContenuPaletteResponse>(resultOutput, response.Message);

                }
                catch (Exception)
                {

                    var response = await RESTHepler.Run<GetContenuPaletteResponseGetContenuPaletteResponse2>(BaseUrl_API, body);
                    var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvGetContenuPaletteMarj;

                    var resultOutput2 = new ResponseGetContenuPaletteGetContenuPaletteResponse()
                    {
                        DATA = new DATAGetContenuPaletteResponse()
                        {
                            Articles = new List<listArticlesGetContenuPaletteResponse>() { resultOutput.DATA.Articles }
                        }
                    };

                    return new Response<ResponseGetContenuPaletteGetContenuPaletteResponse>(resultOutput2, response.Message);
                }
            }
            catch (Exception ex)
            {
                return new Response<ResponseGetContenuPaletteGetContenuPaletteResponse>(ex.ToString());
            }
        }

        public async Task<Response<CloturerPaletteCloturerPaletteResponse>> CloturerPalette(string BaseUrl_API, CloturerPaletteModel model)
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
                                <MethodName>PDARsvCloturerPaletteMarj</MethodName>
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
                                <Request_PDARsvCloturerPaletteMarj xmlns=""http://www.-solutions.com/WebServices/"">
                                <Description>
                                <InfoPalette>
                                    <NumPalette>{model.NumPalette}</NumPalette>
                                    <CintPalette>{model.CintPalette}</CintPalette>
                                    <Zone>{model.Zone}</Zone>
                                    <EmplacementDto>{model.Emplacement}</EmplacementDto>
                                    <EtatPalette>{model.EtatPalette}</EtatPalette>
                                    <NbArticles>{model.NbArticles}</NbArticles>
                                </InfoPalette>
                            </Description>
                        </Request_PDARsvCloturerPaletteMarj>
                    </SOAP-ENV:Body>
                  </SOAP-ENV:Envelope>";



                var response = await RESTHepler.Run<GetCloturerPaletteResponseCloturerPaletteResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvCloturerPaletteMarj;

                return new Response<CloturerPaletteCloturerPaletteResponse>(resultOutput, response.Message);
            }
            catch (Exception ex)
            {
                //return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                return new Response<CloturerPaletteCloturerPaletteResponse>(ex.ToString());
            }
        }


        public async Task<Response<InfoPaletteResponse>> CheckPalette(string BaseUrl_API, CheckPaletteModel model)
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
                                        <MethodName>PDARsvCheckNumPalettExistantMarj</MethodName>
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
                                <Request_PDARsvCheckNumPalettExistantMarj xmlns=""http://www.-solutions.com/WebServices/"">
                                    <Description>
                                        <NumPalette>{model.NumPalette}</NumPalette>
                                    </Description>
                                </Request_PDARsvCheckNumPalettExistantMarj>
                            </SOAP-ENV:Body>
                        </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<CheckExistPaletteResponseCheckPaletteResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvCheckNumPalettExistantMarj;

                return new Response<InfoPaletteResponse>(resultOutput, response.Message);
            }
            catch (Exception ex)
            {
                //return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                return new Response<InfoPaletteResponse>(ex.ToString());
            }
        }


        public async Task<Response<ResponseViderPalette>> ViderPalette(string BaseUrl_API, ViderPaletteModel model)
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
                                    <MethodName>PDARsvViderPaletteMarj</MethodName>
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
                            <Request_PDARsvViderPaletteMarj xmlns=""http://www.-solutions.com/WebServices/"">
                                <Description>
                                    <NumPalette>{model.NumPalette}</NumPalette>
                                </Description>
                            </Request_PDARsvViderPaletteMarj>
                        </SOAP-ENV:Body>
                    </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<ViderPaletteResponseViderPaletteResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvViderPaletteMarj;

                return new Response<ResponseViderPalette>(resultOutput, response.Message);
            }
            catch (Exception ex)
            {
                //return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                return new Response<ResponseViderPalette>(ex.ToString());
            }
        }


        public async Task<Response<InfoZoneEmplResponseData>> GetBornesZoneEmpl(string BaseUrl_API, GetBornesZoneEmplModel model)
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
                                    <MethodName>PDARsvGetBornesZoneEmplMarj</MethodName>
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
                            <Request_PDARsvGetBornesZoneEmplMarj xmlns=""http://www.-solutions.com/WebServices/"">
                                <Description/>
                            </Request_PDARsvGetBornesZoneEmplMarj>
                        </SOAP-ENV:Body>
                    </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<GetBornesZoneEmplResponseGetBornesZoneEmplResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvGetBornesZoneEmplMarj;

                return new Response<InfoZoneEmplResponseData>(resultOutput, response.Message);
            }
            catch (Exception ex)
            {
                //return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                return new Response<InfoZoneEmplResponseData>(ex.ToString());
            }
        }


        public async Task<Response<StockerPaletteResultStockerPaletteResponse>> StockerPalette(string BaseUrl_API, StockerPaletteModel model)
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
                                    <MethodName>PDARsvStockerPaletteRacksMarj</MethodName>
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
                            <Request_PDARsvStockerPaletteRacksMarj xmlns=""http://www.-solutions.com/WebServices/"">
                                <Description>
                                    <InfoPalette>
                                        <NumPalette>{model.NumPalette}</NumPalette>
                                        <CintPalette>{model.CintPalette}</CintPalette>
                                        <Zone>{model.Zone}</Zone>
                                        <EmplacementDto>{model.Emplacement}</EmplacementDto>
                                        <EtatPalette>{model.EtatPalette}</EtatPalette>
                                        <NbArticles>{model.NbArticles}</NbArticles>
                                    </InfoPalette>
                                </Description>
                            </Request_PDARsvStockerPaletteRacksMarj>
                        </SOAP-ENV:Body>
                    </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<GetStockerPaletteResponseStockerPaletteResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvStockerPaletteRacksMarj;

                return new Response<StockerPaletteResultStockerPaletteResponse>(resultOutput, response.Message);
            }
            catch (Exception ex)
            {
                //return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                return new Response<StockerPaletteResultStockerPaletteResponse>(ex.ToString());
            }
        }


        public async Task<Response<DescendrePaletteRacksResultDescendrePaletteRacksResponse>> DescendrePaletteRacks(string BaseUrl_API, DescendrePaletteRacksModel model)
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
                                    <MethodName>PDARsvDescendrePaletteRacksMarj</MethodName>
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
                            <Request_PDARsvDescendrePaletteRacksMarj xmlns=""http://www.-solutions.com/WebServices/"">
                                <Description>
                                    <InfoPalette>
                                        <NumPalette>{model.NumPalette}</NumPalette>
                                        <CintPalette>{model.CintPalette}</CintPalette>
                                        <Zone>{model.Zone}</Zone>
                                        <EmplacementDto>{model.Emplacement}</EmplacementDto>
                                        <EtatPalette>{model.EtatPalette}</EtatPalette>
                                        <NbArticles>{model.NbArticles}</NbArticles>
                                    </InfoPalette>
                                </Description>
                            </Request_PDARsvDescendrePaletteRacksMarj>
                        </SOAP-ENV:Body>
                    </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<GetDescendrePaletteRacksResponseDescendrePaletteRacksResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvDescendrePaletteRacksMarj;

                return new Response<DescendrePaletteRacksResultDescendrePaletteRacksResponse>(resultOutput, response.Message);
            }
            catch (Exception ex)
            {
                //return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                return new Response<DescendrePaletteRacksResultDescendrePaletteRacksResponse>(ex.ToString());
            }
        }


        public async Task<Response<GenererNewNumLotPreResultGenererNewNumLotPreResponse>> GenererNewNumLotPre(string BaseUrl_API, GenererNewNumLotPreModel model)
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
                                        <MethodName>PDARsvGenererNewNumLotPrepaMarj</MethodName>
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
                                <Request_PDARsvGenererNewNumLotPrepaMarj xmlns=""http://www.-solutions.com/WebServices/"">
                                    <Description/>
                                </Request_PDARsvGenererNewNumLotPrepaMarj>
                            </SOAP-ENV:Body>
                        </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<ResponseGenererNewNumLotPreResponseGenererNewNumLotPreResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvGenererNewNumLotPrepaMarj;

                return new Response<GenererNewNumLotPreResultGenererNewNumLotPreResponse>(resultOutput, response.Message);
            }
            catch (Exception ex)
            {
                //return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                return new Response<GenererNewNumLotPreResultGenererNewNumLotPreResponse>(ex.ToString());
            }
        }

        public async Task<Response<ArticlesGetInfoArticleRsvResponse>> GetArticleInfoRsv(string BaseUrl_API, GetInfoArticleRsvModel model)
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
                                <MethodName>PDARsvGetInfoArticleReserveMarj</MethodName>
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
                        <Request_PDARsvGetInfoArticleReserveMarj xmlns=""http://www.-solutions.com/WebServices/"">
                            <Description>
                                <ArticleCode>{model.ArticleCode}</ArticleCode>
                            </Description>
                        </Request_PDARsvGetInfoArticleReserveMarj>
                    </SOAP-ENV:Body>
                </SOAP-ENV:Envelope>";  
                var response = await RESTHepler.Run<GetInfoArticleRsvResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvGetInfoArticleReserveMarj.Article;

                return new Response<ArticlesGetInfoArticleRsvResponse>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<ArticlesGetInfoArticleRsvResponse>("L'article n'appartient à aucune palette.");
            }
        }
        public async Task<Response<CreerLotPrepResultCreerLotPreparationResponse>> CreerLotPrep(string BaseUrl_API, CreerLotPreparationModel model)
        {
            try
            {
                var body = @$"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                        <SOAP-ENV:Header>
                            <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                                <Authentification>
                                    <Username>{model.Username}</Username>
                                    <Password>{model.Password}</Password>
                                    <Domain>DEFAULT</Domain>
                                    <MethodName>PDARsvCreerLotPreparationMarj</MethodName>
                                </Authentification>
                                <Context>
                                    <Classe>10</Classe>
                                    <Site>{model.Site}</Site>
                                    <MerchStructID>1</MerchStructID>
                                    <CommercialNetworkID>1</CommercialNetworkID>
                                            <Language>FR</Language>
                                        </Context>
                                    </Parameters>
                                </SOAP-ENV:Header>
                                <SOAP-ENV:Body>
                                    <Request_PDARsvCreerLotPreparationMarj xmlns=""http://www.-solutions.com/WebServices/"">
                                        <Description>
                                    <NumLot>{model.NumLot}</NumLot>
                                    <Record>
                                        <Article Changed=""0"">
                                            <CodeArticle>{model.Article.CodeArticle}</CodeArticle>
                                            <LiblCaisseC>{model.Article.LiblCaisseC}</LiblCaisseC>
                                            <LiblCaisseL>{model.Article.LiblCaisseL}</LiblCaisseL>
                                            <Cinv>{model.Article.Cinv}</Cinv>
                                            <Cinr>{model.Article.Cinr}</Cinr>
                                            <Ustk>{model.Article.Ustk}</Ustk>
                                            <PdsMoyen>{model.Article.PdsMoyen}</PdsMoyen>
                                            <QteStock>{model.Article.QteStock}</QteStock>
                                            <PdsStock>{model.Article.PdsStock}</PdsStock>
                                            <CinlPCB>{model.Article.CinlPCB}</CinlPCB>
                                            <NbrUVCparPCB>{model.Article.NbrUVCparPCB}</NbrUVCparPCB>";

                foreach (var item in model.Article.DATA.palettes)
                {
                    body += $@"<DATA>
                                      <palettes>
                                      <palette>{item.Palette}</palette>
                                      </palettes>
                                       </DATA>";
                }
                body += @$" <QteDemandeePCB>{model.Article.QteDemandeePCB}</QteDemandeePCB>
                                    <QteDemandeeUVC>{model.Article.QteDemandeeUVC}</QteDemandeeUVC>
                                    </Article>
                                    </Record>
                                    </Description>
                                    </Request_PDARsvCreerLotPreparationMarj>
                                </SOAP-ENV:Body>
                            </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<CreerLotPrepResponseCreerLotPreparationResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvCreerLotPreparationMarj;

                return new Response<CreerLotPrepResultCreerLotPreparationResponse>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<CreerLotPrepResultCreerLotPreparationResponse>("Article inconnu.");
            }
        }

        public async Task<Response<ResponseCheckNumLotExist>> CheckNumLotExist(string BaseUrl_API, CheckNumLotExistModel model)
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
                                            <MethodName>PDARsvCheckNumLotExistMarj</MethodName>
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
                                    <Request_PDARsvCheckNumLotExistMarj xmlns=""http://www.-solutions.com/WebServices/"">
                                        <Description>
                                            <NumLot>{model.NumLot}</NumLot>
                                        </Description>
                                    </Request_PDARsvCheckNumLotExistMarj>
                                </SOAP-ENV:Body>
                            </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<CheckNumLotExistResponseCheckNumLotExistResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDARsvCheckNumLotExistMarj;
                return new Response<ResponseCheckNumLotExist>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<ResponseCheckNumLotExist>("Lot inconnu.");
            }
        }
    }
}