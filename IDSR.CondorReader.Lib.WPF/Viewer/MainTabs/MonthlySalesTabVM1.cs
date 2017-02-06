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
    public class MonthlySalesTabVM1 : MonthlyTabVmBase<FinishedSale>
    {
        private IDsrDbReader<FinishedSale> _readr;

        public MonthlySalesTabVM1(IDsrDbReader<FinishedSale> monthlySalesReader, DsrConfiguration1 dsrConfiguration, DbLoaderVM1 dbLoaderVM) : base(dsrConfiguration, dbLoaderVM)
        {
            Title  = "Monthly Sales";
            _readr = monthlySalesReader;
        }


        public double  VatableSales  { get; private set; }
        public double  OutputVat     { get; private set; }
        public double  VatExempt     { get; private set; }
        public double  MonthlyTotal  { get; private set; }

        public Observables<MonthlySalesDailyRow>  DailyRows { get; } = new Observables<MonthlySalesDailyRow>();

        protected override IDsrDbReader<FinishedSale> Reader => _readr;


        protected override void Visualize(List<FinishedSale> list)
        {
            DailyRows.Swap(list.GroupBy (x => x.TimeScanned.Value.Date)
                               .Select  (x => new MonthlySalesDailyRow(x))
                               .OrderBy (x => x.Date)
                               .ToList  ());

            VatableSales = DailyRows.Sum(x => x.VatableSales);
            OutputVat    = DailyRows.Sum(x => x.OutputVat);
            MonthlyTotal = DailyRows.Sum(x => x.DailyTotal);
            VatExempt    = DailyRows.Sum(x => x.VatExempt);
        }
    }
}
