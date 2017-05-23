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
                                                r => new CdrTransactionLine(r), canclr);

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
    }
}
