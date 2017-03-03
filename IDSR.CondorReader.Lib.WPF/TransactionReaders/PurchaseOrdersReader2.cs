using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.TransactionReaders;
using IDSR.CondorReader.Lib.WPF.BaseReaders;
using static IDSR.CondorReader.Core.ns11.SqlQueries.PurchaseOrdersSQL;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class PurchaseOrdersReader2 : CondorReaderBase1, IPurchaseOrdersReader
    {
        public PurchaseOrdersReader2(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
        }

        public Task<List<CdrPurchaseOrderLine>> GetByIDs(IEnumerable<int> idsList, CancellationToken cancelTkn)
            => RunJobs(QueryParent(idsList, cancelTkn),
                       QueryLines (idsList, cancelTkn),
                       QueryUsers (         cancelTkn),
                       QueryLandedCost     (cancelTkn));


        private static async Task<List<CdrPurchaseOrderLine>> RunJobs(
            Task<Dictionary<decimal, CdrPurchaseOrder>> parntJob, 
            Task<List<CdrPurchaseOrderLine>> linesJob,
            Task<Dictionary<int, string>> usersJob,
            Task<Dictionary<int, decimal>> landedsJob
            )
        {
            Dictionary<decimal, CdrPurchaseOrder> parnt    = null;
            List<CdrPurchaseOrderLine>            lines    = null;
            Dictionary<int, string>               users    = null;
            Dictionary<int, decimal>              landeds  = null;

            await Task.Run(async () =>
            {
                await Task.WhenAll(parntJob, linesJob, usersJob);
                parnt   = await parntJob;
                lines   = await linesJob;
                users   = await usersJob;
                landeds = await landedsJob;
            }
            ).ConfigureAwait(false);

            foreach (var line in lines)
            {
                var p = parnt[line.PurchaseOrderID];
                p.PostedByName = users[int.Parse(p.PostedBy)];

                if (line.ProductID.HasValue)
                    line.LandedCost = landeds[line.ProductID.Value];

                line.Parent = p;
            }

            foreach (var grp in lines.GroupBy(x => x.PurchaseOrderID))
            {
                var p = parnt[grp.Key];
                p.Lines = grp.ToList();
            }

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
