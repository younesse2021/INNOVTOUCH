using Shared.Models;
using Shared.Models.IN;
using Shared.Models.OUT.GenererNumeroArrivageResponse;
using Shared.Models.OUT.GetArrivageResponse;
using Shared.Models.OUT.GetAticleArrivageMagasinResponse;
using Shared.Models.OUT.InsertArrivageResponse;
using Shared.Models.OUT.InsertPaletteCompleteResponse;
using Shared.Models.OUT.ListMotifsArrivageResponse;
using Shared.Models.OUT.TestExistPalResponse;
using Shared.Models.OUT.UpdateArrivageResponse;
using Shared.Models.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ArrivageMagasinService : BaseService
    {
        public async Task<Response<string>> GenererNumeroArrivage(string BaseUrl_API, GenererNumeroArrivageModel model)
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
                              <MethodName>PDAGenererNumeroArrivage</MethodName>
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
                              <Request_PDAGenererNumeroArrivage xmlns=""http://www.-solutions.com/WebServices/"">
                              <Description/>
                              </Request_PDAGenererNumeroArrivage>
                              </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<GenererNumeroArrivageResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAGenererNumeroArrivage.Result.NumArrivage;

                return new Response<string>(resultOutput, response.Message);
            }
            catch (Exception ex)
            {
                //return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
                return new Response<string>(ex.ToString());
            }
        }

        public async Task<Response<TestExistPalResult>> TestExistPal(string BaseUrl_API, TestExistPalModel model)
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
                              <MethodName>PDATestExistPal</MethodName>
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
                              <Request_PDATestExistPal xmlns=""http://www.-solutions.com/WebServices/"">
                              <Description>
                              <code>{model.palette}</code>
                              <site>{model.site}</site>
                              </Description>
                              </Request_PDATestExistPal>
                              </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                              
                var response = await RESTHepler.Run<TestExistPalResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDATestExistPal.Result;
                
                if (resultOutput.Code == "1" && resultOutput.NumArrivage == "-1") // Palette valide 
                {
                    return new Response<TestExistPalResult>(resultOutput, response.Message);
                }
                else if (resultOutput.Code == "-2" && resultOutput.NumArrivage != "-1") // Palette existe dans un arrivage
                {
                    return new Response<TestExistPalResult>(resultOutput, response.Message);
                }
                else 
                {
                    return new Response<TestExistPalResult>("Le numéro saisie ne correspond à aucune palette.");
                }
            }
            catch
            {
                return new Response<TestExistPalResult>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public async Task<Response<GetAticleResult>> GetAticle(string BaseUrl_API, GetAticleArrivageMagasinModel model)
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
                              <MethodName>PDAGetAticle</MethodName>
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
                              <SOAP-ENV:Body><Request_PDAGetAticle xmlns=""http://www.-solutions.com/WebServices/"">
                              <request>
                              <ean>{model.ean}</ean>
                              <palette>{model.palette}</palette>
                              <site>{model.site}</site>
                              </request>
                              </Request_PDAGetAticle>
                              </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<GetAticleArrivageMagasinResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAGetAticle.Result;

                return new Response<GetAticleResult>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<GetAticleResult>("Article inconnu.");
            }
        }

        public async Task<Response<List<Ligne>>> GetListMotifsArrivage(string BaseUrl_API, ListMotifsArrivageModel model)
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
                              <MethodName>PDAGetListMotifsArrivage</MethodName>
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
                              <Request_PDAGetListMotifsArrivage xmlns=""http://www.-solutions.com/WebServices/"">
                              <getLOVParPostesLink>
                              <classe><![CDATA[10]]></classe>
                              <table><![CDATA[1123]]></table>
                              <language><![CDATA[FR]]></language>
                              <parvan1><![CDATA[-1]]></parvan1>
                              </getLOVParPostesLink>
                              </Request_PDAGetListMotifsArrivage>
                              </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";
                var response = await RESTHepler.Run<ListMotifsArrivageResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAGetListMotifsArrivage.Detail.Ligne;

                return new Response<List<Ligne>>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<List<Ligne>>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public async Task<Response<InsertArrivageResult>> InsertArrivage(string BaseUrl_API, InsertArrivageModel model)
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
                              <MethodName>PDAInsertArrivage</MethodName>
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
                              <Request_PDAInsertArrivage xmlns=""http://www.-solutions.com/WebServices/"">
                              <data>
                              <NumeroArrivage>{model.NumeroArrivage}</NumeroArrivage>
                              <NumeroImmatr>{model.NumeroImmatr}</NumeroImmatr>
                              <palette>
                              <paletteCode>{model.paletteCode}</paletteCode>";
                foreach (var item in model.listeArticles)
                {
                    body += $@"<article>
                              <codeEan>{item.codeEan}</codeEan>
                              <articleLibelle>{item.articleLibelle}</articleLibelle>
                              <quantite>{item.quantite}</quantite>
                              <poids>{item.poids}</poids>
                              <uvcua>{item.uvcua}</uvcua>
                              <ua>{item.ua}</ua>
                              <ustk>{item.ustk}</ustk>
                              <seqvl>{item.seqvl}</seqvl>
                              <cexr>{item.cexr}</cexr>
                              <cinv>{item.cinv}</cinv>
                              <cexv>{item.cexv}</cexv>
                              <motif>{item.motif}</motif>
                              </article>";
                }
                body += @$"</palette>
                              </data>
                              </Request_PDAInsertArrivage>
                              </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";

                var response = await RESTHepler.Run<InsertArrivageResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAInsertArrivage.Result;

                return new Response<InsertArrivageResult>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<InsertArrivageResult>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public async Task<Response<InsertArrivageResult>> ValiderInsertArrivage(string BaseUrl_API, ValiderInsertArrivageModel model)
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
                              <MethodName>PDAInsertArrivage</MethodName>
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
                              <Request_PDAInsertArrivage xmlns=""http://www.-solutions.com/WebServices/"">
                              <data>
                              <NumeroArrivage>{model.NumeroArrivage}</NumeroArrivage>
                              <NumeroImmatr>{model.NumeroImmatr}</NumeroImmatr>
                              </data>
                              </Request_PDAInsertArrivage>
                              </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";

                var response = await RESTHepler.Run<InsertArrivageResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAInsertArrivage.Result;

                return new Response<InsertArrivageResult>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<InsertArrivageResult>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public async Task<Response<GetArrivageResult>> GetArrivage(string BaseUrl_API, GetArrivageModel model)
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
                              <MethodName>PDAGetArrivage</MethodName>
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
                              <Request_PDAGetArrivage xmlns=""http://www.-solutions.com/WebServices/"">
                              <data>
                              <numArrivage>{model.NumeroArrivage}</numArrivage>
                              </data>
                              </Request_PDAGetArrivage>
                              </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";

                var response = await RESTHepler.Run<GetArrivageResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAGetArrivage.result;

                return new Response<GetArrivageResult>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<GetArrivageResult>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public async Task<Response<InsertPaletteCompleteResult>> InsertPaletteComplete(string BaseUrl_API, InsertPaletteCompleteModel model)
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
                                              <MethodName>PDAInsertPaletteComplete</MethodName>
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
                                      <Request_PDAInsertPaletteComplete xmlns=""http://www.-solutions.com/WebServices/"">
                                          <data>
                                              <NumeroArrivage>{model.NumeroArrivage}</NumeroArrivage>
                                              <NumeroImmatr>{model.NumeroImmatr}</NumeroImmatr>
                                              <palette>
                                                  <paletteCode>{model.paletteCode}</paletteCode>
                                              </palette>
                                          </data>
                                      </Request_PDAInsertPaletteComplete>
                                  </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";

                var response = await RESTHepler.Run<InsertPaletteCompleteResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAInsertPaletteComplete.Result;

                return new Response<InsertPaletteCompleteResult>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<InsertPaletteCompleteResult>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public async Task<Response<UpdateArrivageResult>> UpdateArrivage(string BaseUrl_API, UpdateArrivageModel model)
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
                                              <MethodName>PDAUpdateArrivage</MethodName>
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
                                      <Request_PDAUpdateArrivage xmlns=""http://www.-solutions.com/WebServices/"">
                                          <data>
                                              <NumeroArrivage>{model.NumeroArrivage}</NumeroArrivage>
                                              <NumeroImmatr>{model.NumeroImmatr}</NumeroImmatr>
                                          </data>
                                      </Request_PDAUpdateArrivage>
                                  </SOAP-ENV:Body>
                              </SOAP-ENV:Envelope>";

                var response = await RESTHepler.Run<UpdateArrivageResponse>(BaseUrl_API, body);
                var resultOutput = response.Data.SOAPENVEnvelope.SOAPENVBody.Response_PDAUpdateArrivage.Result;

                return new Response<UpdateArrivageResult>(resultOutput, response.Message);
            }
            catch
            {
                return new Response<UpdateArrivageResult>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }
    }
}
