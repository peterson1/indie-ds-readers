using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.CondorReader.Core.ns11.ReportRows;
using PropertyChanged;
using Repo2.Core.ns11.DataStructures;
using Repo2.Core.ns11.DateTimeTools;
using Repo2.Core.ns11.InputCommands;
using Repo2.SDK.WPF45.InputCommands;

namespace IDSR.CondorReader.Lib.WPF.Viewer.MainTabs
{
    [ImplementPropertyChanged]
    public class YearEndInventoryTabVM1
    {
        public YearEndInventoryTabVM1(DsrConfiguration1 dsrConfiguration)
        {
            Years    = FillYearsList(dsrConfiguration);
            Year     = Years?.FirstOrDefault();
            QueryCmd = R2Command.Async(RunQuery);
        }

        public string            Title    { get; } = "Year-End Inventory";
        public int?              Year     { get; set; }
        public Observables<int>  Years    { get; }
        public IR2Command        QueryCmd { get; private set; }
        public bool              IsBusy   { get; private set; }

        public Observables<YearEndInventoryRow> Rows { get; } = new Observables<YearEndInventoryRow>();


        private async Task RunQuery()
        {
            if (!Year.HasValue) return;
            IsBusy = true;
            await Task.Delay(1000 * 3);
            IsBusy = false;
        }


        private Observables<int> FillYearsList(DsrConfiguration1 cfg)
        {
            if (cfg?.GrandOpeningDate == null) return null;
            var d8 = cfg.GrandOpeningDate.Value;
            return new Observables<int>(d8.EachYearUpToLastYear());
        }
    }
}
