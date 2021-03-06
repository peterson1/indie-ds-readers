﻿using System;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class FinishedSale
    {
        public CdrProduct    Product         { get; set; }
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
        public double  OutputVat    => LineTotal - VatableSales;
        public double  VatableSales => GetVatableSales();
        public double  VatExempt    => Product.IsVatable ? 0 : LineTotal;


        private double GetLineTotal()
            => Convert.ToDouble(Return ? DiscountedPrice
                                       : Qty * DiscountedPrice);

        private double GetVatableSales()
            => Product.IsVatable ? LineTotal / (1 + (VatPercent / 100.0))
                                 : 0;
    }
}
