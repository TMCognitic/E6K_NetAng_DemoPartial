using System.Data;
using System.Reflection;

namespace Tools.Connections
{
    public static class DbConnectionExtensions
    {
        public static object? ExecuteScalar(this IDbConnection dbConnection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            using (IDbCommand command = CreateCommand(dbConnection, query, isStoredProcedure, parameters))
            {
                dbConnection.Open();
                object? result = command.ExecuteScalar();
                dbConnection.Close();
                return result is DBNull ? null : result;
            }
        }

        public static int ExecuteNonQuery(this IDbConnection dbConnection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            using (IDbCommand command = CreateCommand(dbConnection, query, isStoredProcedure, parameters))
            {
                dbConnection.Open();
                int rows = command.ExecuteNonQuery();
                dbConnection.Close();
                return rows;
            }
        }

        public static IEnumerable<TResult> ExecuteReader<TResult>(this IDbConnection dbConnection, string query, Func<IDataRecord, TResult> selector, bool isStoredProcedure = false, object? parameters = null)
        {
            ArgumentNullException.ThrowIfNull(selector, nameof(selector));

            using (IDbCommand command = CreateCommand(dbConnection, query, isStoredProcedure, parameters))
            {
                dbConnection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return selector(reader);
                    }
                }
                dbConnection.Close();
            }
        }

        private static IDbCommand CreateCommand(IDbConnection dbConnection, string query, bool isStoredProcedure, object? parameters)
        {
            IDbCommand command = dbConnection.CreateCommand();

            command.CommandText = query;

            if (isStoredProcedure)
            {
                command.CommandType = CommandType.StoredProcedure;
            }

            if (parameters is not null)
            {
                Type type = parameters.GetType();

                foreach (PropertyInfo property in type.GetProperties().Where(p => p.CanRead))
                {
                    IDbDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = property.Name;
                    parameter.Value = property.GetMethod?.Invoke(parameters, null) ?? DBNull.Value;

                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }
    }
}
