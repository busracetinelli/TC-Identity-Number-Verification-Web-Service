using Dapper;
using UnipaMiniTask.CORE.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnipaMiniTask.DAL.Connectors
{
    public class DapperConnector
    {
        private SqlConnection _connection;
        public DapperConnector(string connectionString)
        {

            if (_connection == null)
            {
                _connection = new SqlConnection(connectionString);
            }
        }
        public SqlConnection GetConnection()
        {

            if (_connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
                _connection.Open();

            return _connection;
        }
        public T InsertFromProcedure<T>(string ProcedureName, T Model) where T : BaseCore
        {
            return GetConnection().Query<T>(ProcedureName, Model, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
      
        public void UpdateFromProcedure<T>(string ProcedureName, T Model, int? wheredoesitcomefrom = null) where T : BaseCore
        {
            GetConnection().Query<T>(ProcedureName, Model, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<T> SelectFromProcedure<T>(string ProcedureName, int? Id = default(int?))
        {
            return GetConnection().Query<T>(ProcedureName, new { Id }, commandType: CommandType.StoredProcedure);
        }

        public bool DeleteFromProcedure(string ProcedureName, int? Id = default(int?))
        {
            return GetConnection().Execute(ProcedureName, new { Id }, commandType: CommandType.StoredProcedure) == 1;
        }

        public IEnumerable<T> SelectByLangFromProcedure<T>(string ProcedureName, string Lang)
        {
            return GetConnection().Query<T>(ProcedureName, new { Lang }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<T> SelectFromFunctionTable<T>(string FunctionTableName) 
        {
            return GetConnection().Query<T>("SELECT * FROM " + FunctionTableName + "();", CommandType.Text);
        }
        public IEnumerable<T> SelectFromText<T>(string sql)
        {
            return GetConnection().Query<T>(sql, CommandType.Text);
        }
    }
}
