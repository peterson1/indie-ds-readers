using System.Collections.Generic;
using System.Linq;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.ReportRows
{
    public class MonthlyPurchasesReceivingRow
    {
        public MonthlyPurchasesReceivingRow(IGrouping<long, CdrReceivingLine> grp)
        {
            Receiving = grp.FirstOrDefault()?.Parent;
            Lines     = grp.ToList();
        }

        public CdrReceiving            Receiving { get; }
        public List<CdrReceivingLine>  Lines     { get; }

        //public string  Label => Order?.Description;
        //public double? Total => Order?.NetTotal;
    }
}
