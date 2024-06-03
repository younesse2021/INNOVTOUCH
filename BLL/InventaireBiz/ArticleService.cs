using AutoMapper;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Models.IN;
using Shared.Models.OUT.Article;
using Shared.Models.OUT.ArticleByEAN;
using Shared.Models.OUT.ZonesEmplacements;
using Shared.Models.OUT_;
using Shared.Models.OUT_.Stock;
using Shared.Models.OUT_.Vente;
using Shared.Models.REST;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ArticleService : BaseService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            _IUnitOfWork = iUnitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<ProduitInfo>> ArticleInfos(ArticleInventaire model)
        {
            try
            {
                Response<ProduitInfo> res = new Response<ProduitInfo>();

                var result = _IUnitOfWork.Produits.Where(x => x.CODE_CAISSE == model.ean) 
                    .FirstOrDefault();

                if (result != null)
                {
                    res.Succeeded = true;
                    res.Data = result;
                    res.Errors = null;
                }
                else 
                {
                    res.Succeeded = false;
                    res.Data = null;
                    res.Message = "Article introuvable";
                }
              
                return res;
            }
            catch (Exception ex)
            {
                return new Response<ProduitInfo>("Article inconnu.");
            }
        }
        public async Task<Response<InfosArticleByEANResponse>> ArticleByEANInfos(ArticleByEANModel model)
        {
            try
            {
                //#region Article
                //var bodyArticle = @$"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                //              <SOAP-ENV:Header>
                //              <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                //              <Authentification>
                //              <Username>{model.username}</Username>
                //              <Password>{model.password}</Password>
                //              <Domain>DEFAULT</Domain>
                //              <MethodName>GWSGetArticleInfo</MethodName>
                //              </Authentification>
                //              <Context>
                //              <Classe>10</Classe>
                //              <Site>{model.site}</Site>
                //              <MerchStructID>1</MerchStructID>
                //              <CommercialNetworkID>1</CommercialNetworkID>
                //              <Language>FR</Language>
                //              </Context>
                //              </Parameters>
                //              </SOAP-ENV:Header>
                //              <SOAP-ENV:Body>
                //              <Request_GWSGetArticleInfo xmlns=""http://www.-solutions.com/WebServices/"">
                //              <GWSGetArticleInfo>
                //              <CINV><![CDATA[{model.ean}]]></CINV>
                //              <MODE><![CDATA[1]]></MODE>
                //              </GWSGetArticleInfo>
                //              </Request_GWSGetArticleInfo>
                //              </SOAP-ENV:Body>
                //              </SOAP-ENV:Envelope>";
                //var responseArticle = await RESTHepler.Run<ArticleByEANResponse>(BaseUrl_API, bodyArticle);
                //var resultArticle = responseArticle.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSGetArticleInfo.article;
                //resultArticle.imageUrl = @$"{BaseUrl_Image}/images-articles-msm-resize/{model.ean}.jpg"; 
                //#endregion

                #region Stock
                var bodyStock = @$"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                                   <SOAP-ENV:Header>
                                       <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                                           <Authentification>
                                                <Username>{model.username}</Username>
                                               <Password>{model.password}</Password>
                                               <Domain>DEFAULT</Domain>
                                               <MethodName>GWSGetInfoStock</MethodName>
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
                                       <Request_GWSGetInfoStock xmlns=""http://www.-solutions.com/WebServices/"">
                                           <GWSGetInfoStock>
                                               <barCode>
                                                   <![CDATA[{model.ean}]]>
                                               </barCode>
                                           </GWSGetInfoStock>
                                       </Request_GWSGetInfoStock>
                                   </SOAP-ENV:Body>
                                </SOAP-ENV:Envelope>";
            //var responseStock = await RESTHepler.Run<ArticleByEANStockResponse>(BaseUrl_API, bodyStock);
                //var resultStock = responseStock.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSGetInfoStock.infoStock;
                #endregion

                #region Vente
                var bodyVente = @$"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                                   <SOAP-ENV:Header>
                                   <Parameters xmlns=""http://www.-solutions.com/WebServices/"">
                                   <Authentification>
                                   <Username>{model.username}</Username>
                                   <Password>{model.password}</Password>
                                   <Domain>DEFAULT</Domain>
                                   <MethodName>GWSGetInfoVente</MethodName>
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
                                   <Request_GWSGetInfoVente xmlns=""http://www.-solutions.com/WebServices/"">
                                   <GWSGetInfoVente>
                                   <barCodeIV><![CDATA[{model.ean}]]></barCodeIV>
                                   </GWSGetInfoVente>
                                   </Request_GWSGetInfoVente>
                                   </SOAP-ENV:Body>
                                   </SOAP-ENV:Envelope>";
                //var responseVente = await RESTHepler.Run<ArticleByEANVenteResponse>(BaseUrl_API, bodyVente);
                //var resultVente = responseVente.Data.SOAPENVEnvelope.SOAPENVBody.Response_GWSGetInfoVente.infoVente;
                #endregion

                var resultOutput = new InfosArticleByEANResponse()
                {
                    //InfoArticle = resultArticle,
                    //InfoStock = resultStock,
                    //InfoVente = resultVente
                };

                return new Response<InfosArticleByEANResponse>(resultOutput, "Success.");
            }
            catch (Exception ex)
            {
                return new Response<InfosArticleByEANResponse>("Article inconnu.");
            }
        }

    }
}
