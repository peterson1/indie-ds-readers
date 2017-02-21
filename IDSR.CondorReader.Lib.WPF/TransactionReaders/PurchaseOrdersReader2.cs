using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.SqlDbReaders;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.TransactionReaders;
using static IDSR.CondorReader.Core.ns11.SqlQueries.PurchaseOrdersSQL;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class PurchaseOrdersReader2 : SqlDbReaderBase, IPurchaseOrdersReader
    {
        public PurchaseOrdersReader2(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
        }

        public Task<List<CdrPurchaseOrderLine>> GetByIDs(IEnumerable<int> idsList, CancellationToken cancelTkn)
            => RunJobs(QueryParent(idsList, cancelTkn),
                       QueryLines (idsList, cancelTkn));


        private static async Task<List<CdrPurchaseOrderLine>> RunJobs(Task<Dictionary<decimal, CdrPurchaseOrder>> parntJob, Task<List<CdrPurchaseOrderLine>> linesJob)
        {
            Dictionary<decimal, CdrPurchaseOrder> parnt = null;
            List<CdrPurchaseOrderLine> lines = null;

            await Task.Run(async () =>
            {
                await Task.WhenAll(parntJob, linesJob);
                parnt = await parntJob;
                lines = await linesJob;
            }
            ).ConfigureAwait(false);

            foreach (var line in lines)
                line.Parent = parnt[line.PurchaseOrderID];

            return lines;
        }


        private async Task<Dictionary<decimal, CdrPurchaseOrder>> QueryParent(IEnumerable<int> idsList, CancellationToken cancelTokn)
        {
            var qry = ParentQuery.WHERE_PurchaseOrderID_IN(idsList);

            var dict = new Dictionary<decimal, CdrPurchaseOrder>();
            using (var results = await ConnectAndReadAsync(qry, cancelTokn))
            {
                foreach (IDataRecord rec in results)
                {
                    var parnt = new CdrPurchaseOrder(rec);
                    dict.Add(parnt.PurchaseOrderID, parnt);
                }
            }
            return dict;
        }


        private async Task<List<CdrPurchaseOrderLine>> QueryLines(IEnumerable<int> idsList, CancellationToken cancelTkn)
        {
            var qry = LinesQuery.WHERE_PurchaseOrderID_IN(idsList);

            var list = new List<CdrPurchaseOrderLine>();

            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                    list.Add(new CdrPurchaseOrderLine(rec));
            }
            return list;
        }
    }
}
