//using API.Controllers.Helper;
//using API.Filters;
//using AutoMapper;
//using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System;
//using System.Linq;
//using AutoMapper.Configuration;
//using BLL;
//using BLL.InnovTouch.Contrat.Role;
//using Shared.DTO.InnovTouch.DTO.Role;

//namespace API.Controllers.Utilisateurs
//{
//	public class UtilisateursController : BaseController
//	{
//		private readonly IUnitOfWork _IUnitOfWork;
//		private readonly IMapper _mapper;
//		private readonly IUtilisateurService _UtilisateurService;
//		private readonly IExportService _exportService;
//		private readonly ILogger<UtilisateursController> _logger;
//		private readonly IConfiguration _IConfiguration;

//		public UtilisateursController(IUnitOfWork iUnitOfWork, IMapper mapper, IUtilisateurService _UtilisateurService, IExportService exportService, ILogger<UtilisateurController> logger, IConfiguration iConfiguration)
//		{
//			_IUnitOfWork = iUnitOfWork;
//			_mapper = mapper;
//			_UtilisateurService = _UtilisateurService;
//			_exportService = exportService;
// 			_IConfiguration = iConfiguration;
//		}

//		[HttpPost("api/utilisateurs")]
//		public async Task<IActionResult> utilisateurs(UtilisateurDto model)
//		{
//			var biz = new UserService(_IUnitOfWork, _mapper);
//			var response = biz.GetAllUser();
//			return Ok(response);
//		}

//		[HttpPost("api/Utilisateur/create")]
//		public async Task<IActionResult> CreateUtilisateur(UtilisateurDto model)
//		{
//			var biz = new UserService(_IUnitOfWork, _mapper);
//			var response = biz.AddUser(model);
//			return Ok(response);
//		}
 
//	}
//}

