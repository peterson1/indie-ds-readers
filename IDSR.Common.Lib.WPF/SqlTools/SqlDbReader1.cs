using System;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Authentication;
using IDSR.Common.Core.ns11.SqlTools;
using Repo2.Core.ns11.Exceptions;

namespace IDSR.Common.Lib.WPF.SqlTools
{
    public class SqlDbReader1 : SqlDbReaderBase
    {
        private DbConnection _conn;
        private Func<DbCommand> _createCmd;

        public override Task<bool> Connect(DatabaseCredentials dbCredentials, CancellationToken cancelTkn)
        {
            switch (dbCredentials.DbType)
            {
                case DbTypes.SQLite3:
                    return ConnectToSQLite3(dbCredentials, cancelTkn);
                default:
                    throw Fault.Unsupported(dbCredentials.DbType);
            }
        }


        private async Task<bool> ConnectToSQLite3(DatabaseCredentials dbCredentials, CancellationToken cancelTkn)
        {
            var conStr = ConnectionString.SQLite3(dbCredentials);
            _conn = null;
            _conn = new SQLiteConnection(conStr);

            _createCmd = () => new SQLiteCommand();

            await _conn.OpenAsync(cancelTkn);
            return true;
        }


        public override void Disconnect() => _conn?.Close();


        protected override async Task<RecordSetShim> GetQueryResult(string sqlQuery, CancellationToken cancelTkn)
        {
            var rs = new RecordSetShim();
            using (var cmd = CreateCommand(sqlQuery))
            {
                var readr = await cmd.ExecuteReaderAsync(cancelTkn);
                while (await readr.ReadAsync(cancelTkn))
                {
                    var row = new ResultRow();
                    for (int i = 0; i < readr.FieldCount; i++)
                    {
                        row.Add(readr.GetName(i), readr[i]);
                    }
                    rs.Add(row);
                }
            }
            return rs;
        }


        private DbCommand CreateCommand(string sqlQuery)
        {
            var cmd         = _createCmd.Invoke();
            cmd.CommandText = sqlQuery;
            cmd.Connection  = _conn;
            return cmd;
        }
    }
}
