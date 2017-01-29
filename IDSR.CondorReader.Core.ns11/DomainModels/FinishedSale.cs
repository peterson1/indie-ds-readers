using System;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class FinishedSale
    {
        public Product    Product         { get; set; }
        public decimal    Qty             { get; set; }
        public string     TerminalNo      { get; set; }
        public DateTime?  TimeScanned     { get; set; }
        public decimal    ScannedSRP      { get; set; }
        public decimal    DiscountedPrice { get; set; }
        public string     ReturnRemarks   { get; set; }
        public long       VatPercent      { get; set; }
        public long       TransactionNo   { get; set; }
        public bool       Return          { get; set; }

        public double  LineTotal    => GetLineTotal();
        public double  VatAmount    => LineTotal * (VatPercent / 100.0);
        public double  VatableSales => LineTotal - VatAmount;

        private double GetLineTotal()
            => Convert.ToDouble(Return ? DiscountedPrice
                                       : Qty * DiscountedPrice);

    }
}
