using AutoMapper;
using BLL.Services.Contrat;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.Models.Entite;
using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Renci.SshNet.Messages;
using Renci.SshNet.Messages.Connection;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Inventaire;
using Shared.Models;
using Shared.Models.IN;
using Shared.Models.OUT.Inventaires;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class AddInventaireService : IInentaireServicecs
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AddInventaireService> _logger;
        private readonly IConfiguration _IConfiguration;
        public AddInventaireService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AddInventaireService> logger, IConfiguration iconfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _IConfiguration = iconfiguration;
            _logger.LogInformation("AddInventaireService(...)");
        }
        public async Task<Response<bool>> AddInventaire(CreateInventaireModel addinentair)
        {
            var Responce = new Response<bool>();
            try
            {
                List<ProduitList> artilces = new List<ProduitList>();
 
                foreach (var item in addinentair.ListeArticles)
                {
                    ProduitList model = new ProduitList();
                    model.barcode = item.barcode;
                    model.description = item.description;
                    model.quantity = item.quantity;
                    model.weight = item.weight;
                    model.salePrice = item.salePrice;
                    model.externalVariantCode = item.externalVariantCode;
                    model.status = item.status;
                    model.internalLogisticCode = item.internalLogisticCode;
                    model.intMerchStrucNode = item.intMerchStrucNode;
                    model.extMerchStrucNode = item.extMerchStrucNode;
                    model.merchStructureID = item.merchStructureID;
                    model.invoicingUnit = item.invoicingUnit;
                    model.stockUnit = item.stockUnit;
                    model.averageWeight = item.averageWeight;
                    model.seqvl = item.seqvl;

                    artilces.Add(model);

                    var Inventairee = new AddInventaire()
                    {
                        username = addinentair.username,
                        password = addinentair.password,
                        site = addinentair.site,
                        inventaire = addinentair.inventaire,
                        type = addinentair.type,
                        zone = addinentair.zone,
                        emplacement = addinentair.emplacement,
                        Produits = artilces
                    };

                    await _unitOfWork.Inventaire.CreateAsync(Inventairee);
                    _unitOfWork.Save();
                };

                Responce.Message = "les article bien ajoute";
                Responce.Data = true;
                Responce.Succeeded = true;
            }
            catch (Exception ex)
            {
                Responce.Message = $"Error : {ex.Message}";
                Responce.Data = false;
                Responce.Succeeded = false;
            }
            return Responce;
        }
        public Response<int> AddInventaire(InventoryDTO model)
        {
            var Responce = new Response<int>();
            try
            {

                #region Add Inventaire

                string connectionString = _IConfiguration.GetConnectionString("SQLSERVER_InnovTouch");
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand maCommande;
                maCommande = new SqlCommand();
                maCommande.CommandText = "Add_inventaire";
                maCommande.CommandType = CommandType.StoredProcedure;
                maCommande.Connection = sqlConnection;

                SqlParameter parm1 = new SqlParameter("@number", SqlDbType.NVarChar);
                parm1.Value = model.number;
                maCommande.Parameters.Add(parm1);

                SqlParameter parm2 = new SqlParameter("@desciption", SqlDbType.NVarChar);
                parm2.Value = model.description;
                maCommande.Parameters.Add(parm2);

                SqlParameter parm3 = new SqlParameter("@stockPosition", SqlDbType.NVarChar);
                parm3.Value = model.stockPosition;
                maCommande.Parameters.Add(parm3);

                SqlParameter parm4 = new SqlParameter("@valorisationDate", SqlDbType.NVarChar);
                parm4.Value = model.valorisationDate;
                maCommande.Parameters.Add(parm4);

                SqlParameter parm5 = new SqlParameter("@magasinid", SqlDbType.Int);
                parm5.Value = model.Magasin.Id;
                maCommande.Parameters.Add(parm5);

                SqlParameter parm6 = new SqlParameter("@RayoneId", SqlDbType.Int);
                parm6.Value = 3;
                maCommande.Parameters.Add(parm6);

                sqlConnection.Open();
                int Resulte = maCommande.ExecuteNonQuery();
                sqlConnection.Close();

                if (Resulte == 1)
                {
                    Responce.Message = "inventaire été ajoute avec success.";
                    Responce.Data = 1;
                    Responce.Succeeded = true;
                }
                else
                {
                    Responce.Message = $"Echec d'ajout inventaire.";
                    Responce.Data = 0;
                    Responce.Succeeded = false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}";
                Responce.Data = 0;
                Responce.Succeeded = false;
            }

            return Responce;
        }
        public Response<int> CreateEmplacement(Emplacement model)
        {
            var Responce = new Response<int>();
 
            var Checkex = _unitOfWork.Emplacement.Where(x => x.Inventory.Id == model.Inventory.Id &&
                                                        x.Rayone.Id == model.Rayone.Id
                                                       )
                                                   .Include(inv => inv.Inventory)
                                                   .Include(ray => ray.Rayone)
                                                   .FirstOrDefault();

             

            if (Checkex != null )
            {
                var TypeInventaire = Checkex.TypeInventaire;
                var NewTYpe = model.TypeInventaire;

                if(TypeInventaire == NewTYpe)
                {
                    Responce.Message = $"Emplacement Déjà existe.";
                    Responce.Data = 0;
                    Responce.Succeeded = false;
                }
                else
                {
                    try
                    {
                        string connectionString = _IConfiguration.GetConnectionString("SQLSERVER_InnovTouch");
                        SqlConnection sqlConnection = new SqlConnection(connectionString);

                        SqlCommand maCommande;
                        maCommande = new SqlCommand();
                        maCommande.CommandText = "Create_Emplacement";
                        maCommande.CommandType = CommandType.StoredProcedure;
                        maCommande.Connection = sqlConnection;

                        SqlParameter parm1 = new SqlParameter("@Idinventaire", SqlDbType.Int);
                        parm1.Value = model.Inventory.Id;
                        maCommande.Parameters.Add(parm1);

                        SqlParameter parm2 = new SqlParameter("@RayoneId", SqlDbType.Int);
                        parm2.Value = model.Rayone.Id;
                        maCommande.Parameters.Add(parm2);

                        SqlParameter parm3 = new SqlParameter("@typeInventaire", SqlDbType.Int);
                        parm3.Value = model.TypeInventaire;
                        maCommande.Parameters.Add(parm3);

                        SqlParameter parm4 = new SqlParameter("@NumberEmplacement", SqlDbType.Int);
                        parm4.Value = model.NumberEmplacement;
                        maCommande.Parameters.Add(parm4);

                        sqlConnection.Open();
                        int Resulte = maCommande.ExecuteNonQuery();
                        sqlConnection.Close();

                        if (Resulte == 1)
                        {
                            DetailsLot detail = new DetailsLot();

                            for (int i = 1; i <= model.NumberEmplacement; i++)
                            {
                                detail.IdInventaire = model.Inventory.Id;
                                detail.IdRayone = model.Rayone.Id;
                                detail.Type = model.TypeInventaire;
                                detail.NumberLot = i;
                                detail.Libbele = $"Lot {i}";
                                detail.CodeIn = CheckHashRandom();
                                detail.CodeOut = CheckHashRandom();
                                detail.IsScanned = false;
                                ProcdureAddDetailsLot(detail);
                            }
                            Responce.Message = "emplacement été ajoute avec success.";
                            Responce.Data = 1;
                            Responce.Succeeded = true;
                        }
                        else
                        {
                            Responce.Message = $"Echec d'ajout emplacement.";
                            Responce.Data = 0;
                            Responce.Succeeded = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Responce.Message = $"Exception : {ex.Message}";
                        Responce.Data = 0;
                        Responce.Succeeded = false;
                    }
                }
            }
            else
            {
                try
                {
                    string connectionString = _IConfiguration.GetConnectionString("SQLSERVER_InnovTouch");
                    SqlConnection sqlConnection = new SqlConnection(connectionString);

                    SqlCommand maCommande;
                    maCommande = new SqlCommand();
                    maCommande.CommandText = "Create_Emplacement";
                    maCommande.CommandType = CommandType.StoredProcedure;
                    maCommande.Connection = sqlConnection;

                    SqlParameter parm1 = new SqlParameter("@Idinventaire", SqlDbType.Int);
                    parm1.Value = model.Inventory.Id;
                    maCommande.Parameters.Add(parm1);

                    SqlParameter parm2 = new SqlParameter("@RayoneId", SqlDbType.Int);
                    parm2.Value = model.Rayone.Id;
                    maCommande.Parameters.Add(parm2);

                    SqlParameter parm3 = new SqlParameter("@typeInventaire", SqlDbType.Int);
                    parm3.Value = model.TypeInventaire;
                    maCommande.Parameters.Add(parm3);

                    SqlParameter parm4 = new SqlParameter("@NumberEmplacement", SqlDbType.Int);
                    parm4.Value = model.NumberEmplacement;
                    maCommande.Parameters.Add(parm4);

                    sqlConnection.Open();
                    int Resulte = maCommande.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (Resulte == 1)
                    {
                        DetailsLot detail = new DetailsLot();

                        for (int i = 1; i <= model.NumberEmplacement; i++)
                        {
                            detail.IdInventaire = model.Inventory.Id;
                            detail.IdRayone = model.Rayone.Id;
                            detail.Type = model.TypeInventaire;
                            detail.NumberLot = i;
                            detail.Libbele = $"Lot {i}";
                            detail.CodeIn = CheckHashRandom();
                            detail.CodeOut = CheckHashRandom();
                            detail.IsScanned = false;
                            ProcdureAddDetailsLot(detail);
                        }
                        Responce.Message = "emplacement été ajoute avec success.";
                        Responce.Data = 1;
                        Responce.Succeeded = true;
                    }
                    else
                    {
                        Responce.Message = $"Echec d'ajout emplacement.";
                        Responce.Data = 0;
                        Responce.Succeeded = false;
                    }
                }
                catch (Exception ex)
                {
                    Responce.Message = $"Exception : {ex.Message}";
                    Responce.Data = 0;
                    Responce.Succeeded = false;
                }
            }
            return Responce;
        }
        public Response<bool> EditInventaire(InventoryDTO model)
        {
            var Responce = new Response<bool>();
            try
            {
                string connectionString = _IConfiguration.GetConnectionString("SQLSERVER_InnovTouch");
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand maCommande;
                maCommande = new SqlCommand();
                maCommande.CommandText = "Update_inventaire";
                maCommande.CommandType = CommandType.StoredProcedure;
                maCommande.Connection = sqlConnection;

                SqlParameter parm1 = new SqlParameter("@number", SqlDbType.NVarChar);
                parm1.Value = model.number;
                maCommande.Parameters.Add(parm1);

                SqlParameter parm2 = new SqlParameter("@nomberemplacement", SqlDbType.Int);
                parm2.Value = model.NumberEmplacement;
                maCommande.Parameters.Add(parm2);

                SqlParameter parm3 = new SqlParameter("@type", SqlDbType.Int);
                parm3.Value = model.typeInventaire;
                maCommande.Parameters.Add(parm3);

                sqlConnection.Open();
                int Resulte = maCommande.ExecuteNonQuery();
                sqlConnection.Close();

                if (Resulte == 1)
                {
                    Responce.Message = "inventaire été modifier avec success.";
                    Responce.Data = true;
                    Responce.Succeeded = true;
                }
                else
                {
                    Responce.Message = $"Echec modifiation inventaire.";
                    Responce.Data = false;
                    Responce.Succeeded = false;
                }
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}";
                Responce.Data = false;
                Responce.Succeeded = false;
            }
            return Responce;
        }
        public async Task<Response<List<ExportExcelModelDto>>> GetAll()
        {
            var Responce = new Response<List<ExportExcelModelDto>>();
            try
            {
                var Resulte = _unitOfWork.Inventaire.All().Include(x => x.Produits).ToList();

                List<ExportExcelModelDto> ListModels = new List<ExportExcelModelDto>();

                if (Resulte.Any())
                {

                    foreach (var item in Resulte)
                    {
                        ExportExcelModelDto model = new ExportExcelModelDto();
                        model.inventaire = item.inventaire;
                        model.username = item.username;
                        model.site = item.site;
                        model.zone = item.zone;
                        model.emplacement = item.emplacement;

                        foreach (var Item2 in item.Produits)
                        {
                            model.Id = Item2.id;
                            model.codebar = Item2.barcode;
                            model.status = Item2.status;
                            model.description = Item2.description;
                            model.stockUnit = Item2.stockUnit;
                            model.averageWeight = Item2.averageWeight;
                            model.quantity = Item2.quantity;
                            model.salePrice = Item2.salePrice;
                            model.seqvl = Item2.seqvl;
                            ListModels.Add(model);
                        }
                    }

                    Responce.Data = ListModels.OrderBy(x=>x.Id).ToList();
                    Responce.Succeeded = true;
                    Responce.Errors = null;
                    Responce.Message = "there is items of inventaires";

                }
                else
                {
                    Responce.Data = null;
                    Responce.Succeeded = false;
                    Responce.Errors = null;
                    Responce.Message = "No Items in Invenatire";
                }
            }
            catch (Exception ex)
            {
                Responce.Data = null;
                Responce.Succeeded = false;
                Responce.Errors = null;
                Responce.Message = $"exption : {ex.Message}";
            }
            return Responce;
        }
        public Response<List<DAL.InnovTouch.DOMAIN.Models.Inventaire.Inventory>> GetAllInventaire()
        {
            var Responce = new Response<List<DAL.InnovTouch.DOMAIN.Models.Inventaire.Inventory>>();
            #region Attribute
            List<DAL.InnovTouch.DOMAIN.Models.Inventaire.Inventory> Inventory = new List<DAL.InnovTouch.DOMAIN.Models.Inventaire.Inventory>();
            DAL.InnovTouch.DOMAIN.Models.Entite.Magasin mag = new DAL.InnovTouch.DOMAIN.Models.Entite.Magasin();
            DAL.InnovTouch.DOMAIN.Models.Inventaire.Rayone Ray = new DAL.InnovTouch.DOMAIN.Models.Inventaire.Rayone();
            #endregion
            try
            {
                string connectionString = _IConfiguration.GetConnectionString("SQLSERVER_InnovTouch");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("get_inventaires", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        DAL.InnovTouch.DOMAIN.Models.Inventaire.Inventory model = new DAL.InnovTouch.DOMAIN.Models.Inventaire.Inventory();

                        #region - Inventaire

                        model.Id = (int)sdr["Id"];
                        model.number = (string)sdr["number"];
                        model.description = (string)sdr["description"];
                        model.stockPosition = (string)sdr["stockPosition"];
                        model.NumberEmplacement = (int)sdr["NumberEmplacement"];
                        model.Type = (ReserveMagasin)(int)sdr["Type"];

                        #endregion

                        #region - Magasin

                        mag.Id = (int)sdr["MagasinId"];
                        mag.Code = (string)sdr["Code"];
                        mag.Libelle = (string)sdr["Libelle"];
                        mag.Adresse = (string)sdr["Adresse"];
                        mag.Tel = (string)sdr["Tel"];
                        mag.Fax = (string)sdr["Fax"];
                        mag.Email = (string)sdr["Email"];
                        mag.RC = (string)sdr["RC"];
                        mag.Patente = (string)sdr["Patente"];
                        mag.IF = (string)sdr["IF"];
                        mag.CNSS = (string)sdr["CNSS"];
                        #endregion

                        #region - Rayone

                        Ray.Id = (int)sdr["RayoneId"];
                        Ray.Name = (string)sdr["Name"];
                        Ray.IdRayone = (int)sdr["IdRayone"];

                        #endregion

                        model.Magasin = mag;
                        model.Rayone = Ray;
                        Inventory.Add(model);
                    }
                }

                if (Inventory.Any())
                {
                    Responce.Data = Inventory;
                    Responce.Succeeded = true;
                    Responce.Errors = null;
                    Responce.Message = $" There is same Items";
                }
                else
                {
                    Responce.Data = null;
                    Responce.Succeeded = false;
                    Responce.Errors = null;
                    Responce.Message = $" There is no same Items";
                }
            }
            catch (Exception ex)
            {
                Responce.Data = null;
                Responce.Succeeded = false;
                Responce.Errors = null;
                Responce.Message = $"Exception : {ex.Message}";
            }
            return Responce;
        }
        public async Task<Response<List<MagasinDto>>> GetAllMagsin()
        {
            var Resulte = new Response<List<MagasinDto>>();
            try
            {
                var listofmodel = _unitOfWork.Magasins.All();

                if (listofmodel.Any())
                {
                    var map = _mapper.Map<List<MagasinDto>>(listofmodel);
                    Resulte.Data = map;
                    Resulte.Succeeded = true;
                    Resulte.Errors = null;
                    Resulte.Message = "there is items of inventaires";

                }
                else
                {
                    Resulte.Data = null;
                    Resulte.Succeeded = false;
                    Resulte.Errors = null;
                    Resulte.Message = "No Items in Invenatire";
                }
            }
            catch (Exception ex)
            {
                Resulte.Data = null;
                Resulte.Succeeded = false;
                Resulte.Errors = null;
                Resulte.Message = $"exption : {ex.Message}";
            }
            return Resulte;
        }
        public Response<List<DAL.InnovTouch.DOMAIN.Models.Inventaire.Rayone>> GetAllRayone()
        {
            var Responce = new Response<List<DAL.InnovTouch.DOMAIN.Models.Inventaire.Rayone>>();
            try
            {
                var Resulte = _unitOfWork.Rayone.All().ToList();

                if (Resulte.Any())
                {
                    Responce.Data = (List<DAL.InnovTouch.DOMAIN.Models.Inventaire.Rayone>)Resulte;
                    Responce.Succeeded = true;
                    Responce.Errors = null;
                    Responce.Message = "There is item aboute Rayone";
                }
                else
                {
                    Responce.Data = null;
                    Responce.Succeeded = false;
                    Responce.Errors = null;
                    Responce.Message = "There is no item aboute Rayone";
                }
            }
            catch (Exception ex)
            {
                Responce.Data = null;
                Responce.Succeeded = false;
                Responce.Errors = null;
                Responce.Message = $"Exception : {ex.Message}";
            }
            return Responce;
        }
        static string CheckHashRandom()
        {
            HashSet<long> generatedNumbers = new HashSet<long>();
            Random random = new Random();
            long randomNumber = GenerateRandom13DigitNumber(random);
            if (!generatedNumbers.Contains(randomNumber))
            {
                generatedNumbers.Add(randomNumber);
            }
            return randomNumber.ToString();
        }
        static long GenerateRandom13DigitNumber(Random random)
        {
            long min = 1000000000000;
            long max = 9999999999999;
            return (long)(random.NextDouble() * (max - min + 1)) + min;
        }
        public void ProcdureAddDetailsLot(DetailsLot lot)
        {
            string connectionString = _IConfiguration.GetConnectionString("SQLSERVER_InnovTouch");
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand maCommande;
            maCommande = new SqlCommand();
            maCommande.CommandText = "Create_Details_lot";
            maCommande.CommandType = CommandType.StoredProcedure;
            maCommande.Connection = sqlConnection;

            SqlParameter parm1 = new SqlParameter("@Idinventaire", SqlDbType.Int);
            parm1.Value = lot.IdInventaire;
            maCommande.Parameters.Add(parm1);

            SqlParameter parm2 = new SqlParameter("@RayoneId", SqlDbType.Int);
            parm2.Value = lot.IdRayone;
            maCommande.Parameters.Add(parm2);

            SqlParameter parm3 = new SqlParameter("@typeInventaire", SqlDbType.Int);
            parm3.Value = lot.Type;
            maCommande.Parameters.Add(parm3);

            SqlParameter parm4 = new SqlParameter("@Numberlot", SqlDbType.Int);
            parm4.Value = lot.NumberLot;
            maCommande.Parameters.Add(parm4);

            SqlParameter parm5 = new SqlParameter("@Libbele", SqlDbType.NVarChar);
            parm5.Value = lot.Libbele;
            maCommande.Parameters.Add(parm5);

            SqlParameter parm6 = new SqlParameter("@CodeIn", SqlDbType.NVarChar);
            parm6.Value = lot.CodeIn;
            maCommande.Parameters.Add(parm6);

            SqlParameter parm7 = new SqlParameter("@CodeOut", SqlDbType.NVarChar);
            parm7.Value = lot.CodeOut;
            maCommande.Parameters.Add(parm7);

            sqlConnection.Open();
            int Resulte = maCommande.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public Response<List<Emplacement>> GetAllEmplacement()
        {
            var Responce = new Response<List<Emplacement>>();
            try
            {
                var Resulte = _unitOfWork.Emplacement.All()
                                                     .Include(inv => inv.Inventory)
                                                     .Include(ray => ray.Rayone)
                                                     .ToList();

                Responce.Data = Resulte;
                Responce.Succeeded = true;
                Responce.Errors = null;
                Responce.Message = "there is items of inventaires";
            }
            catch (Exception ex)
            {
                Responce.Data = null;
                Responce.Succeeded = false;
                Responce.Errors = null;
                Responce.Message = $"Exception : {ex.Message}";
            }
            return Responce;
        }
        public Response<int> EditEmplacement(Emplacement model)
        {
            var Responce = new Response<int>();
            try
            {
                string connectionString = _IConfiguration.GetConnectionString("SQLSERVER_InnovTouch");
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand maCommande;
                maCommande = new SqlCommand();
                maCommande.CommandText = "Update_emplacement";
                maCommande.CommandType = CommandType.StoredProcedure;
                maCommande.Connection = sqlConnection;

                SqlParameter parm1 = new SqlParameter("@number", SqlDbType.Int);
                parm1.Value = model.Id;
                maCommande.Parameters.Add(parm1);

                SqlParameter parm2 = new SqlParameter("@nomberemplacement", SqlDbType.Int);
                parm2.Value = model.NumberEmplacement;
                maCommande.Parameters.Add(parm2);

                SqlParameter parm3 = new SqlParameter("@type", SqlDbType.Int);
                parm3.Value = model.TypeInventaire;
                maCommande.Parameters.Add(parm3);

                sqlConnection.Open();
                int Resulte = maCommande.ExecuteNonQuery();
                sqlConnection.Close();

                if (Resulte == 1)
                {
                    Responce.Message = "emplacement été modifier avec success.";
                    Responce.Data = 1;
                    Responce.Succeeded = true;
                }
                else
                {
                    Responce.Message = $"Echec modifiation emplacement.";
                    Responce.Data = 0;
                    Responce.Succeeded = false;
                }
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}";
                Responce.Data = 0;
                Responce.Succeeded = false;
            }

            return Responce;
        }
        public Response<int> DeleteEmplacement(Emplacement emp)
        {
            var Responce = new Response<int>();
            try
            {
                string connectionString = _IConfiguration.GetConnectionString("SQLSERVER_InnovTouch");
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand maCommande;
                maCommande = new SqlCommand();
                maCommande.CommandText = "delete_emplacement";
                maCommande.CommandType = CommandType.StoredProcedure;
                maCommande.Connection = sqlConnection;

                SqlParameter parm1 = new SqlParameter("@idemplacement", SqlDbType.Int);
                parm1.Value = emp.Id;
                maCommande.Parameters.Add(parm1);

                sqlConnection.Open();
                int Resulte = maCommande.ExecuteNonQuery();
                sqlConnection.Close();

                Responce.Message = $"Bien Supprrmier";
                Responce.Data = 1;
                Responce.Succeeded = true;
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}.";
                Responce.Data = 0;
                Responce.Succeeded = true;
            }

            return Responce;
        }
        public Response<List<DetailsLot>> GetAllDetailsLot()
        {
            var Responce = new Response<List<DetailsLot>>();
            try
            {
                List<DetailsLot> detailsLots = new List<DetailsLot>();

                var details = _unitOfWork.DetailsLot.All().ToList();

                foreach (var item in details)
                {
                    item.NomInventaire = _unitOfWork.Inventory.Where(x => x.Id == item.IdInventaire).First().description;
                    item.Nomrayone = _unitOfWork.Rayone.Where(x => x.Id == item.IdRayone).First().Name;
                    item.NomInventaire = item.NomInventaire;
                    item.StatusLOt = item.IsScanned == true ? $"{item.Libbele} Valide" : $" {item.Libbele} Non Valide";
                    detailsLots.Add(item);
                }

                if (details.Any())
                {
                    Responce.Message = $"Contains Items";
                    Responce.Data = detailsLots;
                    Responce.Succeeded = true;
                }
                else
                {
                    Responce.Message = $"There is no  Items.";
                    Responce.Data = null;
                    Responce.Succeeded = false;
                }
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}";
                Responce.Data = null;
                Responce.Succeeded = false;
            }
            return Responce;
        }
        public Response<bool> UpdateQentity(ExportExcelModelDto model)
        {
            #region Update Qentite
            var Responce = new Response<bool>();
            try
            {
                string connectionString = _IConfiguration.GetConnectionString("SQLSERVER_InnovTouch");
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand maCommande;
                maCommande = new SqlCommand();
                maCommande.CommandText = "update_qentity";
                maCommande.CommandType = CommandType.StoredProcedure;
                maCommande.Connection = sqlConnection;

                SqlParameter parm1 = new SqlParameter("@id", SqlDbType.Int);
                parm1.Value = model.Id;
                maCommande.Parameters.Add(parm1);

                SqlParameter parm2 = new SqlParameter("@Qentity", SqlDbType.Int);
                parm2.Value = model.NewQentity;
                maCommande.Parameters.Add(parm2);


                sqlConnection.Open();
                int Resulte = maCommande.ExecuteNonQuery();
                sqlConnection.Close();

                if (Resulte == 1)
                {
                    Responce.Message = "inventaire été modifier avec success.";
                    Responce.Data = true;
                    Responce.Succeeded = true;
                }
                else
                {
                    Responce.Message = $"Echec modifiation inventaire.";
                    Responce.Data = false;
                    Responce.Succeeded = false;
                }
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}";
                Responce.Data = false;
                Responce.Succeeded = false;
            }
            return Responce;

            #endregion
        }
        public Response<DetailsLot> GetCodeIn(InventairesModel model)
        {
            #region Code In
            var Responce = new Response<DetailsLot>();
            try
            {
                var Code = _unitOfWork.DetailsLot.Where(
                                       x => x.IdInventaire == model.IdInventaire
                                       && x.IdRayone == model.IdRayone 
                                       && x.Libbele == model.NomEmplacement
                                       && x.Type == model.TypeInventaire).FirstOrDefault();

                if (!string.IsNullOrEmpty(Code.CodeIn))
                {
                    Responce.Message = "inventaire été modifier avec success.";
                    Responce.Data = Code;
                    Responce.Succeeded = true;
                }
                else
                {
                    Responce.Message = $"Echec modifiation inventaire.";
                    Responce.Data = null;
                    Responce.Succeeded = false;
                }
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}";
                Responce.Data = null;
                Responce.Succeeded = false;
            }
            return Responce;
            #endregion
        }
        public Response<bool> DeleteInventaire(int id)
        {
            #region Delete Inventaire
            var Responce = new Response<bool>();
            try
            {
                var inventaire = _unitOfWork.Inventory.Where(x => x.Id == id).First();
                _unitOfWork.Inventory.Delete(inventaire);
                _unitOfWork.Save();
                Responce.Message = $"Bien Supprrmier";
                Responce.Data = true;
                Responce.Succeeded = true;
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}.";
                Responce.Data = false;
                Responce.Succeeded = true;
            }
            return Responce;
            #endregion
        }
        public Response<bool> ValidationLot(InventairesModel model)
        {
            var Responce = new Response<bool>();
            try
            {
                string connectionString = _IConfiguration.GetConnectionString("SQLSERVER_InnovTouch");
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand maCommande;
                maCommande = new SqlCommand();
                maCommande.CommandText = "Update_Scanned_lot";
                maCommande.CommandType = CommandType.StoredProcedure;
                maCommande.Connection = sqlConnection;

                SqlParameter parm1 = new SqlParameter("@idinventaire", SqlDbType.Int);
                parm1.Value = model.IdInventaire;
                maCommande.Parameters.Add(parm1);

                SqlParameter parm2 = new SqlParameter("@idrayone", SqlDbType.Int);
                parm2.Value = model.IdRayone;
                maCommande.Parameters.Add(parm2);


                SqlParameter parm3 = new SqlParameter("@libbele", SqlDbType.NVarChar);
                parm3.Value = model.NomEmplacement;
                maCommande.Parameters.Add(parm3);


                SqlParameter parm4 = new SqlParameter("@Type", SqlDbType.Int);
                parm4.Value = model.TypeInventaire;
                maCommande.Parameters.Add(parm4);

                sqlConnection.Open();
                int Resulte = maCommande.ExecuteNonQuery();
                sqlConnection.Close();

                if (Resulte == 1)
                {
                    Responce.Message = "inventaire été modifier avec success.";
                    Responce.Data = true;
                    Responce.Succeeded = true;
                }
                else
                {
                    Responce.Message = $"Echec modifiation inventaire.";
                    Responce.Data = false;
                    Responce.Succeeded = false;
                }
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}";
                Responce.Data = false;
                Responce.Succeeded = false;
            }
            return Responce;
        }
    }
}
