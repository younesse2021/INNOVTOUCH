 using AutoMapper;
using BLL;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.Models.IN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ModelsController : BaseController
    {

        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;

        public ModelsController(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            _IUnitOfWork = iUnitOfWork;
             _mapper = mapper;
        }

        [HttpPost("api/user/models")]
        public async Task<IActionResult> Models(ModelsUserModel model)
        {
            var biz = new ModelsService(_IUnitOfWork, _mapper);
            var response = await biz.Models(model);
            return Ok(response);
        }
    }
}
