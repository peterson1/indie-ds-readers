using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.CondorReader.Core.ns11;
using PropertyChanged;
using Repo2.Core.ns11.DataStructures;
using Repo2.Core.ns11.DateTimeTools;
using Repo2.Core.ns11.InputCommands;
using Repo2.SDK.WPF45.InputCommands;

namespace IDSR.CondorReader.Lib.WPF.Viewer.MainTabs
{
    [ImplementPropertyChanged]
    public abstract class MonthlyTabVmBase<T>
    {
        protected DsrConfiguration1 _cfg;
        protected DbLoaderVM1       _loadr;

        public MonthlyTabVmBase(DsrConfiguration1 dsrConfiguration, DbLoaderVM1 dbLoaderVM)
        {
            _cfg     = dsrConfiguration;
            _loadr   = dbLoaderVM;
            Months   = FillDatesList();
            Month    = Months?.FirstOrDefault();
            QueryCmd = R2Command.Async(RunQuery);
        }

        public string                 Title     { get; protected set; }
        public DateTime?              Month     { get; set; }
        public Observables<DateTime>  Months    { get; }
        public IR2Command             QueryCmd  { get; private set; }
        public bool                   IsBusy    { get; private set; }


        protected abstract IDsrDbReader<T> Reader    { get; }
        protected abstract void            Visualize (List<T> list);


        private Observables<DateTime> FillDatesList()
        {
            if (_cfg?.GrandOpeningDate == null) return null;
            var day1 = _cfg.GrandOpeningDate.Value;
            var list = day1.EachMonthUpToNow();
            return new Observables<DateTime>(list);
        }


        public async Task RunQuery()
        {
            if (!Month.HasValue) return;
            if (_loadr.Database == null) return;

            IsBusy  = true;
            var yr  = Month.Value.Year;
            var mo  = Month.Value.Month;
            var tkn = new CancellationToken();

            Reader.DatabaseName = _loadr.Database.Name;

            var list = await Reader.GetMonthly(yr, mo, tkn);
            Visualize(list);

            IsBusy = false;
        }
    }
}
