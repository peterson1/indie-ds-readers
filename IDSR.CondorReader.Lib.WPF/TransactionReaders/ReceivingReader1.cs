using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.LocalDbReaders;
using IDSR.CondorReader.Core.ns11;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class ReceivingReader1 : LocalDbReaderBase, IDsrDbReader<ReceivingLine>
    {
        public ReceivingReader1(LocalDbFinder localDbFinder) : base(localDbFinder)
        {
        }


        const string PARENT_QUERY = 
            @"SELECT * 
                FROM Receiving
               WHERE DateReceived >= '{0}' AND DateReceived < '{1}'";

        const string LINE_QUERY =
            @"SELECT ln.* 
                FROM ReceivingLine ln
           LEFT JOIN Receiving re
                  ON re.ReceivingID = ln.ReceivingID
               WHERE re.DateReceived >= '{0}' AND re.DateReceived < '{1}'
                 AND ln.qty > 0;";


        public async Task<List<ReceivingLine>> GetMonthly(int year, int month, CancellationToken cancelTkn)
        {
            Dictionary<long, Receiving> parnt = null;
            List<ReceivingLine>         lines = null;

            var parntJob = QueryParent(year, month, cancelTkn);
            var linesJob = QueryLines (year, month, cancelTkn);

            await Task.Run(async () =>
            {
                await Task.WhenAll(parntJob, linesJob);
                parnt = await parntJob;
                lines = await linesJob;
            }
            ).ConfigureAwait(false);

            foreach (var line in lines)
                line.Parent = parnt[line.ReceivingID];

            return lines;
        }


        private async Task<Dictionary<long, Receiving>> QueryParent(int year, int month, CancellationToken cancelTkn)
        {
            var qry  = AddParamsToMonthlySQL(PARENT_QUERY, year, month);
            var dict = new Dictionary<long, Receiving>();

            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                {
                    var parnt = new Receiving(rec);
                    dict.Add(parnt.Id, parnt);
                }
            }
            return dict;
        }


        private async Task<List<ReceivingLine>> QueryLines(int year, int month, CancellationToken cancelTkn)
        {
            var qry  = AddParamsToMonthlySQL(LINE_QUERY, year, month);
            var list = new List<ReceivingLine>();

            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                    list.Add(new ReceivingLine(rec));
            }
            return list;
        }
    }
}
