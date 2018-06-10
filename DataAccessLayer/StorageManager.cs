using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Database operations provider
    /// </summary>
    public static class StorageManager
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["ProductsDB"].ConnectionString;

        /// <summary>
        /// Get data from DB
        /// </summary>
        /// <param name="procName">SP name</param>
        /// <param name="paramValues">SP parameter values</param>
        /// <returns></returns>
        public static List<Dictionary<string, object>> CallProcedure(string procName, Dictionary<string, object> paramValues = null)
        {
            // The stored procedure result
            var result = new List<Dictionary<string, object>>();

            // The sql command
            var command = new SqlCommand(procName)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            // Add the parameters to the stored procedure
            if (paramValues != null)
            {
                foreach (var param in paramValues.Keys)
                {
                    command.Parameters.AddWithValue(param, paramValues[param]);
                }
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                // Open the connection
                command.Connection = connection;
                connection.Open();

                // Execute the command
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Get the command result
                        var item = new Dictionary<string, object>();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            item[reader.GetName(i)] = reader[i];
                        }

                        // Add the command result to the stored procedure result
                        result.Add(item);
                    }
                }
            }

            return result;
        }
    }
}
