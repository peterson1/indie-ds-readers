using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Lib.WPF.BaseReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static IDSR.CondorReader.Core.ns11.SqlQueries.SalesTransactionSQL;
using System.Data;
using IDSR.CondorReader.Core.ns11.Converters;
using Repo2.SDK.WPF45.Exceptions;
using Repo2.Core.ns11.Extensions.StringExtensions;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class SalesTransactionReader : CondorReaderBase1
    {
        public SalesTransactionReader(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
        }


        public async Task<List<CdrSalesTransaction>> ByCashierSession(int cdrUserId, uint terminalId, DateTime date, CancellationToken canclr = new CancellationToken())
        {
            var headrJob = QueryList<CdrTransactionHeader>(
                                HeadersQuery(date, date).AND_Terminal(terminalId)
                                                        .AND_Cashier(cdrUserId),
                                    r => new CdrTransactionHeader(r), canclr);

            var linesJob = QueryList<CdrTransactionLine>(
                                LinesQuery(date, date).AND_Terminal(terminalId)
                                                      .AND_Cashier(cdrUserId),
                                    r => ParseTransactionLine(r), canclr);

            var pymntsJob = QueryList<CdrTransactionPayment>(
                                PaymentsQuery(date, date).AND_Terminal(terminalId)
                                                         .AND_Cashier(cdrUserId),
                                    r => new CdrTransactionPayment(r), canclr);

            await Task.WhenAll(headrJob, linesJob, pymntsJob);

            return CreateTransactionsList(await headrJob,
                                          await linesJob,
                                          await pymntsJob);
        }


        public async Task<List<CdrSalesTransaction>> GetByTerminal(uint terminalId, DateTime date, CancellationToken canclr = new CancellationToken())
        {
            var headrJob = QueryList<CdrTransactionHeader>(
                                HeadersQuery(date, date).AND_Terminal(terminalId), 
                                    r => new CdrTransactionHeader(r), canclr);

            var linesJob = QueryList<CdrTransactionLine>(
                                LinesQuery(date, date).AND_Terminal(terminalId),
                                    r => ParseTransactionLine(r), canclr);

            var pymntsJob = QueryList<CdrTransactionPayment>(
                                PaymentsQuery(date, date).AND_Terminal(terminalId),
                                    r => new CdrTransactionPayment(r), canclr);

            await Task.WhenAll(headrJob, linesJob, pymntsJob);

            return CreateTransactionsList(await headrJob, 
                                          await linesJob, 
                                          await pymntsJob);
        }


        public async Task<List<CdrSalesTransaction>> GetByDates(DateTime start, DateTime end, CancellationToken canclr = new CancellationToken())
        {
            var headrs = await QueryList<CdrTransactionHeader>(HeadersQuery(start, end),
                                                r => new CdrTransactionHeader(r), canclr);

            var lines = await QueryList<CdrTransactionLine>(LinesQuery(start, end),
                                                r => ParseTransactionLine(r), canclr);

            var pymnts = await QueryList<CdrTransactionPayment>(PaymentsQuery(start, end),
                                                r => new CdrTransactionPayment(r), canclr);

            return CreateTransactionsList(headrs, lines, pymnts);
        }


        private static List<CdrSalesTransaction> CreateTransactionsList(List<CdrTransactionHeader> headrs, List<CdrTransactionLine> lines, List<CdrTransactionPayment> pymnts)
        {
            var txns = new List<CdrSalesTransaction>();
            foreach (var hdr in headrs)
            {
                var txn    = new CdrSalesTransaction();
                txn.Header = hdr;
                txn.Lines  = lines.Where(x => x.TransactionNo == hdr.TransactionNo
                                              && x.TerminalNo == hdr.TerminalNo).ToList();

                txn.Payments = pymnts.Where(x => x.TransactionNo == hdr.TransactionNo
                                                 && x.TerminalNo == hdr.TerminalNo).ToList();
                txns.Add(txn);
            }
            return txns;
        }

        private CdrTransactionLine ParseTransactionLine(IDataRecord r)
        {
            try
            {
                return new CdrTransactionLine(r);
            }
            catch (BarcodeParseException ex)
            {
                Alerter.ShowError("Barcode Parse Error",
                            $"Table: “FinishedSales”"
                    + L.f + $"Record: “{ex.RecordTitle}”"
                    + L.f + $"Barcode: “{ex.BarcodeText}”");
                return null;
            }
        }
    }
}
