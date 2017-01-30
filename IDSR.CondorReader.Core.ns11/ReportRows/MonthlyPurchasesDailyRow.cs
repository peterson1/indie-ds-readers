using System;
using System.Collections.Generic;
using System.Linq;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.ReportRows
{
    public class MonthlyPurchasesDailyRow
    {
        public MonthlyPurchasesDailyRow(IGrouping<DateTime, PurchaseOrderLine> grp)
        {
            Date   = grp.Key;
            Orders = GroupByOrder(grp);
        }

        public DateTime Date { get; }
        public List<MonthlyPurchasesOrderRow> Orders { get; }


        public double? DailyTotal => Orders?.Sum(x => x.Order?.NetTotal);


        private List<MonthlyPurchasesOrderRow> GroupByOrder(IEnumerable<PurchaseOrderLine> lines)
            => lines.GroupBy (x => x.OrderId)
                    .Select  (x => new MonthlyPurchasesOrderRow(x))
                    .OrderBy (x => x.Order.Id)
                    .ToList  ();
    }
}
