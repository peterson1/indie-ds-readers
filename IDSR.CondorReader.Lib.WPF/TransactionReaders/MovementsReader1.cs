using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.SqlDbReaders;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.TransactionReaders;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class MovementsReader1 : SqlDbReaderBase, IMovementsReader
    {
        public MovementsReader1(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
        }


        public Task<List<CdrMovementLine>> GetOpenReturns(IEnumerable<string> vendorCodes, CancellationToken cancelTokn)
            => RunJobs(QueryParent("RSsa", vendorCodes, "OPEN", cancelTokn),
                       QueryLines ("RSsa", vendorCodes, "OPEN", cancelTokn));


        public Task<List<CdrMovementLine>> GetPostedReturns(IEnumerable<string> vendorCodes, CancellationToken cancelTokn)
            => RunJobs(QueryParent("RSsa", vendorCodes, "POSTED", cancelTokn),
                       QueryLines ("RSsa", vendorCodes, "POSTED", cancelTokn));


        private static async Task<List<CdrMovementLine>> RunJobs(Task<Dictionary<decimal, CdrMovement>> parntJob, Task<List<CdrMovementLine>> linesJob)
        {
            Dictionary<decimal, CdrMovement> parnt = null;
            List<CdrMovementLine>            lines = null;

            await Task.Run(async () =>
            {
                await Task.WhenAll(parntJob, linesJob);
                parnt = await parntJob;
                lines = await linesJob;
            }
            ).ConfigureAwait(false);

            foreach (var line in lines)
                line.Parent = parnt[line.MovementID];

            return lines;
        }


        private async Task<Dictionary<decimal, CdrMovement>> QueryParent(string mvtCode, IEnumerable<string> vendorCodes, string statusDesc, CancellationToken cancelTokn)
        {
            var qry = MovementsSQL.ParentQuery.WHERE_MvtCodeClause(mvtCode)
                                              .AppendStatusClause(statusDesc)
                                              .AppendVendorClause(vendorCodes);

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
            var qry = MovementsSQL.LinesQuery.WHERE_MvtCodeClause(mvtCode)
                                             .AppendStatusClause(statusDesc)
                                             .AppendVendorClause(vendorCodes);

            var list = new List<CdrMovementLine>();

            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                    list.Add(new CdrMovementLine(rec));
            }
            return list;
        }
    }


    internal static class MovementsSQL
    {

        internal const string ParentQuery =
            @"SELECT * 
                FROM Movements p";

        internal const string LinesQuery =
            @"SELECT ln.* 
                FROM MovementLine ln
           LEFT JOIN Movements p
                  ON p.MovementID = ln.MovementID";


        internal static string WHERE_MvtCodeClause(this string sqlQuery, string mvtCode)
            => $"{sqlQuery} WHERE p.MovementCode = '{mvtCode}'";


        internal static string AppendStatusClause(this string sqlQuery, string statusDesc)
            => $"{sqlQuery} AND p.StatusDescription = '{statusDesc}'";


        internal static string AppendVendorClause(this string sqlQuery, IEnumerable<string> vendorCodes)
        {
            var joind = string.Join(",", vendorCodes.Select(x => $"'{x}'"));
            return $"{sqlQuery} AND p.VendorCode IN ({joind})";
        }
    }
}
