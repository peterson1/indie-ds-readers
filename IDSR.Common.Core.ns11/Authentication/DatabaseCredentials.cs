namespace IDSR.Common.Core.ns11.Authentication
{
    public class DatabaseCredentials
    {
        public DbTypes   DbType         { get; set; }
        public string    ServerURL      { get; set; }
        public string    DatabaseName   { get; set; }
        public string    UserName       { get; set; }
        public string    Password       { get; set; }
    }
}
