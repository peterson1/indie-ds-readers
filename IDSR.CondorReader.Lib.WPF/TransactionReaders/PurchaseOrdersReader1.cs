using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.SqlDbReaders;
using IDSR.CondorReader.Core.ns11;
using IDSR.CondorReader.Core.ns11.DomainModels;
using Repo2.Core.ns11.Extensions;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class PurchaseOrdersReader1 : SqlDbReaderBase, IDsrDbReader<PurchaseOrderLine>
    {
        public PurchaseOrdersReader1(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
        }


        public async Task<List<PurchaseOrderLine>> GetMonthly(int year, int month, CancellationToken cancelTkn)
        {
            Dictionary<long, PurchaseOrder> ordrs = null;
            List<PurchaseOrderLine>         lines = null;

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
                line.Order = ordrs[line.OrderId];

            return lines;
        }


        private async Task<Dictionary<long, PurchaseOrder>> QueryOrders(int year, int month, CancellationToken cancelTkn)
        {
            var qry  = AddParamsToMonthlySQL(ORDER_QUERY, year, month);
            var dict = new Dictionary<long, PurchaseOrder>();

            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                {
                    var ordr = new PurchaseOrder(rec);
                    dict.Add(ordr.Id, ordr);
                }
            }
            return dict;
        }


        private async Task<List<PurchaseOrderLine>> QueryLines(int year, int month, CancellationToken cancelTkn)
        {
            var qry  = AddParamsToMonthlySQL(LINE_QUERY, year, month);
            var list = new List<PurchaseOrderLine>();

            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                    list.Add(new PurchaseOrderLine(rec));
            }
            return list;
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
