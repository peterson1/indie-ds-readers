using System.Collections.Generic;
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

        Task<List<FinishedSale>> GetFinishedSales(int year, int month, CancellationToken cancelTkn);
    }
}
