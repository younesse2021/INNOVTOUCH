using AutoMapper;
using BLL.Services.Contrat;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shared.DTO.InnovTouch.DTO.Inventaire;
using Shared.Models;
using System;

namespace BLL.Services.Implementation
{
    public class EmplacementService : IEmplacementService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<EmplacementService> _logger;
        private readonly IConfiguration _IConfiguration;
        public EmplacementService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<EmplacementService> logger, IConfiguration iconfiguration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _IConfiguration = iconfiguration;
            _logger.LogInformation("EmplacementService(...)");
        }

        public Response<int> CreateEmplacement(EmplacementDto model)
        {
            var Responce = new Response<int>();
            try
            {
                //_unitOfWork.Emplacement.CreateAsync(model);
                _unitOfWork.Save();
                Responce.Message = "inventaire été ajoute avec success.";
                Responce.Data = 1;
                Responce.Succeeded = true;
            }
            catch (Exception ex)
            {
                Responce.Message = $"Exception : {ex.Message}";
                Responce.Data = 0;
                Responce.Succeeded = false;
            }
            return Responce;
        }
    }
}
