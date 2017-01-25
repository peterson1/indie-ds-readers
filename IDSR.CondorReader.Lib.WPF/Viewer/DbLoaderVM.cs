using System.Linq;
using System.IO;
using System.Reflection;
using Repo2.Core.ns11.DataStructures;

namespace IDSR.CondorReader.Lib.WPF.Viewer
{
    public class DbLoaderVM
    {
        const string LOCAL_DBs_DIR = "LocalDBs";


        public DbLoaderVM()
        {
            Databases = FindDatabases();
        }


        public Observables<DatabaseItem> Databases { get; }


        private Observables<DatabaseItem> FindDatabases()
        {
            var localDBsDir = FindLocalDBsDir();

        }


        private string FindLocalDBsDir()
        {
            var dir = Assembly.GetEntryAssembly().Location;

            while (!LocalDBsDirFound(dir))
            {

            }
        }


        private bool LocalDBsDirFound(string dirPath)
            => Directory.EnumerateDirectories
                (dirPath, LOCAL_DBs_DIR).Any();


        public class DatabaseItem
        {
            public string FilePath { get; set; }

            public override string ToString() 
                => Path.GetFileNameWithoutExtension(FilePath);
        }
    }
}
