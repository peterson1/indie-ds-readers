using System;
using System.Linq;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.CondorReader.Core.ns11.DomainModels;
using Repo2.Core.ns11.DataStructures;
using Repo2.Core.ns11.DateTimeTools;
using Repo2.Core.ns11.InputCommands;
using Repo2.SDK.WPF45.InputCommands;

namespace IDSR.CondorReader.Lib.WPF.Viewer.MainTabs
{
    public class MonthlySalesTabVM1
    {
        private DsrConfiguration1 _cfg;

        public MonthlySalesTabVM1(ConfigFileLoader configFileLoader)
        {
            _cfg     = configFileLoader.ReadBesideExe();
            Dates    = FillDatesList();
            Date     = Dates?.FirstOrDefault();
            QueryCmd = R2Command.Async(RunQuery);
        }

        public string                     Title     { get; } = "Monthly Sales";
        public DateTime?                  Date      { get; set; }
        public Observables<DateTime>      Dates     { get; }
        public Observables<FinishedSale>  Sales     { get; }
        public IR2Command                 QueryCmd  { get; }


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


        private Task RunQuery(object arg)
        {
            throw new NotImplementedException();
        }
    }
}
