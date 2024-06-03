 using AutoMapper;
using BLL;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.Models.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.DTO.InnovTouch.DTO.Role;
using Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class UserController : BaseController
    {
         private readonly IUnitOfWork _IUnitOfWork; 
         private readonly IMapper _mapper;
        public UserController(IUnitOfWork iUnitOfWork ,IMapper mapper)
        {
            _IUnitOfWork = iUnitOfWork;
            _mapper = mapper;
        } 

        [HttpPost("api/auth")]
        public IActionResult Authentification(UtilisateurDto user)
        {
            var biz = new UserService(_IUnitOfWork, _mapper);
            var response = biz.Authentification(user);
            return Ok(response);
        }
    }
}
