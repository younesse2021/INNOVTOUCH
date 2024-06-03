using BLL.InnovTouch.Contrat.Oracle;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InnovTouch.Implementation.Oracle
{
    public class DemarqueService:BaseService,IDemarqueService
    {
        private readonly ILogger<DemarqueService> _logger;

        private readonly string serveur;
        private readonly string username;
        private readonly string password;

        public DemarqueService(ILogger<DemarqueService> logger, IConfiguration configuration)
        {
            _logger = logger;
            serveur = configuration.GetSection("DEMARQUE:Server_Demarque").Value;
            username = configuration.GetSection("DEMARQUE:Username_Demarque").Value;
            password = configuration.GetSection("DEMARQUE:Password_Demarque").Value;
            _logger.LogInformation("Service(...)");
        }
    }
}
