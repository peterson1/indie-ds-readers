using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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


        const string OPEN_RETURNS_PARENT_QUERY =
            @"SELECT * 
                FROM Movements
               WHERE MovementCode = 'RSsa'
                 AND StatusDescription = 'OPEN'
                 AND VendorCode IN ({0})";

        const string OPEN_RETURNS_LINES_QUERY =
            @"SELECT ln.* 
                FROM MovementLine ln
           LEFT JOIN Movements p
                  ON p.MovementID = ln.MovementID
               WHERE p.MovementCode = 'RSsa'
                 AND p.StatusDescription = 'OPEN'
                 AND p.VendorCode IN ({0})";



        public Task<List<CdrMovementLine>> GetOpenReturns(IEnumerable<string> vendorCodes, CancellationToken cancelTokn)
            => RunJobs(QueryParent(AddParamsToSubQuerySQL(OPEN_RETURNS_PARENT_QUERY, vendorCodes), cancelTokn),
                       QueryLines (AddParamsToSubQuerySQL(OPEN_RETURNS_LINES_QUERY , vendorCodes), cancelTokn));


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


        private async Task<Dictionary<decimal, CdrMovement>> QueryParent(string qry, CancellationToken cancelTokn)
        {
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


        private async Task<List<CdrMovementLine>> QueryLines(string qry, CancellationToken cancelTkn)
        {
            var list = new List<CdrMovementLine>();

            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                    list.Add(new CdrMovementLine(rec));
            }
            return list;
        }
    }
}
