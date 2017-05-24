using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Lib.WPF.BaseReaders;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IDSR.CondorReader.Lib.WPF.MasterDataReaders
{
    public class ProductsMetaReader : CondorReaderBase1
    {
        public ProductsMetaReader(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
        }


        public async Task<List<CdrProductMeta>> GetAll(CancellationToken cancelTkn = new CancellationToken())
        {
            var metas   = new List<CdrProductMeta>();
            var headers = await GetAllRecords<CdrProduct        >("Products"       , cancelTkn);
            var posSKUs = await GetAllRecords<CdrPOS_Products   >("POS_Products"   , cancelTkn);
            var vndSKUs = await GetAllRecords<CdrVENDOR_Products>("VENDOR_Products", cancelTkn);

            foreach (var hdr in headers)
            {
                var meta         = new CdrProductMeta();
                meta.Header      = hdr;
                meta.POS_SKUs    = posSKUs.Where(x => x.ProductID == hdr.ProductID).ToList();
                meta.Vendor_SKUs = vndSKUs.Where(x => x.ProductID == hdr.ProductID).ToList();
                metas.Add(meta);
            }
            return metas;
        }
    }
}
