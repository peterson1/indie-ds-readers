using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.SqlTools;
using IDSR.Common.Lib.WPF.DiskAccess;

namespace IDSR.Common.Lib.WPF.LocalDbReaders
{
    public class LocalDbReaderBase
    {
        private LocalDbFinder    _findr;
        private SQLiteConnection _conn;

        public LocalDbReaderBase(LocalDbFinder localDbFinder)
        {
            _findr = localDbFinder;
        }


        public async Task<bool> Connect(string dbFileName, CancellationToken cancelTkn)
        {
            Disconnect();

            var path   = _findr.FindDatabaseFile(dbFileName);
            var conStr = ConnectionString.SQLite3(path);
            _conn      = new SQLiteConnection(conStr);

            await _conn.OpenAsync(cancelTkn);
            return true;
        }


        public IEnumerable<IDataRecord> RunQuery(string sqlStatement, CancellationToken cancelTkn)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = sqlStatement;
                using (var readr = cmd.ExecuteReader())
                {
                    foreach (IDataRecord record in readr)
                    {
                        yield return record;
                    }
                }
            }
        }


        protected string Param(DateTime date) => date.ToString("yyyy-MM-dd");


        public void Disconnect()
        {
            if (_conn == null) return;

            if (_conn.State != ConnectionState.Closed)
                _conn.Close();

            _conn.Dispose();
            _conn = null;
        }
    }
}
