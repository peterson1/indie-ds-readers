using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Core.ns11.SqlTools;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.SqlDbReaders;
using IDSR.CondorReader.Core.ns11;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class ReceivingReader1 : SqlDbReaderBase, IDsrDbReader<ReceivingLine>
    {
        public ReceivingReader1(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
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



        public Task<List<ReceivingLine>> GetDateRange(DateTime startDate, DateTime endDate, CancellationToken cancelTkn)
            => RunJobs(QueryParent(startDate, endDate, cancelTkn),
                        QueryLines(startDate, endDate, cancelTkn));

        private Task<Dictionary<long, Receiving>> QueryParent(DateTime startDate, DateTime endDate, CancellationToken cancelTkn)
            => QueryParent(AddParamsToDateRangeSQL(PARENT_QUERY, startDate, endDate), cancelTkn);

        private Task<List<ReceivingLine>> QueryLines(DateTime startDate, DateTime endDate, CancellationToken cancelTkn)
            => QueryLines(AddParamsToDateRangeSQL(LINE_QUERY, startDate, endDate), cancelTkn);



        public Task<List<ReceivingLine>> GetMonthly(int year, int month, CancellationToken cancelTkn)
            => RunJobs(QueryParent(year, month, cancelTkn), 
                        QueryLines(year, month, cancelTkn));

        private Task<Dictionary<long, Receiving>> QueryParent(int year, int month, CancellationToken cancelTkn)
            => QueryParent(AddParamsToMonthlySQL(PARENT_QUERY, year, month), cancelTkn);

        private Task<List<ReceivingLine>> QueryLines(int year, int month, CancellationToken cancelTkn)
            => QueryLines(AddParamsToMonthlySQL(LINE_QUERY, year, month), cancelTkn);



        private static async Task<List<ReceivingLine>> RunJobs(Task<Dictionary<long, Receiving>> parntJob, Task<List<ReceivingLine>> linesJob)
        {
            Dictionary<long, Receiving> parnt = null;
            List<ReceivingLine>         lines = null;

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


        private async Task<Dictionary<long, Receiving>> QueryParent(string qry, CancellationToken cancelTkn)
        {
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


        private async Task<List<ReceivingLine>> QueryLines(string qry, CancellationToken cancelTkn)
        {
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
