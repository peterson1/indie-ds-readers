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
        [InlineData(2016, 11, 1, 17144.29, 60087.47, 83095.06, 29971.9, 55145.92)]
        public async void DailyTerminalTotals(int yr, int mo, int day,
            double t1Total, double t2Total, double t3Total, double t4Total, double t5Total)
        {
            _sut.Date = new DateTime(yr, mo, day);
            await _sut.RunQuery();
            var row = _sut.DailyRows.Single(x => x.Date == _sut.Date);

            var term = row.Terminals.Single(x => x.Terminal == "001");
            term.TerminalTotal.Should().BeApproximately(t1Total, 0.01);

            term = row.Terminals.Single(x => x.Terminal == "002");
            term.TerminalTotal.Should().BeApproximately(t2Total, 0.01);

            term = row.Terminals.Single(x => x.Terminal == "003");
            term.TerminalTotal.Should().BeApproximately(t3Total, 0.01);

            term = row.Terminals.Single(x => x.Terminal == "004");
            term.TerminalTotal.Should().BeApproximately(t4Total, 0.01);

            term = row.Terminals.Single(x => x.Terminal == "005");
            term.TerminalTotal.Should().BeApproximately(t5Total, 0.01);
        }
    }
}
