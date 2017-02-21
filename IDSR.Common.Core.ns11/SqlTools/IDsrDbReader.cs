using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IDSR.Common.Core.ns11.SqlTools
{
    public interface IDsrDbReader<T>
    {
        string   DatabaseName  { get; set; }
        bool     UseServer     { get; set; }

        Task<List<T>>  GetMonthly   (int year, int month, CancellationToken cancelTkn);
        Task<List<T>>  GetDateRange (DateTime startDate, DateTime endDate, CancellationToken cancelTkn);

        Task<List<T>>  GetByIDs     (IEnumerable<int> idsList, CancellationToken cancelTkn);
    }
}
