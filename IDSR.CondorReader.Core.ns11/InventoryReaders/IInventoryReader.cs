using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Authentication;

namespace IDSR.CondorReader.Core.ns11.InventoryReaders
{
    public interface IInventoryReader
    {
        Task<IDictionary<long, decimal>> GetCurrentSellingAreaQtys(CancellationToken cancelToken);
        Task<bool> Connect(DatabaseCredentials dbCredentials, CancellationToken cancelToken);
    }
}
