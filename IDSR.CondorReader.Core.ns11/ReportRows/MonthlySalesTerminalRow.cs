using System.Collections.Generic;
using System.Linq;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.ReportRows
{
    public class MonthlySalesTerminalRow
    {
        public MonthlySalesTerminalRow(IGrouping<string, FinishedSale> grp)
        {
            Terminal     = grp.Key;
            Transactions = GroupByTransaction(grp);
        }


        public string   Terminal  { get; }
        public List<MonthlySalesTransactionRow>  Transactions   { get; }


        public double TerminalTotal => Transactions.Sum(x => x.TransactionTotal);


        private List<MonthlySalesTransactionRow> GroupByTransaction(IGrouping<string, FinishedSale> items)
            => items.GroupBy (x => x.TransactionNo)
                    .Select  (x => new MonthlySalesTransactionRow(x))
                    .OrderBy (x => x.TransactionNo)
                    .ToList  ();
    }
}
