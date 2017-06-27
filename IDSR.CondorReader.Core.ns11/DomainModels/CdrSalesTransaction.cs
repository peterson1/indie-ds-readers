using System.Collections.Generic;
using System.Linq;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrSalesTransaction
    {
        public CdrTransactionHeader         Header    { get; set; }
        public List<CdrTransactionLine>     Lines     { get; set; }
        public List<CdrTransactionLine>     Returns   { get; set; }
        public List<CdrTransactionPayment>  Payments  { get; set; }


        public override string ToString()
            => $"POS Transaction:{Header?.TransactionNo}"
                        + $" Terminal:{Header?.TerminalNo}"
                        + $" Lines:{Lines?.Count}"
                        + $" Payments:{Payments?.Count}"
                        + $" P{this.Payments.Sum(x => x.Amount):N0}";
    }
}
