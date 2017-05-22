using IDSR.CondorReader.Lib.WPF.BaseReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    internal class SalesTransactionReader : CondorReaderBase1
    {
        public SalesTransactionReader(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {

        }
    }
}
