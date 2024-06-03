using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class BaseService
    {
        #region Oracle
        public DataTable RunQuery(string db_serveur, string db_username, string db_password, string req)
        {
            var StrConn = $"User Id={db_username};Password={db_password};Data Source={db_serveur};Pooling=false";

            using (OracleConnection connection = new OracleConnection(StrConn))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand(req, connection))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        DataSet ds = new DataSet();

                        adapter.Fill(ds);
                        if (ds.Tables.Count > 0)
                            return ds.Tables[0].Copy();
                        else
                            return null;
                    }
                }
            }
        }
        public DataTable RunQuery(string db_serveur, string db_username, string db_password, string req, Dictionary<string, object> parametres)
        {
            var StrConn = $"User Id={db_username};Password={db_password};Data Source={db_serveur};Pooling=false";

            using (OracleConnection connection = new OracleConnection(StrConn))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand(req, connection))
                {
                    command.BindByName = true;
                    foreach (var parametre in parametres)
                    {
                        command.Parameters.Add(parametre.Key, parametre.Value);
                    }
                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        DataSet ds = new DataSet();

                        adapter.Fill(ds);
                        if (ds.Tables.Count > 0)
                            return ds.Tables[0].Copy();
                        else
                            return null;
                    }
                }
            }
        }
        public bool RunUpdateQuery(string db_serveur, string db_username, string db_password, string req, Dictionary<string, object> parametres)
        {
            var StrConn = $"User Id={db_username};Password={db_password};Data Source={db_serveur};Pooling=false";
            bool result = false;

            using (OracleConnection connection = new OracleConnection(StrConn))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand(req, connection))
                {
                    command.BindByName = true;
                    foreach (var parametre in parametres)
                    {
                        command.Parameters.Add(parametre.Key, parametre.Value);
                    }
                    int cnt = command.ExecuteNonQuery();
                    if (cnt > 0)
                    {
                        result = true;
                    }
                }
                connection.Close();
            }
            return result;
        }
        #endregion
    }
}
