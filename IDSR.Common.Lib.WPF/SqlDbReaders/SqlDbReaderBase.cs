using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Core.ns11.SqlTools;
using IDSR.Common.Lib.WPF.DiskAccess;
using Repo2.Core.ns11.Exceptions;
using Repo2.Core.ns11.Extensions.StringExtensions;

namespace IDSR.Common.Lib.WPF.SqlDbReaders
{
    public abstract class SqlDbReaderBase
    {
        private LocalDbFinder     _findr;
        private DsrConfiguration1 _cfg;

        public SqlDbReaderBase(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1)
        {
            _findr = localDbFinder;
            _cfg   = dsrConfiguration1;
        }


        public string  DatabaseName  { get; set; }
        public bool    UseServer     { get; set; }


        private DbConnection CreateConnection()
            => UseServer ? GetSqlServerConnection() 
                         : GetSqliteConnection();


        private DbConnection GetSqlServerConnection()
            => new SqlConnection(_cfg.ServerConnection);


        private DbConnection GetSqliteConnection()
        {
            if (DatabaseName.IsBlank())
                throw Fault.BlankText("Database name");

            var path = _findr.FindDatabaseFile(DatabaseName);
            var conStr = ConnectionString.SQLite3(path);
            return new SQLiteConnection(conStr);
        }

        protected async Task<DbDataReader> ConnectAndReadAsync(string sqlQuery, CancellationToken cancelTkn)
        {
            var conn        = CreateConnection();
            var cmd         = conn.CreateCommand();
            cmd.CommandText = sqlQuery;

            await conn.OpenAsync(cancelTkn);
            return await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection, cancelTkn);
        }


        private static string Param(DateTime date) => date.ToString("yyyy-MM-dd");


        protected static string AddParamsToMonthlySQL(string sqlQuery, int year, int month)
        {
            var start = new DateTime(year, month, 1);
            var end = start.AddMonths(1);
            return string.Format(sqlQuery, Param(start), Param(end));
        }


        protected static string AddParamsToDateRangeSQL(string sqlQuery, DateTime startDate, DateTime endDate)
            => string.Format(sqlQuery, Param(startDate.Date), Param(endDate.Date.AddDays(1)));


        protected static string AddParamsToSubQuerySQL(string sqlQuery, IEnumerable<string> itemsList)
        {
            var joind = string.Join(",", itemsList.Select(x => $"'{x}'"));
            return string.Format(sqlQuery, joind);
        }
    }
}
