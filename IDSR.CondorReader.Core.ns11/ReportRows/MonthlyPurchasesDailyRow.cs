using System;
using System.Collections.Generic;
using System.Linq;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.ReportRows
{
    public class MonthlyPurchasesDailyRow
    {
        public MonthlyPurchasesDailyRow(IGrouping<DateTime, CdrReceivingLine> grp)
        {
            Date       = grp.Key;
            Receivings = GroupByReceiving(grp);
        }

        public DateTime Date { get; }
        public List<MonthlyPurchasesReceivingRow> Receivings { get; }


        public double? DailyTotal => Receivings?.Sum(x => x.Receiving?.NetTotal);


        private List<MonthlyPurchasesReceivingRow> GroupByReceiving(IEnumerable<CdrReceivingLine> lines)
            => lines.GroupBy (x => x.ReceivingID)
                    .Select  (x => new MonthlyPurchasesReceivingRow(x))
                    .OrderBy (x => x.Receiving.Id)
                    .ToList  ();
    }
}
