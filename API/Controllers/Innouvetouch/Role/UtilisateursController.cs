using BLL.InnovTouch.Contrat.Role;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.DTO.InnovTouch.DTO.Bo;
using Shared.DTO.InnovTouch.DTO.Role;
using System;
using System.Threading.Tasks;

namespace API.Controllers.Innouvetouch.Role
{
    [Route("api/utilisateurs")]
    public class UtilisateursController : BaseController
    {
        public readonly ILogger<UtilisateursController> _logger;
        public readonly IUtilisateurService _utilisateurService;
        public UtilisateursController(ILogger<UtilisateursController> logger, IUtilisateurService utilisateurService)
        {
            _logger = logger;
            _utilisateurService = utilisateurService;
            _logger.LogInformation("UtilisateursController(...)");
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> Create(UtilisateurDto utilisateurDto)
        {
            _logger.LogInformation($"Create(UtilisateurDto:{utilisateurDto})");

            try
            {
                var reponse = await _utilisateurService.CreateAsync(utilisateurDto);
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update(UtilisateurDto utilisateurDto)
        {
            _logger.LogInformation($"Update(UtilisateurDto:{utilisateurDto})");
            try
            {
                var reponse = await _utilisateurService.UpdateAsync(utilisateurDto);
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("Delelte/{id}")]
        public async Task<IActionResult> DelteById(int id)
        {
            _logger.LogInformation($"DelteById(id:{id})");
            try
            {
                var reponse = await _utilisateurService.DeleteByIdAsync(id);
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"Get()");
            try
            {
                var reponse = await _utilisateurService.AllAsync();
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"GetById(id:{id})");
            try
            {
                var reponse = await _utilisateurService.GetByIdAsync(id);
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("bo/connect")]
        public async Task<IActionResult> ConnectToBo(UtilisateurBoDto utilisateurBo)
        {
            _logger.LogInformation($"ConnectToBo(utilisateurBo.UserName:{utilisateurBo.UserName})");
            try
            {
                var reponse = await _utilisateurService.ConnectAsync(utilisateurBo.UserName, utilisateurBo.Password);
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
