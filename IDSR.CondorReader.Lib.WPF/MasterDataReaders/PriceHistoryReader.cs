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
    public class PriceHistoryReader : CondorReaderBase1
    {
        public PriceHistoryReader(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
        }


        public async Task<List<CdrPriceChangeHistory>> GetAll(CancellationToken cancelTkn = new CancellationToken())
        {
            var changesJob  = GetAllRecords<CdrPriceChangeHistory>("PriceChangeHistory", cancelTkn);
            var barcodesJob = GetAllRecords<CdrPOS_Products>("POS_Products", cancelTkn);
            await Task.WhenAll(changesJob, barcodesJob);
            //var skusJob = GetAllRecords<CdrProduct>("Products", cancelTkn);
            //await Task.WhenAll(changesJob, skusJob);

            var changes  = await changesJob;
            var barcodes = await barcodesJob;
            //var skus     = await skusJob;

            foreach (var change in changes)
            {
                var bcs = barcodes.Where(x => x.ProductID == change.productid
                                           && x.Barcode   == change.barcode);

                change.SellingBarcodes = bcs.ToList();
                //change.Product = skus.SingleOrDefault(x => x.ProductID == change.productid);
            }

            return changes;
        }
    }
}
