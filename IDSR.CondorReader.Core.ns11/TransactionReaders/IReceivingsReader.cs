using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.TransactionReaders
{
    public interface IReceivingsReader
    {
        Task<List<CdrReceiving>>      GetAllParents  (CancellationToken cancelTkn, bool withLines);
        Task<List<CdrReceivingLine>>  GetAllLines    (CancellationToken cancelTkn);
    }
}
