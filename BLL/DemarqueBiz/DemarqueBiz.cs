using NLog;
using Shared.Models;
using Shared.Models.IN;
using Shared.Models.OUT_;
using Shared.Models.Temp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DemarqueBiz : BaseService
    {

        private readonly string? Server_;
        private readonly string? Username_;
        private readonly string? Password_;
        private readonly string? Server_Demarque;
        private readonly string? Username_Demarque;
        private readonly string? Password_Demarque;

        #region Contructors
        public DemarqueBiz()
        {

        }
        public DemarqueBiz(string Server_, string Username_, string Password_,
                           string Server_Demarque, string Username_Demarque, string Password_Demarque)
        {
            this.Server_ = Server_;
            this.Username_ = Username_;
            this.Password_ = Password_;

            this.Server_Demarque = Server_Demarque;
            this.Username_Demarque = Username_Demarque;
            this.Password_Demarque = Password_Demarque;
        }
        #endregion
        public Response<List<ArticleByEANDemarqueResponse>> GetArticleByEAN(string db_serveur, string db_username, string db_password, ArticleByEANDemarqueModel model)
        {
            var listeTypeArticlePV = new List<string> { "2", "3", "4" };
            var listeTypeArticleUN = new List<string> { "1" };

            try
            {
                #region Get infos article from 
                var query = $@"SELECT
                                    arccode ean,
                                    arccinr codeInt,
                                    pkstrucobj.GET_CEXT(pkstrucrel.GET_NIVEAU('1', arccinr ,2,SYSDATE)) Departement,
                                    pkstrucobj.GET_CEXT(pkstrucrel.GET_NIVEAU('1', arccinr ,3,SYSDATE)) Rayon,
                                    pkstrucobj.GET_CEXT(pkstrucrel.GET_NIVEAU('1', arccinr ,4,SYSDATE)) Famille,
                                    NVL(pkstrucobj.GET_CEXT(pkstrucrel.GET_NIVEAU('1', arccinr,5,SYSDATE)),0) SousFamille,
                                    pkstrucobj.get_desc_caisse( arccinr ,'FR') LIBELLE,
                                    artustk TypeArt
                               FROM artcoca , artrac
                               WHERE artcinr = arccinr
                                    AND arccode='{model.ean}'
                                    AND arcetat != 3
                                    AND TRUNC(SYSDATE) BETWEEN arcddeb AND arcdfin";
                var dt = RunQuery(db_serveur, db_username, db_password, query);
                #endregion
                if (dt.Rows.Count <= 0)
                {
                    return new Response<List<ArticleByEANDemarqueResponse>>(null, "Article inconnu.");
                }
                else
                {
                    #region Check structure article
                    var queryCheckSecteur = $@"SELECT pkctrlacces.ctrl_structure(10,SYSDATE,'{model.username}',-1,
                                  (select cint_ray
                                   from mj_art_struct T
                                   WHERE T.MASCINR in
                                          (select arccinr
                                           from artcoca
                                           where arccode = '{model.ean}') 
                                            )) isexist FROM dual";

                    var dtCheckSecteur = RunQuery(db_serveur, db_username, db_password, queryCheckSecteur);
                    var checkResponse = Convert.ToInt32(dtCheckSecteur.Rows[0]["isexist"]);
                    #endregion
                    if (checkResponse == 1)
                    {
                        #region Check type demarque
                        if (model.type_demarque == "UN")
                        {
                            var articles = new List<ArticleByEANDemarqueResponse>();
                            var row = dt.Rows[0];
                            var _typeArticle = row["TypeArt"]?.ToString();
                            if (listeTypeArticleUN.Contains(_typeArticle))
                            {
                                articles.Add(new ArticleByEANDemarqueResponse
                                {
                                    EAN = row["ean"].ToString(),
                                    CODEINT = (int?)row["codeInt"],
                                    DEPARTEMENT = row["Departement"].ToString(),
                                    RAYON = row["Rayon"].ToString(),
                                    FAMILLE = row["Famille"].ToString(),
                                    SOUSFAMILLE = row["SousFamille"].ToString(),
                                    LIBELLE = row["LIBELLE"].ToString()
                                });
                                return new Response<List<ArticleByEANDemarqueResponse>>(articles, "Success.");
                            }
                            else
                            {
                                return new Response<List<ArticleByEANDemarqueResponse>>(null, "Type article non autorisé.");
                            }
                        }
                        else
                        {
                            var articles = new List<ArticleByEANDemarqueResponse>();
                            var row = dt.Rows[0];
                            var _typeArticle = row["TypeArt"]?.ToString();
                            if (listeTypeArticlePV.Contains(_typeArticle))
                            {
                                articles.Add(new ArticleByEANDemarqueResponse
                                {
                                    EAN = row["ean"].ToString(),
                                    CODEINT = (int?)row["codeInt"],
                                    DEPARTEMENT = row["Departement"].ToString(),
                                    RAYON = row["Rayon"].ToString(),
                                    FAMILLE = row["Famille"].ToString(),
                                    SOUSFAMILLE = row["SousFamille"].ToString(),
                                    LIBELLE = row["LIBELLE"].ToString()
                                });
                                return new Response<List<ArticleByEANDemarqueResponse>>(articles, "Success.");
                            }
                            else
                            {
                                return new Response<List<ArticleByEANDemarqueResponse>>(null, "Type article non autorisé.");
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        return new Response<List<ArticleByEANDemarqueResponse>>(null, "Article non autorisé.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response<List<ArticleByEANDemarqueResponse>>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public Response<string> CreateDemarque(string db_serveur, string db_username, string db_password, CreateDemarqueModel model)
        {
            try
            {
                var nomportable = "MSM_" + model.Site + "_" + model.Username + "_" + model.TypeDemarque + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second;

                foreach (var item in model.ListArticles)
                {
                    if (model.TypeDemarque == "UN")
                    {
                        var query = $@"INSERT INTO marj_Demarque_attente (Utilisateur, site, DateScan,ean,conde_int,
                                                                  famille,sfamille,Rayon,departement,integree, qte,
                                                                  libelle, TypeDemarque, nomportable,validee) 
                                   VALUES ('{model.Username}',{model.Site},TRUNC(SYSDATE),'{item.Ean}',
                                           '{item.Conde_int}','{item.Famille}','{item.Sfamille}','{item.Rayon}',
                                           '{item.Departement}','N',{item.Qte},'{item.Libelle.Replace("'", "´")}','{model.TypeDemarque}',
                                           '{nomportable}', 'N')";
                        RunQuery(db_serveur, db_username, db_password, query);
                    }
                    else
                    {
                        var Poids = item.Qte.Replace(",", ".");
                        var query = $@"INSERT INTO marj_Demarque_attente (Utilisateur, site, DateScan,ean,conde_int,
                                                                  famille,sfamille,Rayon,departement,integree, qte,
                                                                  libelle, TypeDemarque, nomportable,validee) 
                                   VALUES ('{model.Username}',{model.Site},TRUNC(SYSDATE),'{item.Ean}',
                                           '{item.Conde_int}','{item.Famille}','{item.Sfamille}','{item.Rayon}',
                                           '{item.Departement}','N',{Poids},'{item.Libelle.Replace("'", "´")}','{model.TypeDemarque}',
                                           '{nomportable}', 'N')";
                        RunQuery(db_serveur, db_username, db_password, query);
                    }
                }

                return new Response<string>(nomportable, "Success.");
            }
            catch (Exception ex)
            {
                return new Response<string>("Erreur s’est produite lors de l’exécution de l'opération.");
            }
        }

        public Response<List<ArticleDemarqueTelephoneModel>> GetPortablesAvecDemarqueEnAttente(CreateDemarqueModel model)
        {
            List<ArticleDemarqueTelephoneModel> telephonesDemarque;

            string dateQuery = "";
            var dicParams = new Dictionary<string, object>()
                {
                    { ":site" , model.Site }
                };
            if (model.StartDate.HasValue && model.EndDate.HasValue)
            {
                dateQuery = " AND Datescan between :ddebut and :dfin + 0.99999 ";
                dicParams.Add(":ddebut", model.StartDate);
                dicParams.Add(":dfin", model.EndDate);
            }
            string queryTel = $@"
                    select distinct NOMPORTABLE ,COUNT(*) AS cnt, MIN(VALIDEE) as AllValide
                    from marj_Demarque_attente 
                    WHERE INTEGREE <> 'O'
                    AND site = :site
                    {dateQuery} 
                    GROUP BY NOMPORTABLE
                    ORDER BY COUNT(*) DESC";

            var dt = RunQuery(Server_Demarque, Username_Demarque, Password_Demarque, queryTel, dicParams);
            if (dt.Rows.Count <= 0)
            {
                return new Response<List<ArticleDemarqueTelephoneModel>>(null, "Liste vide.");
            }
            telephonesDemarque = new List<ArticleDemarqueTelephoneModel>();
            foreach (DataRow r in dt.Rows)
            {
                telephonesDemarque.Add(new ArticleDemarqueTelephoneModel()
                {
                    Nomportable = Convert.ToString(r["NOMPORTABLE"]),
                    Count = Convert.ToString(r["cnt"]),
                    isValide = Convert.ToString(r["AllValide"]) == "O"
                });
            }
            return new Response<List<ArticleDemarqueTelephoneModel>>(telephonesDemarque);

        }

        public Response<ArticleDemarqueTelephoneModel> GetArticlesDemarqueParNomPortable(CreateDemarqueModel model)
        {
            var articlesDemarque = new ArticleDemarqueTelephoneModel()
            {
                Nomportable = model.NomTelephone
            };

            string dateQuery = "";
            var dicParams = new Dictionary<string, object>()
                {
                    { ":site" , model.Site},
                    { ":nomTel", model.NomTelephone }
                };
            if (model.StartDate.HasValue && model.EndDate.HasValue)
            {
                dateQuery = " AND Datescan between :ddebut and :dfin + 0.99999 ";
                dicParams.Add(":ddebut", model.StartDate);
                dicParams.Add(":dfin", model.EndDate);
            }
            string queryTel = $@"SELECT 
                        Ean,
                        Conde_int,
                        Famille,
                        Sfamille,
                        Rayon,
                        Departement,
                        Qte,
                        Libelle,
                        VALIDEE
            FROM marj_Demarque_attente 
            WHERE NOMPORTABLE = :nomTel 
            AND SITE = :site 
            AND INTEGREE <> 'O'
            {dateQuery} 
            ORDER BY Libelle";
            var dt = RunQuery(Server_Demarque, Username_Demarque, Password_Demarque, queryTel, dicParams);

            if (dt == null || dt.Rows.Count <= 0)
            {
                return new Response<ArticleDemarqueTelephoneModel>(articlesDemarque);
            }

            articlesDemarque.ArticleDemarques = (from DataRow r in dt.Rows
                                                 select new ArtcileDemarqueModel()
                                                 {
                                                     Ean = Convert.ToString(r["Ean"]),
                                                     Conde_int = Convert.ToString(r["Conde_int"]),
                                                     Famille = Convert.ToString(r["Famille"]),
                                                     Sfamille = Convert.ToString(r["Sfamille"]),
                                                     Rayon = Convert.ToString(r["Rayon"]),
                                                     Departement = Convert.ToString(r["Departement"]),
                                                     Qte = Convert.ToString(r["Qte"]),
                                                     Libelle = Convert.ToString(r["Libelle"]),
                                                     isValide = Convert.ToString(r["VALIDEE"]) == "O"
                                                 }).ToList();
            return new Response<ArticleDemarqueTelephoneModel>(articlesDemarque);
        }
        public Response<bool> UpdateDemarque(AuthDto<ArtcileDemarqueModel> payload)
        {
            var query = "UPDATE marj_Demarque_attente SET QTE = :QTE WHERE  NOMPORTABLE = :NOMPORTABLE AND CONDE_INT = :CONDE_INT";
            
            return new Response<bool>(RunUpdateQuery(Server_Demarque, Username_Demarque, Password_Demarque, query, new Dictionary<string, object>()
                {
                    { ":NOMPORTABLE", payload.Data.NomTelephone},
                    { ":CONDE_INT", payload.Data.Conde_int},
                    { ":QTE", payload.Data.Qte}
                }));

        }

        public Response<bool> ValiderDemarque(AuthDto<ArtcileDemarqueModel> payload)
        {
            var query = @"UPDATE marj_Demarque_attente  
                SET VALIDEE = 'O',QTE = :QTE 
                WHERE INTEGREE = 'N'  
                AND NOMPORTABLE = :NOMPORTABLE 
                AND CONDE_INT = :CONDE_INT";

            return new Response<bool>(RunUpdateQuery(Server_Demarque, Username_Demarque, Password_Demarque, query, new Dictionary<string, object>()
                {
                    { ":NOMPORTABLE", payload.Data.NomTelephone},
                    { ":CONDE_INT", payload.Data.Conde_int},
                    { ":QTE", payload.Data.Qte}
                }));

        }

        public Response<bool> DeleteDemarque(AuthDto<ArtcileDemarqueModel> payload)
        {
            var query = @"DELETE marj_Demarque_attente 
                     WHERE INTEGREE = 'N' 
                     AND NOMPORTABLE = :NOMPORTABLE 
                     AND CONDE_INT = :CONDE_INT ";

            return new Response<bool>(RunUpdateQuery(Server_Demarque, Username_Demarque, Password_Demarque, query, new Dictionary<string, object>()
                {
                    { "NOMPORTABLE", payload.Data.NomTelephone},
                    { "CONDE_INT", payload.Data.Conde_int}
                }));
        }

        public Response<bool> IntegrerDemarque(string userName, string siteUser, ArticleDemarqueTelephoneModel payload)
        {

            var _logger = LogManager.GetCurrentClassLogger();
            _logger.Log<string>(NLog.LogLevel.Info, $"IntegrerDemarque(userName:{userName})");
            int Compteur = 1;
            int countTotal = 0;
            int countTotalSucceeded = 0;


            var res = GetArticlesDemarqueParNomPortable(new CreateDemarqueModel() { Site = siteUser, NomTelephone = payload.Nomportable });

            if (!res.Succeeded)
            {
                _logger.Log<string>(NLog.LogLevel.Warn, $"Echèc GetArticlesDemarqueParNomPortable");
                var response = new Response<bool>(false);
                response.Message = $"Echèc recuperation ligne démarque pour portable: {payload.Nomportable}; site: {siteUser}";
                return response;
            }
            if (res.Data == null || res.Data.ArticleDemarques  == null || res.Data.ArticleDemarques.Count() == 0)
            {
                // pas de ligne démarque trouvé
                _logger.Log<string>(NLog.LogLevel.Warn, $"pas de ligne démarque trouvé");
                var response = new Response<bool>(false);
                response.Message = $"pas de ligne démarque trouvé pour portable: {payload.Nomportable}; site: {siteUser}";
                return response;
            }
            payload.ArticleDemarques = res.Data.ArticleDemarques;

            if (payload.ArticleDemarques != null)
            {
                countTotal = payload.ArticleDemarques.Count;
            }
            //Boucle sur les articles à demarquer d'un téléphone
            foreach (var item in payload.ArticleDemarques)
            {
                string site = "";
                string NomTelephone = payload.Nomportable;
                string QTE = item.Qte;
                string v_EAN = item.Ean;
                string EAN = item.Ean;

                _logger.Log<string>(NLog.LogLevel.Info, $"nomProtable:{NomTelephone},EAN:{EAN}");
                int Numero_Mouvement = SeqNextVal();
                if (Numero_Mouvement <= 0)
                {
                    // problème génération numéro séquence
                    _logger.Log<string>(NLog.LogLevel.Warn, $"problème génération numéro séquence");
                    continue;
                }
                DateTime DateScan;
                string CINL = "";
                double EcartQte;
                double EcartPoid;
                string NomCorrecteur = userName;
                double NouvelleQte;
                double NouveauPoids;
                string NomFichier = $"{NomTelephone}_{Numero_Mouvement}";
                string SEQVL = "";
                string typeDemarque = "";
                string poidsMoyen = "";

                //récuperer les informations de la ligne demarque depuis oracle DEMARQUE
                var demarqueInfo = RecupererDemarque(NomTelephone, EAN);
                if (demarqueInfo == null)
                {
                    // pas de ligne démarque trouvé
                    _logger.Log<string>(NLog.LogLevel.Warn, $"pas de ligne démarque trouvé, RecupererDemarque(NomTelephone:{NomTelephone},EAN:{EAN})");
                    continue;
                }
                site = demarqueInfo.site;
                DateScan = demarqueInfo.datescan;
                typeDemarque = demarqueInfo.TYPEDEMARQUE;

                // Récuperer les informations complementaire de l'article depuis oracle 
                var artcileInfo = RECEP_autresChampsIntegration(EAN);
                if (demarqueInfo == null)
                {
                    // article non trouvé, problème manque information
                    _logger.Log<string>(NLog.LogLevel.Warn, $"article non trouvé, RECEP_autresChampsIntegration(EAN:{EAN})");
                    continue;
                }
                CINL = artcileInfo.cinl;
                poidsMoyen = artcileInfo.poids_moyen;
                SEQVL = artcileInfo.seqvl;

                // Faire le calcul des ecarts Qte et poids
                //si poids variable
                if ("PV".Equals(typeDemarque))
                {
                    EcartQte = Convert.ToDouble(QTE) / Convert.ToDouble(poidsMoyen);
                    NouvelleQte = this.EcartQte(site, CINL);
                    NouvelleQte = NouvelleQte + EcartQte;
                    EcartPoid = Convert.ToDouble(QTE);
                    NouveauPoids = this.EcartQte(site, CINL);
                    NouveauPoids = NouveauPoids + EcartPoid;
                }
                //non géré au poids
                else
                {
                    EcartQte = Convert.ToDouble(QTE);
                    NouvelleQte = this.EcartQte(site, CINL);
                    NouvelleQte = NouvelleQte + EcartQte;
                    EcartPoid = 0;
                    NouveauPoids = 0;
                }


                //Inserer sur la base de donnée 
                //InsertInto_INTMVTSTO(Session("N_Site").ToString(), NextValSeq.ToString(), SeqLigne.ToString(), Session("CINL").ToString(), Convert.ToDouble(Ecart_Quantite), Convert.ToDouble(Ecart_Poids), Session("Utilisateur").ToString(), Convert.ToDouble(Nouvelle_QTE), Convert.ToDouble(Nouveau_Poids), Session("NOMPORTABLE").ToString() & "_" & NextValSeq.ToString(), Session("SEQVL").ToString(), v_DateScan.ToString())
                var resultatIntegration = IntegrerDemarque(
                     site,
                     Numero_Mouvement.ToString(),
                     Compteur.ToString(),
                     CINL,
                     EcartQte,
                     EcartPoid,
                     NomCorrecteur,
                     NouvelleQte,
                     NouveauPoids,
                     NomFichier,
                     SEQVL,
                     DateScan);
                if (!resultatIntegration)
                {
                    // échéc insertion mvt demarque sur oracle 
                    _logger.Log<string>(NLog.LogLevel.Warn, $"échéc insertion mvt demarque sur oracle ");
                    continue;
                }

                // Modifier la ligne démarque sur la base de donnée DERMARQUE
                var resultatUpdate = UpdateDemarqueLigne(userName, site, NomTelephone, DateScan, QTE, v_EAN);
                if (!resultatUpdate)
                {
                    // échéc modification mvt demarque sur oracle DEMARQUE
                    _logger.Log<string>(NLog.LogLevel.Warn, $"échéc modification mvt demarque sur oracle DEMARQUE");
                    continue;
                }
                Compteur++;
                countTotalSucceeded++;
            }
            return new Response<bool>(countTotal == countTotalSucceeded);
        }

        #region Integrer demarque
        private ArticleDemarqueLigne RecupererDemarque(string nomTelephone, string ean)
        {
            ArticleDemarqueLigne ligneDemarque = null;
            var query = @"
                SELECT
                    site,
                    datescan,
                    ean,
                    rayon,
                    departement,
                    libelle,
                    qte,
                    TYPEDEMARQUE
                FROM
                    marj_demarque_attente
                WHERE
                        nomportable = :nomportable
                    AND integree = 'N'
                    AND ean = :ean";

            var resultatDt = RunQuery(Server_Demarque, Username_Demarque, Password_Demarque, query, new Dictionary<string, object>()
            {
                {":nomportable", nomTelephone } ,
                {":ean", ean }
            });

            if (resultatDt != null && resultatDt.Rows.Count > 0)
            {
                ligneDemarque = new ArticleDemarqueLigne();
                ligneDemarque.site = Convert.ToString(resultatDt.Rows[0]["site"]);
                ligneDemarque.datescan = Convert.ToDateTime(resultatDt.Rows[0]["datescan"]);
                ligneDemarque.ean = Convert.ToString(resultatDt.Rows[0]["ean"]);
                ligneDemarque.rayon = Convert.ToString(resultatDt.Rows[0]["rayon"]);
                ligneDemarque.departement = Convert.ToString(resultatDt.Rows[0]["departement"]);
                ligneDemarque.libelle = Convert.ToString(resultatDt.Rows[0]["libelle"]);
                ligneDemarque.qte = Convert.ToDouble(resultatDt.Rows[0]["qte"]);
                ligneDemarque.TYPEDEMARQUE = Convert.ToString(resultatDt.Rows[0]["TYPEDEMARQUE"]);

            }

            return ligneDemarque;
        }
        private bool UpdateDemarqueLigne(string userName, string site, string NomTelephone, DateTime DateScan, string QTE, string v_EAN)
        {
            var updateDemarque = @"Update MARJ_DEMARQUE_ATTENTE 
            set INTEGREE='O',
                INTEGRATEUR=:userName ,
                Erreur='' 
            where SITE= :site 
                and NOMPORTABLE= :NomFichier 
                and DateScan= :DateScan 
                and QTE = :QTE 
                 
                and EAN= :v_EAN";

            var resulat = RunUpdateQuery(Server_Demarque, Username_Demarque, Password_Demarque, updateDemarque, new Dictionary<string, object>()
            {
                {":userName", userName},
                {":site", site},
                {":NomFichier", NomTelephone},
                {":DateScan", DateScan},
                {":QTE", QTE},
                {":v_EAN", v_EAN}
            });
            return resulat;
        }
        private double EcartQte(string site, string CINL)
        {
            double resultat = 0;
            var query = "select nvl(pkstock.getStockDispoEnQte(:Site,:CINL),0) QteDispo from dual";

            var resultatDt = RunQuery(Server_, Username_, Password_, query, new Dictionary<string, object>()
            {
                { ":Site", site },
                { ":CINL", CINL }
            });
            if (resultatDt != null && resultatDt.Rows.Count > 1)
            {
                resultat = Convert.ToDouble(resultatDt.Rows[0]["QteDispo"]);
            }
            return resultat;
        }
        private ArticleIntegrationInfo RECEP_autresChampsIntegration(string EAN)
        {
            ArticleIntegrationInfo artInfo = null;
            string query = @"SELECT
    arccinv         cinl,
    aruseqvl        seqvl,
    arucinr         cinr,
    artustk         ustk,
    nvl(arlpmoy, 1) poids_moyen
FROM
    (
        SELECT
            arccinv,
            aruseqvl,
            arucinr,
            artustk,
            arlpmoy,
            1       valide,
            arcetat etat
        FROM
            artcoca,
            artul,
            artvl,
            artrac
        WHERE
                TRIM(LEADING '0' FROM arccode) = :ean
            AND trunc(sysdate) BETWEEN arcddeb AND arcdfin
            AND arcetat != 3
            AND arccinv = arucinl
            AND arlseqvl = aruseqvl
            AND artcinr = arucinr
        UNION
        SELECT
            arccinv,
            aruseqvl,
            arucinr,
            artustk,
            arlpmoy,
            2       valide,
            arcetat etat
        FROM
            artcoca,
            artul,
            artvl,
            artrac
        WHERE
                TRIM(LEADING '0' FROM arccode) = :ean
            AND arcetat != 3
            AND arccinv = arucinl
            AND arlseqvl = aruseqvl
            AND artcinr = arucinr
        ORDER BY
            valide,
            etat
    )
WHERE
    ROWNUM = 1";

            var articleInfosDt = RunQuery(Server_, Username_, Password_, query, new Dictionary<string, object>()
               {
                   { ":ean",EAN }
               });
            if (articleInfosDt != null && articleInfosDt.Rows.Count > 0)
            {
                var r = articleInfosDt.Rows[0];
                artInfo = new ArticleIntegrationInfo();
                artInfo.cinl = Convert.ToString(r["cinl"]);
                artInfo.seqvl = Convert.ToString(r["seqvl"]);
                artInfo.cinr = Convert.ToString(r["cinr"]);
                artInfo.ustk = Convert.ToString(r["ustk"]);
                artInfo.poids_moyen = Convert.ToString(r["poids_moyen"]);

            }
            return artInfo;
        }
        private bool IntegrerDemarque(string site, string Numero_Mouvement, string Compteur, string CINL, double EcartQte, double EcartPoid, string NomCorrecteur, double NouvelleQte, double NouveauPoids, string NomFichier, string SEQVL, DateTime DateScan)
        {

            var dicParams = new Dictionary<string, object>()
                {
                {":site",site },
                {":Numero_Mouvement", Numero_Mouvement},
                {":Compteur",Compteur },
                {":DateScan", DateScan },
                {":CINL", CINL},
                {":EcarQte", EcartQte},
                {":EcartPoid", EcartPoid },
                {":NomCorrecteur",NomCorrecteur },
                {":site1",site },
                {":NouvelleQte",NouvelleQte },
                {":NomFichier", NomFichier},
                {":Compteur1",Compteur },
                {":SEQVL",SEQVL },
                {":Numero_Mouvement1", Numero_Mouvement},
                {":NouveauPoids",NouveauPoids }
                };

            var query = $@" INSERT INTO INTMVTSTO
          (IMSSITE, IMSTMVT, IMSNMVT, IMSNLIG, IMSDMVT, IMSCINL, IMSTPOS, IMSNPOS, IMSMOTF, IMSIMPU, IMSEQTE,IMSEPDS, IMSNPAC, IMSNPRE, 
          IMSTTVA, IMSCORR, IMSCTPT, IMSNQTE, IMSNPDS, IMSEPAC, IMSEPRE, IMSVARE, IMSVAVE, IMSITRT, IMSDTRT, IMSFICH, IMSFLIG, IMSDCRE, 
          IMSDMAJ, IMSUTIL, IMSPPRG, IMSSEQVL, IMSCEXMVT)
          VALUES
          (:site,101,
           :Numero_Mouvement ,
           :Compteur, 
           trunc(:DateScan), 
           :CINL, 0, 0, 21, 1,
           :EcarQte,
           :EcartPoid, - 1, - 1, -1,
           :NomCorrecteur,
           :site1,
           :NouvelleQte,
           :NouveauPoids, 0, 0, 0, 0, 0, trunc(SYSDATE),
           :NomFichier,
           :Compteur1,trunc(SYSDATE), trunc(SYSDATE), 'Corr_Portabl', 'Corr_Portabl', 
           :SEQVL,
           :Numero_Mouvement1)";
            return RunUpdateQuery(Server_, Username_, Password_, query, dicParams);
        }
        private int SeqNextVal()
        {
            var resultat = 0;
            var query = "SELECT seq_stomvt.NEXTVAL FROM DUAL";

            var resultatDt = RunQuery(Server_, Username_, Password_, query);

            if (resultatDt != null && resultatDt.Rows.Count > 0)
            {
                resultat = Convert.ToInt32(resultatDt.Rows[0][0]);
            }
            return resultat;
        }

        private sealed class ArticleIntegrationInfo
        {
            public string cinl { get; set; }
            public string seqvl { get; set; }
            public string cinr { get; set; }
            public string ustk { get; set; }
            public string poids_moyen { get; set; }
        }
        private sealed class ArticleDemarqueLigne
        {
            public string site { get; set; }
            public DateTime datescan { get; set; }
            public string ean { get; set; }
            public string rayon { get; set; }
            public string departement { get; set; }
            public string libelle { get; set; }
            public double qte { get; set; }
            public string TYPEDEMARQUE { get; set; }
        }

        #endregion

        

    }
}
