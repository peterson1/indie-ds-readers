using Autofac;
using FluentAssertions;
using IDSR.CondorReader.Lib.WPF.ComponentRegistry;
using IDSR.CondorReader.Lib.WPF.MasterDataReaders;
using Repo2.Core.ns11.DateTimeTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IDSR.CondorReader.Tests.CondorDataReader1Tests
{
    public class MonthlySalesTxnFacts
    {
        [Fact(DisplayName = "SalesTransactions GetByDates")]
        public async Task SalesTransactionsGetByDates()
        {
            CondorDataReader1 sut;

            using (var scope = CondorReaderIoC.BeginScope())
            {
                sut = scope.Resolve<CondorDataReader1>();
            }

            var recs = await sut.SalesTransactions.GetByDates(1.Oct(2016), 31.Oct(2016));
            recs.Should().HaveCount(123);
        }
    }
}
