using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.SalesReaders
{
    public interface IMonthlySalesReader
    {
        IEnumerable<FinishedSale>  Query
            (int year, int month, CancellationToken cancelTkn);

        Task<bool>  Connect     (string databasePath, CancellationToken cancelTkn);
        void        Disconnect  ();
    }
}
