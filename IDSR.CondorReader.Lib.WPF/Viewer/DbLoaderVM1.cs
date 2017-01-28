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

        public DbLoaderVM1(LocalDbFinder localDbFinder, ProductsReader1 productsReader) : base(localDbFinder)
        {
            _productReadr = productsReader;
        }


        protected async override Task LoadMasterData(CancellationToken cancelTkn)
        {
            if (_productReadr == null) return;
            _productReadr.DatabaseName = Database.Name;
            await _productReadr.CacheInMemory(cancelTkn);
        }
    }
}
