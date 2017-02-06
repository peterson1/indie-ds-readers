using System.Threading;
using Autofac;
using FluentAssertions;
using IDSR.Common.Core.ns11.SqlTools;
using IDSR.CondorReader.Core.ns11;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Lib.WPF.ComponentRegistry;
using Xunit;

namespace IDSR.CondorReader.Tests.MonthlySalesTests
{
    [Trait("LocalDB Read", "2017-01-24_BK")]
    public class MonthlySalesReader1Facts
    {
        private IDsrDbReader<FinishedSale> _sut;

        public MonthlySalesReader1Facts()
        {
            using (var scope = CondorReaderIoC.BeginScope())
            {
                _sut = scope.Resolve<IDsrDbReader<FinishedSale>>();
                _sut.DatabaseName = "2017-01-24_BK";
            }
        }


        [Theory(DisplayName = "record counts", Skip = "outdated")]
        [InlineData(2016, 11, 196880)]
        [InlineData(2016, 12, 230593)]
        public async void RecordCounts(int year, int month, int expectedCount)
        {
            var list = await _sut.GetMonthly(year, month, new CancellationToken());
            list.Should().HaveCount(expectedCount);
        }
    }
}
