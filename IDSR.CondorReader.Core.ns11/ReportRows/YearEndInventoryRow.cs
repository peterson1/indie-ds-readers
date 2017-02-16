using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.ReportRows
{
    public class YearEndInventoryRow
    {
        public CdrProduct  Product     { get; set; }
        public decimal  LastPCount  { get; set; }
        public decimal  YearEndSRP  { get; set; }
        public decimal  LandedCost  { get; set; }
    }
}
