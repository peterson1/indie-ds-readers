using System;
using System.Linq;
using Autofac;
using FluentAssertions;
using IDSR.CondorReader.Lib.WPF.ComponentRegistry;
using IDSR.CondorReader.Lib.WPF.Viewer.MainTabs;
using Xunit;

namespace IDSR.CondorReader.Tests.MonthlySalesTests
{
    [Trait("LocalDB Read", "2017-01-24_BK")]
    public class MonthlySalesTabVM1Facts
    {
        private MonthlySalesTabVM1 _sut;

        public MonthlySalesTabVM1Facts()
        {
            using (var scope = CondorReaderIoC.BeginScope())
            {
                _sut   = scope.Resolve<MonthlySalesTabVM1>();
            }
        }


        [Theory(DisplayName = "Terminal Totals")]
        [InlineData(2016, 11,  1, 17144.29, 60087.47, 83095.06, 29971.90, 55145.92)]
        [InlineData(2016, 11,  2, 45248.05, 30128.91, 68593.61, 30828.14, 46603.72)]
        [InlineData(2016, 11,  3, 10066.41, 37818.49, 73011.31, 40331.48, 53979.05)]
        [InlineData(2016, 11,  4, 14805.89, 22186.89, 44790.04, 53021.94, 50407.59)]
        [InlineData(2016, 11, 30, 54125.16, 40036.66, 40313.50, 44878.95, 67124.02)]
        public async void DailyTerminalTotals(int yr, int mo, int day,
            double t1Total, double t2Total, double t3Total, double t4Total, double t5Total)
        {
            _sut.Month = new DateTime(yr, mo, day);
            await _sut.RunQuery();
            var row = _sut.DailyRows.Single(x => x.Date == _sut.Month);
            var slack = 0.019;

            var term = row.Terminals.Single(x => x.Terminal == "001");
            term.TerminalTotal.Should().BeApproximately(t1Total, slack, "POS#1");

            term = row.Terminals.Single(x => x.Terminal == "002");
            term.TerminalTotal.Should().BeApproximately(t2Total, slack, "POS#2");

            term = row.Terminals.Single(x => x.Terminal == "003");
            term.TerminalTotal.Should().BeApproximately(t3Total, slack, "POS#3");

            term = row.Terminals.Single(x => x.Terminal == "004");
            term.TerminalTotal.Should().BeApproximately(t4Total, slack, "POS#4");

            term = row.Terminals.Single(x => x.Terminal == "005");
            term.TerminalTotal.Should().BeApproximately(t5Total, slack, "POS#5");
        }
    }
}
