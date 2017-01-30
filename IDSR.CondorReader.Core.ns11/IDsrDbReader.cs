using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IDSR.CondorReader.Core.ns11
{
    public interface IDsrDbReader<T>
    {
        string DatabaseName { get; set; }
        Task<List<T>> GetMonthly(int year, int month, CancellationToken cancelTkn);
    }
}
