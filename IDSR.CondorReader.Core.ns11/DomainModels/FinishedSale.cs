using System;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class FinishedSale
    {
        public Product    Product         { get; set; }
        public decimal    TotalQty        { get; set; }
        public string     TerminalNo      { get; set; }
        public DateTime?  TimeScanned     { get; set; }
        public decimal    ScannedSRP      { get; set; }
        public decimal    DiscountedPrice { get; set; }
        public string     ReturnRemarks   { get; set; }
    }
}
