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


        public async Task<List<CdrSalesTransaction>> GetByDates(DateTime start, DateTime end, CancellationToken canclr = new CancellationToken())
        {
            var headrs = await QueryList<CdrTransactionHeader>(HeadersQuery(start, end), 
                                                r => new CdrTransactionHeader(r), canclr);

            var lines  = await QueryList<CdrTransactionLine>(LinesQuery(start, end), 
                                                r => ParseTransactionLine(r), canclr);

            var pymnts = await QueryList<CdrTransactionPayment>(PaymentsQuery(start, end),
                                                r => new CdrTransactionPayment(r), canclr);

            var txns = new List<CdrSalesTransaction>();
            foreach (var hdr in headrs)
            {
                var txn      = new CdrSalesTransaction();
                txn.Header   = hdr;
                txn.Lines    = lines.Where(x => x.TransactionNo == hdr.TransactionNo).ToList();
                txn.Payments = pymnts.Where(x => x.TransactionNo == hdr.TransactionNo).ToList();
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
