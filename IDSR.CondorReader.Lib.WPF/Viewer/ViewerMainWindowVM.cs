using IDSR.CondorReader.Lib.WPF.Viewer.MainTabs;
using Repo2.Core.ns11.DataStructures;

namespace IDSR.CondorReader.Lib.WPF.Viewer
{
    public class ViewerMainWindowVM
    {
        public ViewerMainWindowVM(DbLoaderVM1 dbLoaderVM,
                                  YearEndInventoryTabVM1 yearEndInventoryTabVM,
                                  MonthlySalesTabVM1 monthlySalesTabVM)
        {
            DbLoader = dbLoaderVM;
            Tabs     = new Observables<object>
            {
                monthlySalesTabVM,
                yearEndInventoryTabVM,
            };
            DbLoader.MasterDataLoaded += (a, b) 
                => monthlySalesTabVM.QueryCmd.ExecuteIfItCan();
        }


        public string               Title    { get; } = "Condor DB Viewer";
        public Observables<object>  Tabs     { get; }
        public DbLoaderVM1          DbLoader { get; }
    }
}
