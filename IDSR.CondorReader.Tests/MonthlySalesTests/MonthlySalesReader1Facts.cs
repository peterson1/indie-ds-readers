using System;
using System.Linq;
using System.Threading;
using Autofac;
using FluentAssertions;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.CondorReader.Core.ns11.SalesReaders;
using IDSR.CondorReader.Lib.WPF.ComponentRegistry;
using Xunit;

namespace IDSR.CondorReader.Tests.MonthlySalesTests
{
    public class MonthlySalesReader1Facts : IDisposable
    {
        private IMonthlySalesReader _sut;

        public MonthlySalesReader1Facts()
        {
            using (var scope = CondorReaderIoC.BeginScope())
            {
                _sut = scope.Resolve<IMonthlySalesReader>();
                //var findr = scope.Resolve<LocalDbFinder>();
                //findr.AssemblyDir = AppDomain.CurrentDomain.BaseDirectory;
            }
        }


        [Theory(DisplayName = "Monthly Sales record counts")]
        [InlineData(2016, 11, 196880)]
        [InlineData(2016, 12, 230593)]
        public async void MonthlySalesrecordcounts(int year, int month, int expectedCount)
        {
            var tkn = new CancellationToken();
            var ok  = await _sut.Connect("2017-01-24_BK", tkn);
            ok.Should().BeTrue("should be able to connect");
            var list = _sut.Query(year, month, tkn);
            list.Count().Should().Be(expectedCount);
            _sut.Disconnect();
        }


        public void Dispose() =>_sut?.Disconnect();
    }
}
