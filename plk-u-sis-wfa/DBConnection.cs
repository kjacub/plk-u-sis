
using MySql.Data.MySqlClient;

namespace plk_u_sis_wfa
{
    public class DBConnection
    {
        private static readonly string connectionString =
            BuildConnectionString();

        private static string BuildConnectionString()
        {
            string password =
                Environment.GetEnvironmentVariable("PLK_DB_PASSWORD")
                ?? throw new InvalidOperationException(
                    "PLK_DB_PASSWORD environment variable is missing.");

            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Port = 3306,
                Database = "plk_u_sis_db",
                UserID = "root",
                Password = password
            };

            return builder.ConnectionString;
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}