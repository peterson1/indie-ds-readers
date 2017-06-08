using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Lib.WPF.BaseReaders;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class RemittanceReader : CondorReaderBase1
    {
        public RemittanceReader(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
        }


        public Task<List<CdrRemittance>> ForDate(DateTime date, CancellationToken cancelTkn = new CancellationToken())
        {
            var qry = $@"SELECT * 
                           FROM Remittance 
                          WHERE fldLogDate >= '{date.Date:yyyy-MM-dd}'
                            AND fldLogDate <  '{date.Date.AddDays(1):yyyy-MM-dd}'";

            return QueryList<CdrRemittance>(qry, r => new CdrRemittance(r), cancelTkn);
        }
    }
}
