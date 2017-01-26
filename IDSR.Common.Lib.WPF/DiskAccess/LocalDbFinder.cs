using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Repo2.Core.ns11.Extensions.StringExtensions;

namespace IDSR.Common.Lib.WPF.DiskAccess
{
    public class LocalDbFinder
    {
        const string LOCAL_DBs_DIR = "LocalDBs";
        const string DB_FILE_PATTERN = "*.db3";


        public IEnumerable<string> FindDatabaseFiles()
        {
            var localDBsDir = FindLocalDBsDir();
            if (localDBsDir.IsBlank())
                throw new DirectoryNotFoundException(
                    $"Can't find “{LOCAL_DBs_DIR}” folder.");

            var files = Directory.EnumerateFiles(localDBsDir, DB_FILE_PATTERN);
            if (files.Count() == 0)
                throw new FileNotFoundException(
                    $"No database files found using filter: “{DB_FILE_PATTERN}”.");

            return files.OrderByDescending(x => x);
        }


        public string FindDatabaseFile(string dbFileNameWithoutExtension)
        {
            var files = FindDatabaseFiles();
            var matches = files.Where(x 
                => Path.GetFileNameWithoutExtension(x) == dbFileNameWithoutExtension);
            return matches.SingleOrDefault();
        }


        private string FindLocalDBsDir()
        {
            //var asmbly = Assembly.GetEntryAssembly();
            //if (asmbly == null) asmbly = Assembly.GetExecutingAssembly();
            //if (asmbly == null)
            //    throw new ApplicationException("No Assembly to get location from.");

            //var exeP = asmbly.Location;
            //var dir  = Directory.GetParent(exeP).FullName;

            var dir = AppDomain.CurrentDomain.BaseDirectory;

            while (!LocalDBsDirFound(dir))
            {
                var parent = Directory.GetParent(dir);
                if (parent == null) return null;
                dir = parent.FullName;
            }

            return Path.Combine(dir, LOCAL_DBs_DIR);
        }


        private bool LocalDBsDirFound(string dirPath)
            => Directory.EnumerateDirectories
                (dirPath, LOCAL_DBs_DIR).Any();
    }
}
