using System.IO;
using System.Linq;
using IDSR.Common.Lib.WPF.DiskAccess;
using Repo2.Core.ns11.DataStructures;

namespace IDSR.Common.Lib.WPF.MVVM
{
    public class DbLoaderVM1
    {
        private LocalDbFinder _locDbFindr;

        public DbLoaderVM1(LocalDbFinder localDbFinder)
        {
            _locDbFindr = localDbFinder;
            Databases = FindDatabases();
            Database = Databases?.FirstOrDefault();
        }


        public Observables<DatabaseItem> Databases { get; }
        public DatabaseItem Database { get; set; }


        private Observables<DatabaseItem> FindDatabases()
        {
            var dbs = _locDbFindr.FindDatabaseFiles();
            var items = dbs.Select(x => new DatabaseItem { FilePath = x });
            return new Observables<DatabaseItem>(items);
        }




        public class DatabaseItem
        {
            public string FilePath { get; set; }

            public override string ToString()
                => Path.GetFileNameWithoutExtension(FilePath);
        }
    }
}
