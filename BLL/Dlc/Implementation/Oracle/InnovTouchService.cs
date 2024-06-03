using BLL.InnovTouch.Contrat.Oracle;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shared.DTO.InnovTouch.DTO.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.Implementation.Oracle
{
    public class Service : BaseService, IService
    {

        private readonly ILogger<Service> _logger;

        private readonly string serveur;
        private readonly string username;
        private readonly string password;

        public Service(ILogger<Service> logger,IConfiguration configuration)
        {
            _logger= logger;
            serveur = configuration.GetSection("ENV:Server_").Value;
            username = configuration.GetSection("ENV:Username_").Value;
            password = configuration.GetSection("ENV:Password_").Value;
            _logger.LogInformation("Service(...)");
        }
        public Task<Response<string[]>> GetDepartementsByLoginAsync(string login)
        {
            _logger.LogInformation($"GetDepartementsByLoginAsync(login:{login})");
            Response<string[]> response = new Response<string[]>();
            try
            {
                var query = @"
					SELECT 
						distinct CEXT_DEPT Departement 
					FROM SECSTRUCT, mj_art_struct, SECUSERPRO, adm_users 
					WHERE SSMPROFIL = SUPPROFIL 
						and SSMSTRCINT = CINT_RAY 
						and SUPUSER = :login
						and aususer = SUPUSER 
						and AUSAPPLI = 'PDA'
					group by CEXT_DEPT";

                var resultatDt = RunQuery(serveur, username, password, query, new Dictionary<string, object>()
                {
                    {":login",login} 
                });

                if(resultatDt != null && resultatDt.Rows.Count> 0)
                {
                    List<string> result = new List<string>();
                    foreach (DataRow item in resultatDt.Rows)
                    {
                        result.Add(Convert.ToString(item["Departement"]));
                    }
                    response.Succeeded = true;
                    response.Data = result.ToArray();
                }
                _logger.LogInformation($"liste departement pour login:{login}, {response.Data}");
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message= "Une erreur s'est produit lors de l'execution du requête";
                _logger.LogError(ex, $" Exception : {ex.Message}");
            }
            return Task.FromResult(response);
        }
    }
}
