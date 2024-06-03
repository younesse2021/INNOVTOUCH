using AutoMapper;
using BLL.InnovTouch.Contrat.Entite;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.Implementation.Entite
{
    public class MagasinService : IMagasinService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<MagasinService> _logger;
        public MagasinService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MagasinService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _logger.LogInformation("MagasinService(...)");
        }

        public async Task<Response<List<MagasinDto>>> AllAsync()
        {
            _logger.LogInformation("AllAsync()");
            var resultat = new Response<List<MagasinDto>>();
            try
            {
                var magasins = await _unitOfWork.Magasins
                    .All()
                    .OrderBy(m => m.Libelle)
                    .ToListAsync();
                resultat.Succeeded = true;
                resultat.Data = _mapper.Map<List<MagasinDto>>(magasins);
                _logger.LogInformation($"magasins count:{resultat.Data.Count}");
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc AllAsync");
            }
            return resultat;
        }

        public async Task<Response<List<MagasinDto>>> GetByCodeEnseigneAsync(string codeEnseigne)
        {
            _logger.LogInformation($"GetByCodeEnseigneAsync(codeEnseigne:{codeEnseigne})");
            var resultat = new Response<List<MagasinDto>>();
            //try
            //{
            //    var magasins = null;
                    
            //    resultat.Succeeded = true;
            //    resultat.Data = _mapper.Map<List<MagasinDto>>(magasins);
            //    _logger.LogInformation($"magasins count:{resultat.Data.Count}");
            //}
            //catch (Exception ex)
            //{
            //    resultat.Succeeded = false;
            //    resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
            //    _logger.LogError(ex, "Echèc GetByCodeEnseigneAsync");
            //}
            return resultat;
        }

        public async Task<Response<MagasinDto>> GetByCodeAsync(string codeMagasin)
        {
            _logger.LogInformation($"GetByCodeAsync(codeMagasin:{codeMagasin})");
            var resultat = new Response<MagasinDto>();
            try
            {
                var magasin = await _unitOfWork.Magasins
                    .Where(m => m.Code.ToUpper().Equals(codeMagasin.ToUpper()))
                    //.Include(m => m.Enseigne)
                    .OrderBy(m => m.Libelle)
                    .FirstOrDefaultAsync();

                resultat.Succeeded = true;
                resultat.Data = _mapper.Map<MagasinDto>(magasin);
                _logger.LogInformation($"magasin :{magasin}");
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetByCodeAsync");
            }
            return resultat;
        }
    }
}
