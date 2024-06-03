using AutoMapper;
using BLL.InnovTouch.Contrat.Role;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.DTO;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.Implementation.Role
{
    public class ProfileService: IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProfileService> _logger;
        private readonly IMapper _mapper;
        public ProfileService(IUnitOfWork unitOfWork, ILogger<ProfileService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _logger.LogInformation("ProfileService(...)");
        }

        public async Task<Response<List<ProfileDto>>> GetAllByEnseigneIdAsync(int id)
        {
            _logger.LogInformation($"GetAllByEnseigneIdAsync(id:{id})");
            var resultat = new Response<List<ProfileDto>>();
            try
            {
                var profile = await _unitOfWork.Profiles
                    .WhereAsync(p => p.EnseignesId == id);
                
                resultat.Succeeded = true;
                var profileDto = _mapper.Map<List<ProfileDto>>(profile);
                resultat.Data = profileDto;
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetAllByEnseigneIdAsync");
            }
            return resultat;
        }

        public async Task<Response<ProfileDto>> GetByIdAsync(int id)
        {
            _logger.LogInformation($"GetById(id:{id})");
            var resultat = new Response<ProfileDto>();
            try
            {
                var profile = await _unitOfWork.Profiles
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
                if(profile == null)
                {
                    resultat.Succeeded = true;
                    resultat.Message = $"Profile id:{id} non trouvé";
                    return resultat;
                }
                resultat.Succeeded = true;
                var profileDto = _mapper.Map<ProfileDto>(profile);

                //include les droits
                profileDto.Droits = _mapper.Map<List<DroitDto>>( await _unitOfWork.DroitProfiles
                      .Where(dp => dp.ProfileId == profileDto.Id)
                      .Include(dp => dp.Droit).Select( dp => dp.Droit ).ToListAsync());
                      

                resultat.Data = profileDto;

            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetById");
            }
            return resultat;
        }
    }
}
