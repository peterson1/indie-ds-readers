using System.Collections.Generic;
using System.Linq;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.ReportRows
{
    public class MonthlySalesTransactionRow
    {
        public MonthlySalesTransactionRow(IGrouping<long, FinishedSale> grp)
        {
            TransactionNo = grp.Key;
            Lines         = grp.ToList();
        }


        public long                TransactionNo  { get; }
        public List<FinishedSale>  Lines          { get; }


        public double VatableSales     => Lines.Sum(x => x.VatableSales);
        public double OutputVat        => Lines.Sum(x => x.OutputVat);
        public double TransactionTotal => Lines.Sum(x => x.LineTotal);
    }
}
