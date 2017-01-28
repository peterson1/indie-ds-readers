using System.Data;
using System.Data.Common;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.SalesReaders
{
    public interface IMonthlySalesReader
    {
        string DatabaseName { get; set; }

        DbDataReader ReadFinishedSales  (int year, int month);
        FinishedSale ToFinishedSale     (IDataRecord dataRecord);
    }
}
