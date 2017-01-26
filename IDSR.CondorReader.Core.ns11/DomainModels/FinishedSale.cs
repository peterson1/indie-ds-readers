using System;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class FinishedSale
    {
        public Product   Product      { get; set; }
        public decimal   TotalQty     { get; set; }
        public string    TerminalNo   { get; set; }
        public DateTime  TimeScanned  { get; set; }
    }
}
