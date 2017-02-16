using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.SqlDbReaders;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.MasterDataReaders;

namespace IDSR.CondorReader.Lib.WPF.MasterDataReaders
{
    public class ProductsReader1 : SqlDbReaderBase
    {
        private ProductCache _cache;


        public ProductsReader1(LocalDbFinder localDbFinder, ProductCache productsCache, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
            _cache = productsCache;
        }


        public async Task CacheInMemory(CancellationToken cancelTkn)
        {
            using (var readr = await ConnectAndReadAsync(SQL_QUERY, cancelTkn))
            {
                _cache.Clear();
                foreach (IDataRecord rec in readr)
                {
                    _cache.Add(new CdrProduct(rec));
                }
            }
        }


        const string SQL_QUERY = "SELECT * FROM Products";
    }
}
