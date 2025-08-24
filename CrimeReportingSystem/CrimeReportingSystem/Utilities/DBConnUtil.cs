using Microsoft.Data.SqlClient;

namespace CrimeReportingSystem.Utilities
{
    public static class DBConnUtil
    {
        public static SqlConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}