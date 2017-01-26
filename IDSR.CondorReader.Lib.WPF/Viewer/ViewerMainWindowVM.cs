using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.MVVM;
using IDSR.CondorReader.Lib.WPF.Viewer.MainTabs;
using Repo2.Core.ns11.DataStructures;

namespace IDSR.CondorReader.Lib.WPF.Viewer
{
    public class ViewerMainWindowVM
    {
        public ViewerMainWindowVM(DbLoaderVM1 dbLoaderVM,
                                  MonthlySalesTabVM1 monthlySalesTabVM1)
        {
            DbLoader = dbLoaderVM;
            Tabs     = new Observables<object> { monthlySalesTabVM1 };
        }


        public string               Title    { get; } = "Condor DB Viewer";
        public Observables<object>  Tabs     { get; }
        public DbLoaderVM1          DbLoader { get; }
    }
}
