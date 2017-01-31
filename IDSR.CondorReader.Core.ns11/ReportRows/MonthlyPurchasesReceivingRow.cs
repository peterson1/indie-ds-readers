using System.Collections.Generic;
using System.Linq;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.ReportRows
{
    public class MonthlyPurchasesReceivingRow
    {
        public MonthlyPurchasesReceivingRow(IGrouping<long, ReceivingLine> grp)
        {
            Receiving = grp.FirstOrDefault()?.Parent;
            Lines     = grp.ToList();
        }

        public Receiving            Receiving { get; }
        public List<ReceivingLine>  Lines     { get; }

        //public string  Label => Order?.Description;
        //public double? Total => Order?.NetTotal;
    }
}
