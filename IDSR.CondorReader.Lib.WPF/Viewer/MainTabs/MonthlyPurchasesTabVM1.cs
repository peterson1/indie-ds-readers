using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Core.ns11.SqlTools;
using IDSR.CondorReader.Core.ns11;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.ReportRows;
using PropertyChanged;
using Repo2.Core.ns11.DataStructures;

namespace IDSR.CondorReader.Lib.WPF.Viewer.MainTabs
{
    [ImplementPropertyChanged]
    public class MonthlyPurchasesTabVM1 : MonthlyTabVmBase<CdrReceivingLine>
    {
        private IDsrDbReader<CdrReceivingLine> _readr;

        public MonthlyPurchasesTabVM1(IDsrDbReader<CdrReceivingLine> monthlyPurchasesReader, DsrConfiguration1 dsrConfiguration, DbLoaderVM1 dbLoaderVM) : base(dsrConfiguration, dbLoaderVM)
        {
            Title  = "Monthly Purchases";
            _readr = monthlyPurchasesReader;
        }


        public Observables<MonthlyPurchasesDailyRow>  DailyRows { get; } = new Observables<MonthlyPurchasesDailyRow>();

        protected override IDsrDbReader<CdrReceivingLine> Reader => _readr;


        protected override void Visualize(List<CdrReceivingLine> list)
        {
            DailyRows.Swap(list.GroupBy (x => x.Parent.DateReceived.Value.Date)
                               .Select  (x => new MonthlyPurchasesDailyRow(x))
                               .OrderBy (x => x.Date)
                               .ToList  ());
        }
    }
}
