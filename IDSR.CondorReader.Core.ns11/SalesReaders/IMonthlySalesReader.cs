using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.SalesReaders
{
    public interface IMonthlySalesReader
    {
        string DatabaseName { get; set; }

        Task<DbDataReader>  ReadFinishedSales (int year, int month, CancellationToken cancelTkn);
        FinishedSale        ToFinishedSale    (IDataRecord dataRecord);
    }
}
