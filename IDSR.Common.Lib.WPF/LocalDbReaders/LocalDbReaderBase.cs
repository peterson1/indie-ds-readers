using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.SqlTools;
using IDSR.Common.Lib.WPF.DiskAccess;
using Repo2.Core.ns11.Exceptions;
using Repo2.Core.ns11.Extensions.StringExtensions;

namespace IDSR.Common.Lib.WPF.LocalDbReaders
{
    public abstract class LocalDbReaderBase
    {
        private LocalDbFinder _findr;

        public LocalDbReaderBase(LocalDbFinder localDbFinder)
        {
            _findr = localDbFinder;
        }


        public string DatabaseName { get; set; }


        private DbConnection CreateConnection()
        {
            if (DatabaseName.IsBlank())
                throw Fault.BlankText("Database name");

            var path   = _findr.FindDatabaseFile(DatabaseName);
            var conStr = ConnectionString.SQLite3(path);
            return  new SQLiteConnection(conStr);
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
    }
}
