using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.ReportRows;
using IDSR.CondorReader.Core.ns11.SalesReaders;
using PropertyChanged;
using Repo2.Core.ns11.DataStructures;
using Repo2.Core.ns11.DateTimeTools;
using Repo2.Core.ns11.InputCommands;
using Repo2.SDK.WPF45.InputCommands;

namespace IDSR.CondorReader.Lib.WPF.Viewer.MainTabs
{
    [ImplementPropertyChanged]
    public class MonthlySalesTabVM1
    {
        private DsrConfiguration1   _cfg;
        private IMonthlySalesReader _readr;
        private DbLoaderVM1         _loadr;

        public MonthlySalesTabVM1(DsrConfiguration1 dsrConfiguration, IMonthlySalesReader monthlySalesReader, DbLoaderVM1 dbLoaderVM)
        {
            _cfg     = dsrConfiguration;
            _readr   = monthlySalesReader;
            _loadr   = dbLoaderVM;
            Dates    = FillDatesList();
            Date     = Dates?.FirstOrDefault();
            QueryCmd = R2Command.Async(RunQuery);
        }

        public string                     Title     { get; } = "Monthly Sales";
        public DateTime?                  Date      { get; set; }
        public Observables<DateTime>      Dates     { get; }
        public IR2Command                 QueryCmd  { get; private set; }
        public bool                       IsBusy    { get; private set; }

        public Observables<FinishedSale>          Details   { get; } = new Observables<FinishedSale>();
        public Observables<MonthlySalesDailyRow>  DailyRows { get; } = new Observables<MonthlySalesDailyRow>();

        public double  VatableSales  { get; private set; }


        private Observables<DateTime> FillDatesList()
        {
            if (_cfg?.GrandOpeningDate == null) return null;
            var day1 = _cfg.GrandOpeningDate.Value;
            var list = day1.EachMonthUpToNow();
            return new Observables<DateTime>(list);
        }


        public async Task RunQuery()
        {
            if (!Date.HasValue) return;
            if (_loadr.Database == null) return;

            IsBusy = true;
            _readr.DatabaseName = _loadr.Database.Name;
            var yr   = Date.Value.Year;
            var mo   = Date.Value.Month;
            var tkn  = new CancellationToken();
            var list = await _readr.GetFinishedSales(yr, mo, tkn);

            PopulateRows(list);

            IsBusy = false;
        }


        private void PopulateRows(List<FinishedSale> list)
        {
            DailyRows.Swap(list.GroupBy (x => x.TimeScanned.Value.Date)
                               .Select  (x => new MonthlySalesDailyRow(x))
                               .OrderBy (x => x.Date)
                               .ToList  ());
            Details.Swap(list);

            VatableSales = Details.Sum(x => x.VatableSales);
        }
    }
}
