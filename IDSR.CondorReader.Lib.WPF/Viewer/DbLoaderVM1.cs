using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.MVVM;
using IDSR.CondorReader.Lib.WPF.MasterDataReaders;
using PropertyChanged;

namespace IDSR.CondorReader.Lib.WPF.Viewer
{
    public class DbLoaderVM1 : DbLoaderVmBase
    {
        private ProductsReader1 _productReadr;
        private VendorsReader1  _vendorReadr;

        public DbLoaderVM1(LocalDbFinder localDbFinder, 
            ProductsReader1 productsReader,
            VendorsReader1 vendorsReader) : base(localDbFinder)
        {
            _productReadr = productsReader;
            _vendorReadr  = vendorsReader;
        }


        protected async override Task LoadMasterData(CancellationToken cancelTkn)
        {
            if (Database == null) return;

            if (_productReadr != null)
            {
                _productReadr.DatabaseName = Database.Name;
                _productReadr.UseServer    = UseServer;
                await _productReadr.CacheInMemory(cancelTkn);
            }

            if (_vendorReadr != null)
            {
                _vendorReadr.DatabaseName = Database.Name;
                _vendorReadr.UseServer    = UseServer;
                await _vendorReadr.CacheInMemory(cancelTkn);
            }
        }
    }
}
