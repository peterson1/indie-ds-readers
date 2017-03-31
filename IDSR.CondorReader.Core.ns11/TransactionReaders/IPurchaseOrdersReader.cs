using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.TransactionReaders
{
    public interface IPurchaseOrdersReader
    {
        Task<List<CdrPurchaseOrderLine>>  GetByIDs       (IEnumerable<int> idsList, CancellationToken cancelTkn);
        Task<List<CdrPurchaseOrder>>      GetAllParents  (CancellationToken cancelTkn, bool withLines);
        Task<List<CdrPurchaseOrderLine>>  GetAllLines    (CancellationToken cancelTkn);
    }
}
