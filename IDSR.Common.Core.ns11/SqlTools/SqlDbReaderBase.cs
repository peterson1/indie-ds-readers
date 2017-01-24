using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Authentication;

namespace IDSR.Common.Core.ns11.SqlTools
{
    public abstract class SqlDbReaderBase : ISqlDbReader
    {
        public abstract Task<bool>  Connect     (DatabaseCredentials dbCredentials, CancellationToken token);
        public abstract void        Disconnect  ();


        protected abstract Task<RecordSetShim> GetQueryResult(string sqlQuery, CancellationToken cancelToken);


        public async Task<RecordSetShim> Query(string sqlQuery, CancellationToken cancelToken)
        {
            RecordSetShim rs = null;
            await Task.Run(async () =>
            {
                rs = await GetQueryResult(sqlQuery, cancelToken);
            }
            ).ConfigureAwait(false);
            return rs;
        }


        public async Task<IDictionary<TKey, TVal>> QueryDictionary<TKey, TVal>(string twoColumnQuery, CancellationToken cancelToken)
        {
            var ret = new SortedDictionary<TKey, TVal>();
            var rs  = await Query(twoColumnQuery, cancelToken);

            foreach (var row in rs)
            {
                var key = (TKey)row.ElementAt(0).Value;
                var val = (TVal)row.ElementAt(1).Value;
                ret.Add(key, val);
            }
            return ret;
        }

    }
}
