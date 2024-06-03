using AutoMapper;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.Models.Entite;
using DAL.InnovTouch.DOMAIN.Models.Role;
using Microsoft.EntityFrameworkCore;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Role;
using Shared.Models;
using Shared.Models.OUT;
using Shared.Models.REST;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
 

namespace BLL
{
    public class UserService : BaseService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork iUnitOfWork , IMapper mapper)
        {
            _IUnitOfWork = iUnitOfWork;
            _mapper = mapper;
        }
        public Response<UtilisateurDto> Authentification(UtilisateurDto user )
        {
            try
            {

                var UserInfo = _IUnitOfWork.Utilisateurs.Where(x => x.Login == user.Login && x.Password == user.Password).Include(Mag => Mag.Magasin).FirstOrDefault() ;

                var resultat = new Response<UtilisateurDto>();
                if (UserInfo  !=  null || UserInfo.Email != "")
                {
                    resultat.Succeeded = true;
                    resultat.Message = "User Found !";
                    resultat.Data = _mapper.Map<UtilisateurDto>(UserInfo);
                    return resultat;
                }
                else
                {
                    resultat.Succeeded = true;
                    resultat.Message = "Uutlisateur n'exits pas ";
                    resultat.Data = null;
                    return resultat;
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Shared.Models.Response<bool> AddUser(UtilisateurDto user)
        {
            var Responce = new Shared.Models.Response<bool>();
            var Mapper = _mapper.Map<Utilisateur>(user);

            try
            {
                _IUnitOfWork.Utilisateurs.Create(Mapper);
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

        public Response<bool> UpdateUser(UtilisateurDto user)
        {
            var Responce = new Shared.Models.Response<bool>();
            var Mapper = _mapper.Map<Utilisateur>(user);

            try
            {
                _IUnitOfWork.Utilisateurs.Update(Mapper);
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

        public Response<bool> DeleteUser(UtilisateurDto user)
        {
            var Responce = new Shared.Models.Response<bool>();
            var Mapper = _mapper.Map<Utilisateur>(user);

            try
            {
                _IUnitOfWork.Utilisateurs.Delete(Mapper);
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

        public Response<List<UtilisateurDto>> GetAllUser()
        {
            var Responce = new Shared.Models.Response<List<UtilisateurDto>>();

            try
            {
                var Resulte = _IUnitOfWork.Utilisateurs.All().ToList();

                if (Resulte.Count() != 0)
                {
                    Responce.Message = " count != 0";
                    Responce.Succeeded = true;
                    Responce.Data = _mapper.Map<List<UtilisateurDto>>(Resulte);
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
