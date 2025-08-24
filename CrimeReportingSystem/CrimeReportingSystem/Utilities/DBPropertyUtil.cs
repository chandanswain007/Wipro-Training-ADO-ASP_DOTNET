using System.IO;

namespace CrimeReportingSystem.Utilities
{
    public static class DBPropertyUtil
    {
        public static string GetPropertyString(string propertyFileName)
        {
            var properties = File.ReadAllLines(propertyFileName);
            var connectionString = "";

            foreach (var line in properties)
            {
                if (line.StartsWith("ConnectionString="))
                {
                    connectionString = line.Substring("ConnectionString=".Length);
                    break;
                }
            }

            return connectionString;
        }
    }
}