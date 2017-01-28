using Autofac;
using FluentAssertions;
using IDSR.CondorReader.Core.ns11.SalesReaders;
using IDSR.CondorReader.Lib.WPF.ComponentRegistry;
using Xunit;

namespace IDSR.CondorReader.Tests.MonthlySalesTests
{
    public class MonthlySalesReader1Facts
    {
        private IMonthlySalesReader _sut;

        public MonthlySalesReader1Facts()
        {
            using (var scope = CondorReaderIoC.BeginScope())
            {
                _sut = scope.Resolve<IMonthlySalesReader>();
                _sut.DatabaseName = "2017-01-24_BK";
            }
        }


        [Theory(DisplayName = "using DataReader")]
        [InlineData(2016, 11, 196880)]
        [InlineData(2016, 12, 230593)]
        public void UsingDataReader(int year, int month, int expectedCount)
        {
            var count = 0;
            using (var readr = _sut.ReadFinishedSales(year, month))
            {
                foreach (var record in readr)
                {
                    count++;
                }
            }
            count.Should().Be(expectedCount);
        }
    }
}
