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
using static IDSR.CondorReader.Core.ns11.SqlQueries.MovementsSQL;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class MovementsReader1 : CondorReaderBase1, IMovementsReader
    {
        public MovementsReader1(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
        }


        public Task<List<CdrMovementLine>> GetOpenReturns(IEnumerable<string> vendorCodes, CancellationToken cancelTokn)
            => RunJobs(QueryParent("RSsa", vendorCodes, "OPEN", cancelTokn),
                       QueryLines ("RSsa", vendorCodes, "OPEN", cancelTokn),
                       QueryUsers(cancelTokn));


        public Task<List<CdrMovementLine>> GetPostedReturns(IEnumerable<string> vendorCodes, CancellationToken cancelTokn)
            => RunJobs(QueryParent("RSsa", vendorCodes, "POSTED", cancelTokn),
                       QueryLines ("RSsa", vendorCodes, "POSTED", cancelTokn),
                       QueryUsers(cancelTokn));


        private static async Task<List<CdrMovementLine>> RunJobs(
            Task<Dictionary<decimal, CdrMovement>> parntJob, 
            Task<List<CdrMovementLine>> linesJob,
            Task<Dictionary<int, string>> usersJob)
        {
            Dictionary<decimal, CdrMovement> parnt = null;
            List<CdrMovementLine>            lines = null;
            Dictionary<int, string>          users = null;

            await Task.Run(async () =>
            {
                await Task.WhenAll(parntJob, linesJob);
                parnt = await parntJob;
                lines = await linesJob;
                users = await usersJob;
            }
            ).ConfigureAwait(false);

            foreach (var line in lines)
            {
                var p = parnt[line.MovementID];
                p.PostedByName = users[int.Parse(p.PostedBy)];
                line.Parent = p;
            }

            foreach (var grp in lines.GroupBy(x => x.MovementID))
            {
                var p = parnt[grp.Key];
                p.Lines = grp.ToList();
            }

            return lines;
        }


        private async Task<Dictionary<decimal, CdrMovement>> QueryParent(string mvtCode, IEnumerable<string> vendorCodes, string statusDesc, CancellationToken cancelTokn)
        {
            var qry = ParentQuery.WHERE_MovementCode_IS(mvtCode)
                                 .AND_StatusDescription_IS(statusDesc)
                                 .AND_VendorCode_IN(vendorCodes);

            var dict = new Dictionary<decimal, CdrMovement>();
            using (var results = await ConnectAndReadAsync(qry, cancelTokn))
            {
                foreach (IDataRecord rec in results)
                {
                    var parnt = new CdrMovement(rec);
                    dict.Add(parnt.MovementID, parnt);
                }
            }
            return dict;
        }


        private async Task<List<CdrMovementLine>> QueryLines(string mvtCode, IEnumerable<string> vendorCodes, string statusDesc, CancellationToken cancelTkn)
        {
            var qry = LinesQuery.WHERE_MovementCode_IS(mvtCode)
                                .AND_StatusDescription_IS(statusDesc)
                                .AND_VendorCode_IN(vendorCodes);

            var list = new List<CdrMovementLine>();

            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                    list.Add(new CdrMovementLine(rec));
            }
            return list;
        }


        public async Task<List<CdrMovement>> GetBadOrders(CancellationToken cancelTkn, bool withLines)
        {
            var qry = ParentQuery.WHERE_MovementCode_IS("RSsa")
                                 .AND_StatusDescription_IS("POSTED");

            List<CdrMovementLine> lines = null;
            if (withLines) lines = await GetBadOrderLines(cancelTkn);

            var usrs = await QueryUsers(cancelTkn);
            var list = await QueryList<CdrMovement>(qry, r => new CdrMovement(r), cancelTkn);
            foreach (var mvt in list)
            {
                int usrID;
                if (int.TryParse(mvt.PostedBy, out usrID))
                    mvt.PostedByName = usrs.GetOrDefault(usrID, "‹deleted-user›");

                if (withLines)
                    mvt.Lines = lines.Where(x => x.MovementID == mvt.MovementID).ToList();
            }
            return list;
        }


        public async Task<List<CdrMovementLine>> GetBadOrderLines(CancellationToken cancelTkn)
        {
            var qry = LinesQuery.WHERE_MovementCode_IS("RSsa")
                                .AND_StatusDescription_IS("POSTED");

            var parentsJob  = GetBadOrders    (cancelTkn, false);
            var productsJob = GetProductsDict (cancelTkn);
            var linesJob    = QueryList<CdrMovementLine>(qry, x => new CdrMovementLine(x), cancelTkn);
            await Task.WhenAll(parentsJob, linesJob);

            var parents  = (await parentsJob).ToDictionary(x => x.MovementID);
            var products = await productsJob;
            var lines    = await linesJob;

            foreach (var line in lines)
            {
                line.Parent = parents.GetOrDefault(line.MovementID);

                if (line.ProductID.HasValue)
                    line.Product = products.GetOrDefault((int)line.ProductID.Value);
            }
            return lines;
        }
    }
}
