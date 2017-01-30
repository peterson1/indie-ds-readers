using System;
using System.Linq;
using Autofac;
using FluentAssertions;
using IDSR.CondorReader.Lib.WPF.ComponentRegistry;
using IDSR.CondorReader.Lib.WPF.Viewer.MainTabs;
using Xunit;

namespace IDSR.CondorReader.Tests.MonthlyPurchasesTests
{
    [Trait("LocalDB Read", "2017-01-24_BK")]
    public class MonthlyPurchasesTabVM1Facts
    {
        private MonthlyPurchasesTabVM1 _sut;

        public MonthlyPurchasesTabVM1Facts()
        {
            using (var scope = CondorReaderIoC.BeginScope())
            {
                _sut = scope.Resolve<MonthlyPurchasesTabVM1>();
            }
        }


        [Theory(DisplayName = "Daily Totals")]
        [InlineData(2016, 11, 2, 15301.77)]
        public async void DailyPurchases(int yr, int mo, int day, double expctdTotal)
        {
            _sut.Month = new DateTime(yr, mo, day);
            await _sut.RunQuery();
            var row = _sut.DailyRows.Single(x => x.Date == _sut.Month);
            //var slack = 0.01;

            row.DailyTotal.Should().Be(expctdTotal);
        }
    }
}
