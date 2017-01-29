﻿using System.Threading;
using Autofac;
using FluentAssertions;
using IDSR.CondorReader.Core.ns11.SalesReaders;
using IDSR.CondorReader.Lib.WPF.ComponentRegistry;
using Xunit;

namespace IDSR.CondorReader.Tests.MonthlySalesTests
{
    [Trait("LocalDB Read", "2017-01-24_BK")]
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


        [Theory(DisplayName = "record counts")]
        [InlineData(2016, 11, 196880)]
        [InlineData(2016, 12, 230593)]
        public async void RecordCounts(int year, int month, int expectedCount)
        {
            var list = await _sut.GetFinishedSales(year, month, new CancellationToken());
            list.Should().HaveCount(expectedCount);
        }
    }
}
