using AutoMapper;
using BLL.Services.Contrat;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using Microsoft.Extensions.Configuration;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Inventaire;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EmplacementBiz
{
    public class EmplacementService : BaseService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmplacementService _IEmplacementService;
        private readonly IConfiguration _IIConfiguration;
        public EmplacementService(IUnitOfWork iUnitOfWork, IMapper mapper, IEmplacementService emplacementService, IConfiguration iConfiguration)
        {
            _IUnitOfWork = iUnitOfWork;
            _mapper = mapper;
            _IEmplacementService = emplacementService;
            _IIConfiguration = iConfiguration;
        }

       


    }
}
