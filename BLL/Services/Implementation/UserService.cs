using AutoMapper;
using BLL.Services.Contrat;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.Models.Role;
using Microsoft.Extensions.Configuration;
using Shared.Models;
using Shared.Models.OUT.ListControlePrixResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BLL.Services.Implementation
{
    public class UserService : IuserService
    {

        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;
        private readonly IInentaireServicecs _IInentaireServicecs;
        private readonly IConfiguration _IIConfiguration;
        public UserService(IUnitOfWork iUnitOfWork, IMapper mapper, IInentaireServicecs inentaireServicecs, IConfiguration iConfiguration)
        {
            _IUnitOfWork = iUnitOfWork;
            _mapper = mapper;
            _IInentaireServicecs = inentaireServicecs;
            this._IIConfiguration = iConfiguration;
        }

        public Shared.Models.Response<bool> AddUser(Utilisateur user)
        {
            var Responce = new Shared.Models.Response<bool>();

            try
            {
                 _IUnitOfWork.Utilisateurs.Create(user);
                _IUnitOfWork.Save();

                Responce.Message = "L'Utilisateur et ajoute avec succes.";
                Responce.Succeeded = true;
                Responce.Data = true;
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}";
                Responce.Succeeded = false;
                Responce.Data = false;
            }

            return Responce;
        }

        public Response<bool> UpdateUser(Utilisateur user)
        {
            var Responce = new Shared.Models.Response<bool>();

            try
            {
                _IUnitOfWork.Utilisateurs.Update(user);
                _IUnitOfWork.Save();

                Responce.Message = "L'Utilisateur et ajoute avec succes.";
                Responce.Succeeded = true;
                Responce.Data = true;
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}";
                Responce.Succeeded = false;
                Responce.Data = false;
            }

            return Responce;
        }

        public Response<bool> DeleteUser(Utilisateur user)
        {
            var Responce = new Shared.Models.Response<bool>();

            try
            {
                _IUnitOfWork.Utilisateurs.Delete(user);
                _IUnitOfWork.Save();

                Responce.Message = "L'Utilisateur et ajoute avec succes.";
                Responce.Succeeded = true;
                Responce.Data = true;
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}";
                Responce.Succeeded = false;
                Responce.Data = false;
            }

            return Responce;
        }

        public Response<List<Utilisateur>> GetAllUser()
        {
            var Responce = new Shared.Models.Response<List<Utilisateur>>();

            try
            {
                var Resulte = _IUnitOfWork.Utilisateurs.All().ToList();

                if(Resulte.Count() != 0)
                {
                    Responce.Message = " count != 0";
                    Responce.Succeeded = true;
                    Responce.Data = (List<Utilisateur>)Resulte;
                }
                else
                {
                    Responce.Message = " count = 0";
                    Responce.Succeeded = true;
                    Responce.Data = null;
                }
               
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}";
                Responce.Succeeded = false;
                Responce.Data = null;
            }

            return Responce;
        }
    }
}
