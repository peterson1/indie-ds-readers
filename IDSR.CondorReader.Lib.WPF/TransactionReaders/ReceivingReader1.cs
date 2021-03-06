﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Core.ns11.SqlTools;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.SqlDbReaders;
using IDSR.CondorReader.Core.ns11;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Lib.WPF.BaseReaders;
using Repo2.Core.ns11.Extensions.StringExtensions;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class ReceivingReader1 : CondorReaderBase1, IDsrDbReader<CdrReceivingLine>
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



        public Task<List<CdrReceivingLine>> GetDateRange(DateTime startDate, DateTime endDate, CancellationToken cancelTkn)
            => RunJobs(QueryParent(startDate, endDate, cancelTkn),
                        QueryLines(startDate, endDate, cancelTkn),
                        QueryUsers(cancelTkn));

        private Task<Dictionary<long, CdrReceiving>> QueryParent(DateTime startDate, DateTime endDate, CancellationToken cancelTkn)
            => QueryParent(AddParamsToDateRangeSQL(PARENT_QUERY, startDate, endDate), cancelTkn);

        private Task<List<CdrReceivingLine>> QueryLines(DateTime startDate, DateTime endDate, CancellationToken cancelTkn)
            => QueryLines(AddParamsToDateRangeSQL(LINE_QUERY, startDate, endDate), cancelTkn);



        public Task<List<CdrReceivingLine>> GetMonthly(int year, int month, CancellationToken cancelTkn)
            => RunJobs(QueryParent(year, month, cancelTkn), 
                        QueryLines(year, month, cancelTkn),
                        QueryUsers(cancelTkn));

        private Task<Dictionary<long, CdrReceiving>> QueryParent(int year, int month, CancellationToken cancelTkn)
            => QueryParent(AddParamsToMonthlySQL(PARENT_QUERY, year, month), cancelTkn);

        private Task<List<CdrReceivingLine>> QueryLines(int year, int month, CancellationToken cancelTkn)
            => QueryLines(AddParamsToMonthlySQL(LINE_QUERY, year, month), cancelTkn);



        private static async Task<List<CdrReceivingLine>> RunJobs(
            Task<Dictionary<long, CdrReceiving>> parntJob, 
            Task<List<CdrReceivingLine>> linesJob,
            Task<Dictionary<int, string>> usersJob)
        {
            Dictionary<long, CdrReceiving> parnt = null;
            List<CdrReceivingLine>         lines = null;
            Dictionary<int, string>        users = null;

            await Task.Run(async () =>
            {
                await Task.WhenAll(parntJob, linesJob);
                parnt = await parntJob;
                lines = await linesJob;
                users = await usersJob;
            }
            ).ConfigureAwait(false);

            if (parnt == null) return null;

            foreach (var line in lines)
                line.Parent = parnt[line.ReceivingID];

            foreach (var grp in lines.GroupBy(x => x.ReceivingID))
            {
                var p = parnt[grp.Key];
                p.Lines = grp.ToList();

                if (!p.PostedBy.IsBlank())
                    p.PostedByName = users[int.Parse(p.PostedBy)];
            }

            return lines;
        }


        private async Task<Dictionary<long, CdrReceiving>> QueryParent(string qry, CancellationToken cancelTkn)
        {
            var dict = new Dictionary<long, CdrReceiving>();

            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                if (results == null) return null;
                foreach (IDataRecord rec in results)
                {
                    var parnt = new CdrReceiving(rec);
                    dict.Add(parnt.ReceivingID, parnt);
                }
            }
            return dict;
        }


        private async Task<List<CdrReceivingLine>> QueryLines(string qry, CancellationToken cancelTkn)
        {
            var list = new List<CdrReceivingLine>();

            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                    list.Add(new CdrReceivingLine(rec));
            }
            return list;
        }

        public Task<List<CdrReceivingLine>> GetByIDs(IEnumerable<int> idsList, CancellationToken cancelTkn)
        {
            throw new NotImplementedException();
        }
    }
}
