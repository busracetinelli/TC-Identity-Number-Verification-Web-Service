using System;
using System.Data;
using System.Data.SqlClient;

namespace UnipaMiniTask.DAL.Connectors
{
    public class MsSqlConnector
    {
        public MsSqlConnector(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }

        public SqlConnection GetConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
                connection.Open();

            return connection;
        }

        public SqlCommand GetCommand(SqlConnection sqlConnection)
        {
            var result = sqlConnection.CreateCommand();
            //result.CommandTimeout = 180; // 3dk
            result.CommandTimeout = 300; // 6 dk
            return result;
        }

        public void ExecuteReader(string commandText, CommandType commandType, CommandBehavior commandBehavior, SqlParameter[] sqlParameters, Action<SqlDataReader> function = null)
        {
            using (var connection = GetConnection())
            {
                using (var command = GetCommand(connection))
                {
                    command.CommandText = commandText;
                    command.CommandType = commandType;

                    if (sqlParameters != null)
                        foreach (var sqlParameter in sqlParameters)
                            command.Parameters.Add(sqlParameter);

                    using (var reader = command.ExecuteReader(commandBehavior))
                        try
                        {
                            function?.Invoke(reader);
                        }
                        finally
                        {
                            reader.Close();
                        }
                }
            }

        }

        public object ExecuteScalar(string commandText, CommandType commandType, SqlParameter[] sqlParameters)
        {
            using (var connection = GetConnection())
            {
                using (var command = GetCommand(connection))
                {
                    command.CommandText = commandText;
                    command.CommandType = commandType;
                    if (sqlParameters == null)
                        return command.ExecuteScalar();

                    foreach (var sqlParameter in sqlParameters)
                        command.Parameters.Add(sqlParameter);

                    return command.ExecuteScalar();
                }
            }

        }

        public int ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] sqlParameters)
        {
            using (var connection = GetConnection())
            {
                using (var command = GetCommand(connection))
                {
                    command.CommandText = commandText;
                    command.CommandType = commandType;

                    if (sqlParameters == null)
                        return command.ExecuteNonQuery();

                    foreach (var sqlParameter in sqlParameters)
                        command.Parameters.Add(sqlParameter);

                    return command.ExecuteNonQuery();
                }
            }
        }

        public int ExecuteNonQueryTimeoutless(string commandText, CommandType commandType, SqlParameter[] sqlParameters)
        {
            using (var connection = GetConnection())
            {
                using (var command = GetCommand(connection))
                {
                    command.CommandTimeout = 0;
                    command.CommandText = commandText;
                    command.CommandType = commandType;
                    if (sqlParameters == null)
                        return command.ExecuteNonQuery();

                    foreach (var sqlParameter in sqlParameters)
                        command.Parameters.Add(sqlParameter);

                    return command.ExecuteNonQuery();
                }
            }
        }

        public DataTable ExecuteDataTable(string commandText, CommandType commandType, SqlParameter[] sqlParameter)
        {
            using (var connection = GetConnection())
            {
                using (var dap = new SqlDataAdapter(commandText, connection) { SelectCommand = { CommandType = commandType } })
                {
                    if (sqlParameter != null && sqlParameter.Length > 0)
                        foreach (var parameter in sqlParameter)
                            dap.SelectCommand.Parameters.Add(parameter);

                    var result = new DataTable();
                    dap.Fill(result);
                    return result;
                }
            }
        }

        public DataTable ExecuteDataTableWithIdentity(string commandText, CommandType commandType, SqlParameter[] sqlParameter, string identityColName, int identitySeed, int identityStep)
        {
            using (var connection = GetConnection())
            {
                using (var dap = new SqlDataAdapter(commandText, connection) { SelectCommand = { CommandType = commandType } })
                {
                    if (sqlParameter != null && sqlParameter.Length > 0)
                        foreach (var parameter in sqlParameter)
                            dap.SelectCommand.Parameters.Add(parameter);

                    var result = new DataTable();

                    var dc = new DataColumn(identityColName)
                    {
                        AutoIncrement = true,
                        AutoIncrementSeed = identitySeed,
                        AutoIncrementStep = identityStep,
                        DataType = typeof(int)
                    };

                    result.Columns.Add(dc);

                    dap.Fill(result);
                    return result;
                }
            }
        }

        public DataSet ExecuteDataSet(string commandText, CommandType commandType, SqlParameter[] sqlParameter)
        {
            using (var connection = GetConnection())
            {
                using (var dap = new SqlDataAdapter(commandText, connection) { SelectCommand = { CommandType = commandType } })
                {
                    if (sqlParameter != null && sqlParameter.Length > 0)
                        foreach (SqlParameter parameter in sqlParameter)
                            dap.SelectCommand.Parameters.Add(parameter);

                    var result = new DataSet();
                    dap.Fill(result);
                    return result;
                }
            }
        }
    }
}
