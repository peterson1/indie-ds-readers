using System.Collections.Generic;
using System.Linq;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.ReportRows
{
    public class MonthlyPurchasesOrderRow
    {
        private IGrouping<long, PurchaseOrderLine> x;

        public MonthlyPurchasesOrderRow(IGrouping<long, PurchaseOrderLine> grp)
        {
            Order = grp.FirstOrDefault()?.Order;
            Lines = grp.ToList();
        }

        public PurchaseOrder            Order { get; }
        public List<PurchaseOrderLine>  Lines { get; }

        //public string  Label => Order?.Description;
        //public double? Total => Order?.NetTotal;
    }
}
