using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Lib.WPF.DiskAccess;
using PropertyChanged;
using Repo2.Core.ns11.DataStructures;
using Repo2.Core.ns11.InputCommands;
using Repo2.SDK.WPF45.InputCommands;

namespace IDSR.Common.Lib.WPF.MVVM
{
    [ImplementPropertyChanged]
    public abstract class DbLoaderVmBase
    {
        public event EventHandler MasterDataLoaded;

        private LocalDbFinder _locDbFindr;


        protected abstract Task LoadMasterData(CancellationToken cancelTkn);


        public DbLoaderVmBase(LocalDbFinder localDbFinder)
        {
            _locDbFindr       = localDbFinder;
            LoadMasterDataCmd = R2Command.Async(LoadMasterData);
            try
            {
                Databases = FindDatabases();
            }
            catch  { }
            Database          = Databases?.FirstOrDefault();
        }


        public Observables<DatabaseItem>  Databases          { get; }
        public DatabaseItem               Database           { get; set; }
        public IR2Command                 LoadMasterDataCmd  { get; private set; }
        public bool                       UseServer          { get; set; }
        public bool                       IsBusy             { get; private set; }


        private Observables<DatabaseItem> FindDatabases()
        {
            var dbs   = _locDbFindr.FindDatabaseFiles();
            var items = dbs.Select(x => new DatabaseItem { FilePath = x });
            return new Observables<DatabaseItem>(items);
        }


        public async Task LoadMasterData()
        {
            IsBusy = true;
            await LoadMasterData(new CancellationToken());
            MasterDataLoaded?.Invoke(this, EventArgs.Empty);
            IsBusy = false;
        }


        public class DatabaseItem
        {
            public string FilePath { get; set; }

            public string Name
                => Path.GetFileNameWithoutExtension(FilePath);

            public override string ToString() => Name;
        }
    }
}
