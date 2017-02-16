using System;

namespace IDSR.Common.Core.ns11.Configuration
{
    public class DsrConfiguration1
    {
        public DateTime?  GrandOpeningDate  { get; set; }
        public string     ServerConnection  { get; set; }
        public string     SQLiteDbName      { get; set; }

        public static DsrConfiguration1 CreateDefault()
            => new DsrConfiguration1
            {
                GrandOpeningDate = DateTime.Now,
                ServerConnection = "Data Source={serverName};Initial Catalog={databaseName};User id={userName};Password={password};"
            };
    }
}
