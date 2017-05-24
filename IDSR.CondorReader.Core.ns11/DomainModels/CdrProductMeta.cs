using System.Collections.Generic;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrProductMeta
    {
        public CdrProduct                Header      { get; set; }
        public List<CdrPOS_Products>     POS_SKUs    { get; set; }
        public List<CdrVENDOR_Products>  Vendor_SKUs { get; set; }
    }
}
