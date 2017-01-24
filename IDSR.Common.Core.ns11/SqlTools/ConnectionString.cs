using IDSR.Common.Core.ns11.Authentication;

namespace IDSR.Common.Core.ns11.SqlTools
{
    public class ConnectionString
    {
        public static string SQLite3(DatabaseCredentials creds)
            => $"Data Source={creds.ServerURL};Version=3;";
    }
}
