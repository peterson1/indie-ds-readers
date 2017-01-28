using System;
using System.Data;
using System.Linq;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.SalesReaders;
using Repo2.Core.ns11.DataStructures;
using Repo2.Core.ns11.DateTimeTools;
using Repo2.Core.ns11.InputCommands;
using Repo2.SDK.WPF45.InputCommands;

namespace IDSR.CondorReader.Lib.WPF.Viewer.MainTabs
{
    public class MonthlySalesTabVM1
    {
        private DsrConfiguration1   _cfg;
        private IMonthlySalesReader _readr;
        private DbLoaderVM1         _loadr;

        public MonthlySalesTabVM1(ConfigFileLoader configFileLoader, IMonthlySalesReader monthlySalesReader, DbLoaderVM1 dbLoaderVM)
        {
            _cfg     = configFileLoader.ReadBesideExe();
            _readr   = monthlySalesReader;
            _loadr   = dbLoaderVM;
            Dates    = FillDatesList();
            Date     = Dates?.FirstOrDefault();
            QueryCmd = R2Command.Relay(RunQuery);

            //_loadr.MasterDataLoaded += (a, b)
            //    => QueryCmd.ExecuteIfItCan();
        }

        public string                     Title     { get; } = "Monthly Sales";
        public Observables<FinishedSale>  Sales     { get; } = new Observables<FinishedSale>();
        public DateTime?                  Date      { get; set; }
        public Observables<DateTime>      Dates     { get; }
        public IR2Command                 QueryCmd  { get; private set; }


        private Observables<DateTime> FillDatesList()
        {
            if (_cfg?.GrandOpeningDate == null) return null;

            var day1  = _cfg.GrandOpeningDate.Value;
            var dates = day1.EachDayUpTo(DateTime.Now)
                            .Select(x => new DateTime(x.Year, x.Month, 1))
                            .GroupBy(x => x).Select(x => x.First())
                            .OrderByDescending(x => x).ToList();

            return new Observables<DateTime>(dates);
        }


        private void RunQuery(object arg)
        {
            if (!Date.HasValue) return;
            var d8   = Date.Value;
            _readr.DatabaseName = _loadr.Database.Name;
            //var rows = _readr.Query(d8.Year, d8.Month, new CancellationToken());
            ShowLoading();

            using (var results = _readr.ReadFinishedSales(d8.Year, d8.Month))
            {
                Sales.Clear();
                foreach (IDataRecord rec in results)
                {
                    Sales.Add(_readr.ToFinishedSale(rec));
                }
            }
        }


        private void ShowLoading()
        {
            Sales.Clear();
            Sales.Add(GetLoadingItemRow());
        }


        private FinishedSale GetLoadingItemRow()
            => new FinishedSale
            {
                Product = new Product { Description = "Loading ..." }
            };
    }
}
