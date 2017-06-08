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
using Repo2.Core.ns11.Extensions;
using static IDSR.CondorReader.Core.ns11.SqlQueries.PurchaseOrdersSQL;
using Repo2.Core.ns11.Exceptions;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class PurchaseOrdersReader2 : CondorReaderBase1, IPurchaseOrdersReader
    {
        public PurchaseOrdersReader2(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
        }

        public Task<List<CdrPurchaseOrderLine>> GetByIDs(IEnumerable<int> idsList, CancellationToken cancelTkn)
            => RunJobs(QueryFilteredParents (idsList, cancelTkn),
                       QueryFilteredLines   (idsList, cancelTkn),
                       QueryUsers           (         cancelTkn),
                       QueryLandedCost      (         cancelTkn));


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
                //var p = parnt[line.PurchaseOrderID];
                if (!parnt.TryGetValue(line.PurchaseOrderID, out CdrPurchaseOrder p))
                    throw Fault.NoMatch<CdrPurchaseOrder>(nameof(line.PurchaseOrderID), line.PurchaseOrderID);

                //p.PostedByName = users[int.Parse(p.PostedBy)];
                if (!users.TryGetValue(int.Parse(p.PostedBy), out string usrNme))
                    throw Fault.NoMatch<string>("username", p.PostedBy);
                p.PostedByName = usrNme;

                if (line.ProductID.HasValue && line.ProductID != 0)
                {
                    //line.LandedCost = landeds[line.ProductID.Value];
                    if (!landeds.TryGetValue(line.ProductID.Value, out decimal landedCost))
                        throw Fault.NoMatch<decimal>(nameof(CdrPurchaseOrderLine.ProductID), line.ProductID.Value);
                    line.LandedCost = landedCost;
                }

                line.Parent = p;
            }

            foreach (var grp in lines.GroupBy(x => x.PurchaseOrderID))
            {
                var p = parnt[grp.Key];
                p.Lines = grp.ToList();
            }

            return lines;
        }


        private async Task<Dictionary<decimal, CdrPurchaseOrder>> QueryFilteredParents(IEnumerable<int> idsList, CancellationToken cancelTokn)
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



        private async Task<List<CdrPurchaseOrderLine>> QueryFilteredLines(IEnumerable<int> idsList, CancellationToken cancelTkn)
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



        public async Task<List<CdrPurchaseOrder>> GetAllParents(CancellationToken cancelTkn, bool withLines)
        {
            List<CdrPurchaseOrderLine> lines = null;
            if (withLines) lines = await GetAllLines(cancelTkn);

            var list = new List<CdrPurchaseOrder>();
            var usrs = await QueryUsers(cancelTkn);

            using (var results = await ConnectAndReadAsync(ParentQuery, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                {
                    var po = new CdrPurchaseOrder(rec);

                    int usrID;
                    if (int.TryParse(po.PostedBy, out usrID))
                        po.PostedByName = usrs.GetOrDefault(usrID, "‹deleted-user›");

                    if (withLines)
                        po.Lines = lines.Where(x => x.PurchaseOrderID == po.PurchaseOrderID).ToList();

                    list.Add(po);
                }
            }
            return list;
        }


        public async Task<List<CdrPurchaseOrderLine>> GetAllLines(CancellationToken cancelTkn)
        {
            var parentsJob  = GetAllParents(cancelTkn, false);
            var linesJob    = QueryAllLines(cancelTkn);
            var productsJob = GetProductsDict(cancelTkn);

            await Task.WhenAll(parentsJob, linesJob, productsJob);

            var lines    = await linesJob;
            var parents  = await parentsJob;
            var products = await productsJob;

            foreach (var line in lines)
            {
                line.Parent  = parents.SingleOrDefault(x => x.PurchaseOrderID == line.PurchaseOrderID);
                line.Product = products.GetOrDefault(line.ProductID ?? 0);
            }
            return lines;
        }


        private async Task<List<CdrPurchaseOrderLine>> QueryAllLines(CancellationToken cancelTkn)
        {
            var list = new List<CdrPurchaseOrderLine>();

            using (var results = await ConnectAndReadAsync(LinesQuery, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                    list.Add(new CdrPurchaseOrderLine(rec));
            }
            return list;
        }


        //private async Task<Dictionary<int, CdrProduct>> GetProductsDict(CancellationToken cancelTkn)
        //{
        //    var dict   = new Dictionary<int, CdrProduct>();
        //    var sqlQry = "SELECT * FROM Products";

        //    using (var results = await ConnectAndReadAsync(sqlQry, cancelTkn))
        //    {
        //        foreach (IDataRecord rec in results)
        //        {
        //            var prod = new CdrProduct(rec);
        //            dict.Add(prod.ProductID, prod);
        //        }
        //    }
        //    return dict;
        //}
    }
}
