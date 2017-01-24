using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Authentication;

namespace IDSR.Common.Core.ns11.SqlTools
{
    public interface ISqlDbReader
    {
        Task<bool>  Connect     (DatabaseCredentials dbCredentials, CancellationToken token);
        void        Disconnect  ();

        Task<RecordSetShim>           Query                       (string sqlQuery, CancellationToken cancelToken);
        Task<IDictionary<TKey, TVal>> QueryDictionary<TKey, TVal> (string twoColumnQuery, CancellationToken cancelToken);
    }
}
