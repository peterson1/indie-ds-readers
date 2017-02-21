using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Core.ns11.SqlTools;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.SqlDbReaders;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class PurchaseOrdersReader1 : SqlDbReaderBase, IDsrDbReader<CdrPurchaseOrderLine>
    {
        public PurchaseOrdersReader1(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
        }


        public async Task<List<CdrPurchaseOrderLine>> GetMonthly(int year, int month, CancellationToken cancelTkn)
        {
            Dictionary<decimal, CdrPurchaseOrder> ordrs = null;
            List<CdrPurchaseOrderLine>         lines = null;

            var ordrJob = QueryOrders(year, month, cancelTkn);
            var lineJob = QueryLines (year, month, cancelTkn);

            await Task.Run(async () =>
            {
                await Task.WhenAll(ordrJob, lineJob);
                ordrs = await ordrJob;
                lines = await lineJob;
            }
            ).ConfigureAwait(false);

            foreach (var line in lines)
                line.Parent = ordrs[line.PurchaseOrderID];

            return lines;
        }


        private async Task<Dictionary<decimal, CdrPurchaseOrder>> QueryOrders(int year, int month, CancellationToken cancelTkn)
        {
            var qry  = AddParamsToMonthlySQL(ORDER_QUERY, year, month);
            var dict = new Dictionary<decimal, CdrPurchaseOrder>();

            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                {
                    var ordr = new CdrPurchaseOrder(rec);
                    dict.Add(ordr.PurchaseOrderID, ordr);
                }
            }
            return dict;
        }


        private async Task<List<CdrPurchaseOrderLine>> QueryLines(int year, int month, CancellationToken cancelTkn)
        {
            var qry  = AddParamsToMonthlySQL(LINE_QUERY, year, month);
            var list = new List<CdrPurchaseOrderLine>();

            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                    list.Add(new CdrPurchaseOrderLine(rec));
            }
            return list;
        }

        public Task<List<CdrPurchaseOrderLine>> GetDateRange(DateTime startDate, DateTime endDate, CancellationToken cancelTkn)
        {
            throw new NotImplementedException();
        }

        public Task<List<CdrPurchaseOrderLine>> GetByIDs(IEnumerable<int> idsList, CancellationToken cancelTkn)
        {
            throw new NotImplementedException();
        }



        const string ORDER_QUERY = @"SELECT * FROM [PurchaseOrder]
                                      WHERE PostedDate >= '{0}' AND PostedDate < '{1}'";


        const string LINE_QUERY = @"SELECT ln.* 
                                      FROM PurchaseOrderLine ln
                                 LEFT JOIN PurchaseOrder po
                                        ON po.PurchaseOrderID = ln.PurchaseOrderID
                                     WHERE po.PostedDate >= '{0}' AND po.PostedDate < '{1}';";
    }
}
