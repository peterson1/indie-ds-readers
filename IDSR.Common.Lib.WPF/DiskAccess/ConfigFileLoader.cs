using System.IO;
using IDSR.Common.Core.ns11.Configuration;
using Repo2.Core.ns11.FileSystems;

namespace IDSR.Common.Lib.WPF.DiskAccess
{
    public class ConfigFileLoader
    {
        const string SETTINGS_CFG = "settings.cfg";

        private IFileSystemAccesor _fs;
        private DsrConfiguration1  _lastLoaded;

        public ConfigFileLoader(IFileSystemAccesor fileSystemAccesor)
        {
            _fs = fileSystemAccesor;
        }


        public DsrConfiguration1 GetLastLoaded()
            => _lastLoaded ?? (_lastLoaded = ReadBesideExe());


        private DsrConfiguration1 ReadBesideExe()
        {
            try
            {
                return _fs.ReadJsonFileBesideExe<DsrConfiguration1>(SETTINGS_CFG);
            }
            catch (FileNotFoundException)
            {
                _fs.WriteJsonFileBesideExe(SETTINGS_CFG, DsrConfiguration1.CreateDefault());
                return null;
            }
        }
    }
}
