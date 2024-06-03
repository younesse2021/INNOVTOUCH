using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DAL.DOMAIN.Repositories;
using DAL.InnovTouch.DOMAIN.IRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DAL.Repositories
{
    public class UnitOfWorkOracle : IUnitOfWorkOracle
    {
        private readonly ILogger<UnitOfWorkOracle> _logger;
        private readonly OracleConnection _cnx;

        public UnitOfWorkOracle(ILogger<UnitOfWorkOracle> logger, IConfiguration configuration)
        {
            _logger = logger;
            var db_username = configuration["ENV:Username_"];
            var db_password = configuration["ENV:Password_"];
            var db_serveur = configuration["ENV:Server_"];
            _cnx = new OracleConnection($"User Id={db_username};Password={db_password};Data Source={db_serveur};Pooling=false");
            _logger.LogInformation("UnitOfwork(...)");
        }
        public async Task<DataTable?> GetDataAsync(string req, Dictionary<string, Object> parameters)
        {
            _logger.LogInformation($"GetData(req,parameters.count:{parameters.Count})");
            DataTable dt = new DataTable();
            try
            {
                OracleCommand cmd = new OracleCommand(req, _cnx);
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param.Key, param.Value);
                }
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                await Task.FromResult(da.Fill(dt));
                if (dt.Rows.Count == 0)
                {
                    dt = null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception : {ex.Message}");
            }
            return dt;
        }
    }
}
