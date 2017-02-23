using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Core.ns11.SqlTools;
using IDSR.Common.Lib.WPF.DiskAccess;
using Repo2.Core.ns11.Exceptions;
using Repo2.Core.ns11.Extensions.StringExtensions;
using Repo2.SDK.WPF45.Exceptions;

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
        {
            if (_cfg.SQLiteDbName.IsBlank())
                UseServer    = true;
            else
            {
                UseServer    = false;
                DatabaseName = _cfg.SQLiteDbName;
            }

            return UseServer ? GetSqlServerConnection() 
                             : GetSqliteConnection();
        }


        private DbConnection GetSqlServerConnection()
        {
            var conStr = _cfg.ServerConnection;

            if (conStr.IsBlank())
                throw Fault.BlankText("SQL Server connection string");

            return new SqlConnection(conStr);
        }


        private DbConnection GetSqliteConnection()
        {
            if (DatabaseName.IsBlank())
                throw Fault.BlankText("Database name");

            var path = _findr.FindDatabaseFile(DatabaseName);
            var conStr = ConnectionString.SQLite3(path);
            return new SQLiteConnection(conStr);
        }

        //protected async Task<DbDataReader> ConnectAndReadAsync(string sqlQuery, CancellationToken cancelTkn)
        //{
        //    var conn        = CreateConnection();
        //    var cmd         = conn.CreateCommand();
        //    cmd.CommandText = sqlQuery;

        //    AttemptConnect:
        //    try
        //    {
        //        await conn.OpenAsync(cancelTkn);
        //    }
        //    catch (Exception ex)
        //    {
        //        var cap  = $"Can't connect to server.  ‹{ex.GetType().Name}›";
        //        //var msg  = $"{ex.Message}{L.f}{conn.ConnectionString}";
        //        var msg  = $"{ex.Message}";
        //            msg += $"{L.F}Should we try to connect again?";
        //        var resp = MessageBox.Show(msg, cap, MessageBoxButton.YesNo, MessageBoxImage.Question);
        //        if (resp == MessageBoxResult.Yes)
        //            goto AttemptConnect;
        //        else
        //            return null;
        //    }
        //    return await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection, cancelTkn);
        //}

        protected async Task<DbDataReader> ConnectAndReadAsync(string sqlQuery, CancellationToken cancelTkn)
        {
            var conn        = CreateConnection();
            var cmd         = conn.CreateCommand();
            cmd.CommandText = sqlQuery;

            var job = conn.OpenAsync(cancelTkn);
            try
            {
                Task.WaitAll(job);
            }
            catch (Exception ex)
            {
                ShowSqlServerError(ex);
                return null;
            }
            if (job.IsFaulted)
            {
                ShowSqlServerError(job.Exception);
                return null;
            }
            return await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection, cancelTkn);
        }


        private void ShowSqlServerError(Exception ex)
            => Alerter.ShowError("Can't connect to database", ex.Info());


        private static string Param(DateTime date) => date.ToString("yyyy-MM-dd");


        protected static string AddParamsToMonthlySQL(string sqlQuery, int year, int month)
        {
            var start = new DateTime(year, month, 1);
            var end = start.AddMonths(1);
            return string.Format(sqlQuery, Param(start), Param(end));
        }


        protected static string AddParamsToDateRangeSQL(string sqlQuery, DateTime startDate, DateTime endDate)
            => string.Format(sqlQuery, Param(startDate.Date), Param(endDate.Date.AddDays(1)));
    }
}
