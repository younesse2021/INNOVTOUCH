using AutoMapper;
using BLL;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.IN;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ArticleController : BaseController
    {

        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;

        public ArticleController(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            _IUnitOfWork = iUnitOfWork;
            _mapper = mapper;
        }
        [HttpPost("api/article")]
        public async Task<IActionResult> Article(ArticleInventaire model)
        {
            var biz = new ArticleService(_IUnitOfWork, _mapper);
            var response = await biz.ArticleInfos(model);
            return Ok(response);
        }
    }
}
