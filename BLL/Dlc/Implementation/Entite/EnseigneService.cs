using AutoMapper;
using BLL.InnovTouch.Contrat.Entite;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.Models.OUT.GenererNumeroArrivageResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.Implementation.Entite
{
    public class EnseigneService : IEnseigneService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<EnseigneService> _logger;
        public EnseigneService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<EnseigneService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _logger.LogInformation("EnseigneService(...)");
        }

        public async Task<Response<List<EnseigneDto>>> AllAsync()
        {
            _logger.LogInformation("AllAsync(...)");
            Response<List<EnseigneDto>> resultat = new Response<List<EnseigneDto>>();
            try
            {
                var enseignes = await _unitOfWork.Enseignes
                    .All()
                    .OrderBy(e => e.Libelle)
                    .ToListAsync();
                resultat.Succeeded = true;
                resultat.Data = _mapper.Map<List<EnseigneDto>>(enseignes);
                _logger.LogInformation($"enseignes count:{resultat.Data.Count}");
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc AllAsync");
            }
            return resultat;
        }
    }
}
