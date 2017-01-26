using IDSR.Common.Core.ns11.Authentication;

namespace IDSR.Common.Core.ns11.SqlTools
{
    public class ConnectionString
    {
        public static string SQLite3(DatabaseCredentials creds) 
            => SQLite3(creds.ServerURL);

        public static string SQLite3(string dbFilePath)
            => $"Data Source={dbFilePath};Version=3;";
    }
}
