using API.Controllers.Helper;
using API.Filters;
using AutoMapper;
using BLL;
using BLL.Services.Contrat;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Inventaire;
using Shared.Models;
using Shared.Models.IN;
using Shared.Models.OUT.ModelsUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class InventaireController : BaseController
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;
        private readonly IInentaireServicecs _IInentaireServicecs;
        private readonly IExportService _exportService;
        private readonly ILogger<InventaireController> _logger;
        private readonly IConfiguration _IConfiguration;

        public InventaireController(IUnitOfWork iUnitOfWork, IMapper mapper, IInentaireServicecs iInentaireServicecs, IExportService exportService, ILogger<InventaireController> logger, IConfiguration iConfiguration)
        {
            _IUnitOfWork = iUnitOfWork;
            _mapper = mapper;
            _IInentaireServicecs = iInentaireServicecs;
            _exportService = exportService;
            _logger = logger;
            _IConfiguration = iConfiguration;
        }

        #region - Details Lot 
        [HttpGet("api/inventaire/GetAllLot")]
        public IActionResult GetAllLot()
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = biz.GetAllDetails();
            return Ok(response);
        }
        #endregion

        #region Emplacement

        [HttpPost("api/inventaire/ValidationLot")]
        public IActionResult ValidationLot(InventairesModel emp)
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = biz.ValidationLot(emp);
            return Ok(response);
        }

        [HttpPost("api/inventaire/CreateEmplacement")]
        public IActionResult CreateEmplacement(Emplacement emp)
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = biz.CreateEmplacement(emp);
            return Ok(response);
        }

        [HttpGet("api/inventaire/GetAllEmplacement")]
        public IActionResult GetAllEmplacement()
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = biz.GetAllEmplacement();
            return Ok(response);
        }

        [HttpPost("api/inventaire/EditEmplacement")]
        public IActionResult EditEmplacement(Emplacement details)
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = biz.EditEmplacement(details);
            return Ok(response);
        }

        [HttpPost("api/inventaire/DeleteEmplacement")]
        public IActionResult DeleteEmplacement(Emplacement emp)
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = biz.DeleteEmplacement(emp);
            return Ok(response);
        }

        #endregion

        #region Inventaire

        [HttpDelete("api/inventaire/DeleteInventaire/{id}")]
        public IActionResult DeleteInventaire(int id)
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = biz.DeleteInventaire(id);
            return Ok(response);
        }

        [HttpPut("api/inventaire/EditQentity")]
        public async Task<IActionResult> EditQentity(ExportExcelModelDto model)
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = biz.UpdateQentity(model);
            return Ok(response);
        }

        [HttpPost("api/inventaires")]
        public async Task<IActionResult> Inventaires(InventairesModel model)
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = await biz.Inventaires(model);
            return Ok(response);
        }

        [HttpPost("api/inventaire/create")]
        public async Task<IActionResult> CreateInventaire(CreateInventaireModel model)
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = await biz.CreateInventaire(model);
            return Ok(response);
        }

        [HttpGet("api/inventaire/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = await biz.GetAll();
            return Ok(response);
        }

        [BindFilter]
        [HttpPost("api/Inventaire/controle/export/filtre")]
        public async Task<IActionResult> ExportAll(int Id)
        {
            try
            {
                var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);

                var response = await biz.GetAll();

                List<ExportExcelModel> ListModels = new List<ExportExcelModel>();

                foreach (var item in response.Data)
                {
                    ExportExcelModel model = new ExportExcelModel();
                    model.Id = item.Id;
                    model.inventaire = item.inventaire;
                    model.username = item.username;
                    model.site = item.site;
                    model.zone = item.zone;
                    model.emplacement = item.emplacement;
                    model.barcode = item.codebar;
                    model.status = item.status;
                    model.description = item.description;
                    model.stockUnit = item.stockUnit;
                    model.quantity = item.quantity;
                    model.libStockUnit = item.libStockUnit;
                    model.averageWeight = item.averageWeight;
                    model.salePrice = item.salePrice;
                    model.seqvl = item.seqvl;
                    ListModels.Add(model);
                }

                //num_inventaire  code_article   libelle_article  qte
                var fileContents = _exportService.ExportListToExcel(
                    ListModels
                    .AsQueryable()
                    .Select(Inven =>
                    new
                    {
                        Inven.site,
                        Inven.inventaire,
                        Inven.barcode,
                        Inven.quantity,
                    })
                    , new string[] {
                        "Site ",
                        "N'inventaire",
                        "Code Barre",
                        "Quantité",
                });
                return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Liste contrôle Inove.xlsx");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [BindFilter]
        [HttpPost("api/Inventaire/controle/export/ExportLot")]
        public async Task<IActionResult> ExportLot(int Id)
        {
            try
            {
                var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);

                Response<List<DetailsLot>> response = biz.GetAllDetails();

                List<ExportLot> ListofLot = new List<ExportLot>();

                foreach (var item in response.Data)
                {
                    var inventaire = biz.GetAllInventaire().Data.Where(x => x.Id == item.IdInventaire).FirstOrDefault();
                    var ray = biz.GetAllRayone().Data.Where(x => x.Id == item.IdRayone).FirstOrDefault();

                    ExportLot model = new ExportLot();
                    model.Inventaire_number = inventaire.number;
                    model.Inventaire_Libbele = inventaire.description;
                    model.Inventaire_Rayone_Id = (int)ray.IdRayone;
                    model.Inventaire_Rayone_name = ray.Name;
                    model.Inventaire_numeber_emplaamcent = (int)item.NumberLot;
                    model.Inventaire_CodeIn = (string)item.CodeIn;
                    model.Inventaire_CodeOut = (string)item.CodeOut;
                    model.Inventaire_Nom_lot = item.Libbele;
                    ListofLot.Add(model);
                }


                var fileContents = _exportService.ExportListToExcel(
                   ListofLot
                   .AsQueryable()
                   .Select(model =>
                   new
                   {
                       model.Inventaire_number,
                       model.Inventaire_Libbele,
                       model.Inventaire_Rayone_Id,
                       model.Inventaire_Rayone_name,
                       model.Inventaire_Nom_lot,
                       model.Inventaire_numeber_emplaamcent,
                       model.Inventaire_CodeIn,
                       model.Inventaire_CodeOut,
                       
                   })
                   , new string[] {
                        "Nomber d'inventaire ",
                        "Libbele d'inventaire",
                        "Id Rayone",
                        "Nom Rayone",
                        "Nom  Lot",
                        "Id  Lot",
                        "Code Barre In",
                        "Code Barre Out",
                   });
                return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Liste contrôle Inove.xlsx");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("api/inventaire/GetAllMagasin")]
        public async Task<IActionResult> GetAllMagasin()
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = await biz.GetAllMagasin();
            return Ok(response);
        }

        [HttpPost("api/inventaire/AddInventaire")]
        public IActionResult AddInventaire(InventoryDTO model)
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = biz.AddInventaire(model);
            return Ok(response);
        }

        [HttpPut("api/inventaire/Edit")]
        public IActionResult EditInven(InventoryDTO model)
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = biz.EditInventaire(model);
            return Ok(response);
        }

        [HttpPost("upload")]
        public IActionResult UploadExcelFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    //**  read excel file and send data to database : **//
                }
                return Ok("File uploaded and processed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("api/inventaire/GetAllInventaire")]
        public IActionResult GetAllInventaire()
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = biz.GetAllInventaire();
            return Ok(response);
        }

        [HttpPost("api/inventaire/GetCodeIn")]
        public IActionResult GetCodeIn(InventairesModel model)
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = biz.GetCodeIn(model);
            return Ok(response);
        }

        #endregion

        #region Rayone

        [HttpGet("api/inventaire/GetAllRayone")]
        public async Task<IActionResult> GetAllRayone()
        {
            var biz = new InventaireService(_IUnitOfWork, _mapper, _IInentaireServicecs, _IConfiguration);
            var response = biz.GetAllRayone();
            return Ok(response);
        }

        #endregion

    }
}
