//using AutoMapper;
//using AutoMapper.Configuration;
//using BLL.Services.Contrat;
//using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
//using DAL.InnovTouch.DOMAIN.Models.Role;
//using Shared.DTO.InnovTouch.DTO.Entite;
//using Shared.DTO.InnovTouch.DTO.Inventaire;
//using Shared.DTO.InnovTouch.DTO.Role;
//using Shared.Models;
//using Shared.Models.IN;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BLL.UtilisateurBiz
//{
//	internal class UtilisateurService
//	{


//		private readonly IUnitOfWork _IUnitOfWork;
//		private readonly IMapper _mapper;
//		private readonly IInentaireServicecs _IInentaireServicecs;
//		private readonly IConfiguration _IIConfiguration;

//		public UtilisateurService(IUnitOfWork iUnitOfWork, IMapper mapper, IInentaireServicecs inentaireServicecs, IConfiguration iConfiguration)
//		{
//			_IUnitOfWork = iUnitOfWork;
//			_mapper = mapper;
//			_IInentaireServicecs = inentaireServicecs;
//			_IIConfiguration = iConfiguration;
//		}
//		public async Task<Response<Utilisateurs>> Utilisateurs(UtilisateurModel model)
//		{
//			try
//			{
//				Utilisateurs list = new Utilisateurs();
//				List<Utilisateur> ListOfInn = new List<Utilisateur>();
//				Utilisateur Utilisateur = new Utilisateur();

//				var ListOfIn = _IUnitOfWork.Inventory.All();

//				if (ListOfIn.Count() != 0)
//				{
//					var Responce = new Response<Utilisateurs>();
//					Responce.Succeeded = true;
//					Responce.Errors = null;

//					foreach (var item in ListOfIn)
//					{
//						ListOfInn.Add(new Utilisateur()
//						{
//							number = item.number,
//							description = item.description,
//							stockPosition = item.stockPosition,
//							valorisationDate = item.valorisationDate
//						});
//					}

//					list.inventory = ListOfInn;
//					Responce.Data = list;
//					return Responce;
//				}
//				else
//				{
//					var Responce = new Response<Utilisateurs>();
//					Responce.Succeeded = false;
//					Responce.Errors = new List<string>() { "Acune item inventaire" };
//					Responce.Data = null;
//					return Responce;
//				}
//			}
//			catch (Exception ex)
//			{
//				var Responce = new Response<Utilisateurs>();
//				Responce.Succeeded = false;
//				Responce.Errors = new List<string>() { "Acune item inventaire" };
//				Responce.Data = null;
//				Responce.Message = $"{ex.Message}";
//				return Responce;
//			}
//		}
//		public async Task<Response<bool>> CreateInventaire(CreateInventaireModel model)
//		{
//			try
//			{
//				return await _IInentaireServicecs.AddInventaire(model);
//			}
//			catch (Exception ex)
//			{
//				return new Response<bool>("Erreur s’est produite lors de l’exécution de l'opération.");
//			}
//		}
//		public async Task<Response<List<ExportExcelModelDto>>> GetAll()
//		{
//			try
//			{
//				return await _IInentaireServicecs.GetAll();
//			}
//			catch (Exception ex)
//			{
//				return new Response<List<ExportExcelModelDto>>("Erreur s’est produite lors de l’exécution de l'opération.");
//			}
//		}
//		public async Task<Response<List<MagasinDto>>> GetAllMagasin()
//		{
//			try
//			{
//				return await _IInentaireServicecs.GetAllMagsin();
//			}
//			catch (Exception ex)
//			{
//				return new Response<List<MagasinDto>>("Erreur s’est produite lors de l’exécution de l'opération.");
//			}
//		}
//		public Response<int> AddInventaire(UtilisateurDto model)
//		{
//			try
//			{
//				return _IInentaireServicecs.AddInventaire(model);
//			}
//			catch (Exception ex)
//			{
//				return new Response<int>("Erreur s’est produite lors de l’exécution de l'opération.");
//			}
//		}
//	}
//}
