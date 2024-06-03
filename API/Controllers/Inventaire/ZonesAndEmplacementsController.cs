using AutoMapper;
using BLL;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.IN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ZonesAndEmplacementsController : BaseController
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;
        public ZonesAndEmplacementsController(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            _IUnitOfWork = iUnitOfWork;
            _mapper = mapper;
        }

        [HttpPost("api/zones/emplacements")]
        public async Task<IActionResult> ZonesEmplacements(ZonesEmplacementsModel model)
        {
            var biz = new ZonesEmplacementsService(_IUnitOfWork, _mapper);
            var response = await biz.ZonesEmplacements(model);
            return Ok(response);
        }
        [HttpPost("api/zones/emplacements/utilisation")]
        public async Task<IActionResult> CheckZoneEmplacement(ZonesEmplacementsModel model)
        {
            var biz = new ZonesEmplacementsService(_IUnitOfWork, _mapper);
            var response = await biz.CheckEmplacement(Base.Init().Server_,
                Base.Init().Username_,
                Base.Init().Password_,
                model.inventaire,
                model.emplacement);

            return Ok(response);
        }
    }
}
