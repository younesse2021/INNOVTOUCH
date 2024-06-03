using AutoMapper;
using BLL.InnovTouch.Contrat.Role;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DOMAIN.Models.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shared.DTO.InnovTouch.DTO.Bo;
using Shared.DTO.InnovTouch.DTO.Helper;
using Shared.DTO.InnovTouch.DTO.Role;
using Shared.Models.OUT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BLL.InnovTouch.Implementation.Role
{
    public class UtilisateurService : IUtilisateurService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UtilisateurService> _logger;
        private readonly IMapper _mapper;
        private readonly IProfileService _profileService;
        public string serverGold { get; set; }
        public string usernameGold { get; set; }
        public string passwordGold { get; set; }

        private readonly string _apiKey;

        public UtilisateurService(IUnitOfWork unitOfWork,
            ILogger<UtilisateurService> logger,
            IMapper mapper,
            IConfiguration configuration,
            IProfileService profileService
            )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _profileService = profileService;

            serverGold = configuration[$"ENV:Server_Gold"];
            usernameGold = configuration[$"ENV:Username_Gold"];
            passwordGold = configuration[$"ENV:Password_Gold"];
            _apiKey = configuration[$"BUILDVERSION"];

            _logger.LogInformation("UtilisateurService(...)");
        }

        public async Task<Response<UtilisateurDto>> GetBy(string userName, string password)
        {
            var resultat = new Response<UtilisateurDto>();
            try
            {
                var resultOracle = GetFromOracle(userName, password);
                if (!resultOracle.Succeeded)
                {
                    resultat.Message = resultOracle.Message;
                    resultat.Succeeded = false;
                    return resultat;
                }
                if (resultOracle.Succeeded && (resultOracle.Data == null || resultOracle.Data.Count == 0))
                {
                    resultat.Message = $"Echèc vérification de l'utilisateur :{userName} sur oracle";
                    resultat.Succeeded = true;
                    return resultat;
                }

                //utilisateur trouvé sur oracle
                var resultInnovTouch = await GetByLogin(userName);
                if (!resultInnovTouch.Succeeded)
                {
                    resultat.Succeeded = false;
                    resultat.Message = resultInnovTouch.Message;
                    return resultat;
                }
                if (resultInnovTouch.Data == null)
                {
                    resultat.Succeeded = true;
                    resultat.Message = resultInnovTouch.Message;
                    return resultat;
                }
                resultat.Succeeded = true;
                resultat.Data = resultInnovTouch.Data;
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetBy");
            }
            return resultat;
        }
        public async Task<Response<UtilisateurDto>> GetByLogin(string login)
        {
            _logger.LogInformation($"GetByLogin({login})");
            var resultat = new Response<UtilisateurDto>();
            try
            {
                var utilisateur = await _unitOfWork.Utilisateurs
                    .Where(u => u.Login == login)
                    //.Include(u => u.Profile)
                    // .ThenInclude(p => p.DroitsProfiles)
                    //.ThenInclude(dp => dp.Droit)
                    // .Include(u => u.Profile)
                    //.ThenInclude(p => p.Enseignes)
                    .FirstOrDefaultAsync();
                if (utilisateur == null || utilisateur.Id == 0)
                {
                    resultat.Succeeded = true;
                    resultat.Message = $"Utilisateur {login} non trouvé";
                    _logger.LogInformation($"Utilisateur {login} non trouvé sur InnovTouch");
                    return resultat;
                }
                resultat.Succeeded = true;
                var utilisateurDto = _mapper.Map<UtilisateurDto>(utilisateur);
                if (_profileService != null)
                {
                    //utilisateurDto.Profile = (await _profileService.GetByIdAsync(utilisateur.ProfileId.Value)).Data;
                }
                resultat.Data = utilisateurDto;
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetByLogin");
            }
            return resultat;
        }
        public async Task<Response<int>> CreateAsync(UtilisateurDto utilisateurDto)
        {
            _logger.LogInformation($"CreateAsync({utilisateurDto})");

            var resultat = new Response<int>();

            try
            {
                var utilisateurExist = await _unitOfWork.Utilisateurs
                    .AnyAsync(u => u.Login.ToUpper().Equals(utilisateurDto.Login.ToUpper()));
                if (utilisateurExist)
                {
                    resultat.Succeeded = true;
                    resultat.Message = "Login existe déja";
                    return resultat;
                }
                var utilisateur = _mapper.Map<Utilisateur>(utilisateurDto);
                await _unitOfWork.Utilisateurs.CreateAsync(GererPropNavigation(utilisateur));
                await _unitOfWork.SaveAsync();

                resultat.Succeeded = true;
                resultat.Message = "Utilisateur bien crée";
                resultat.Data = utilisateur.Id;
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc CreateAsync");
            }
            return resultat;
        }
        public async Task<Response<bool>> UpdateAsync(UtilisateurDto utilisateurDto)
        {
            _logger.LogInformation($"UpdateAsync({utilisateurDto})");
            var resultat = new Response<bool>();
            try
            {
                var utilisateurExist = await _unitOfWork.Utilisateurs
                    .AnyAsync(u => u.Id == utilisateurDto.Id);
                if (!utilisateurExist)
                {
                    resultat.Succeeded = true;
                    resultat.Message = "Utilisateur introuvable";
                    return resultat;
                }

                var utilisateur = _mapper.Map<Utilisateur>(utilisateurDto);
                _unitOfWork.Utilisateurs.Update(GererPropNavigation(utilisateur));
                resultat.Data = false;
                if (await _unitOfWork.SaveAsync() > 0)
                {
                    resultat.Message = "Utilisateur bien modifié";
                    resultat.Data = true;
                }
                resultat.Succeeded = true;

            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc UpdateAsync");
            }
            return resultat;
        }
        public async Task<Response<bool>> DeleteByIdAsync(int id)
        {
            _logger.LogInformation($"DeleteByIdAsync(id:{id})");
            var resultat = new Response<bool>();
            try
            {
                var utilisateur = await _unitOfWork.Utilisateurs
                    .WhereFirstAsync(u => u.Id == id);
                if (utilisateur == null || utilisateur.Id == 0)
                {
                    resultat.Succeeded = true;
                    resultat.Message = "Utilisateur introuvable";
                    return resultat;
                }
                _unitOfWork.Utilisateurs.Delete(utilisateur);
                resultat.Data = false;
                if (await _unitOfWork.SaveAsync() > 0)
                {
                    resultat.Message = "Utilisateur bien supprimé";
                    resultat.Data = true;
                }
                resultat.Succeeded = true;
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc DeleteByIdAsync");
            }
            return resultat;
        }
        public async Task<Response<UtilisateurDto>> GetByIdAsync(int id)
        {
            _logger.LogInformation($"GetByIdAsync(id:{id})");
            var resultat = new Response<UtilisateurDto>();
            try
            {
                var utilisateur = await _unitOfWork.Utilisateurs
                    .Where(u => u.Id == id)
                   // .Include(u => u.Profile)
                    .FirstOrDefaultAsync();
                if (utilisateur == null || utilisateur.Id == 0)
                {
                    resultat.Succeeded = true;
                    resultat.Message = "Utilisateur introuvable";
                    return resultat;
                }
                resultat.Succeeded = true;
                resultat.Data = _mapper.Map<UtilisateurDto>(utilisateur);
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetByIdAsync");
            }
            return resultat;
        }
        public async Task<Response<List<UtilisateurDto>>> AllAsync()
        {
            _logger.LogInformation($"AllAsync()");
            var resultat = new Response<List<UtilisateurDto>>();
            try
            {
                var utilisateurs = await _unitOfWork.Utilisateurs
                    .All()
                   // .Include(u => u.Profile)
                    .ToListAsync();
                resultat.Succeeded = true;
                resultat.Data = _mapper.Map<List<UtilisateurDto>>(utilisateurs);
                resultat.Message = $"Utilisateurs count:{resultat.Data?.Count}";
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetByIdAsync");
            }
            return resultat;
        }
        private Shared.Models.Response<List<AuthResponse>> GetFromOracle(string userName, string password)
        {
            //TODO
            //var biz = new UserService();
            //return biz.Authentification(server, username, password, userName, password);
            return null;
        }
        private Utilisateur GererPropNavigation(Utilisateur utilisateur)
        {
            return utilisateur;
        }
        public async Task<Response<UtilisateurBoDto>> ConnectAsync(string userName, string password)
        {
            _logger.LogInformation($"ConnectAsync({userName})");
            var resultat = new Response<UtilisateurBoDto>();
            try
            {
                var Resulte = _unitOfWork.Utilisateurs.Where(x => x.Login == userName && x.Password == password).FirstOrDefault();

                if (Resulte != null && !string.IsNullOrEmpty(Resulte.Login))
                {
                    UtilisateurBoDto utilisateur = null;

                    utilisateur = new UtilisateurBoDto()
                    {
                        UserName = Resulte.Login,
                        Password = Resulte.Password,
                        Token = new Shared.DTO.InnovTouch.DTO.JwtToken() { Token = _apiKey },
                        isConnected = true,
                        EnseigneId = Resulte.MagasinId.ToString()
                    };

                    resultat.Succeeded = true;
                    resultat.Data = utilisateur;
                    resultat.Message = $"utlisateur a nom : {Resulte.Nom} exits.";
                }
                else
                {
                    resultat.Succeeded = false;
                    resultat.Data = null;
                    resultat.Message = $"Une erreur est survenue lors de l'execution l'opération";
                }
            }
            catch (Exception ex)
            {
                resultat.Succeeded = false;
                resultat.Message = "Une erreur est survenue lors de l'execution l'opération";
                _logger.LogError(ex, "Echèc GetByLogin");
            }
            return resultat;
        }
    }
}
