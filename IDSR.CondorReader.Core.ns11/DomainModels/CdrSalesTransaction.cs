using System.Collections.Generic;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrSalesTransaction
    {
        public CdrTransactionHeader         Header    { get; set; }
        public List<CdrTransactionLine>     Lines     { get; set; }
        public List<CdrTransactionPayment>  Payments  { get; set; }
    }
}
