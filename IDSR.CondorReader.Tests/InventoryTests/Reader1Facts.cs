using System.Threading;
using Autofac;
using FluentAssertions;
using IDSR.CondorReader.Core.ns11.InventoryReaders;
using IDSR.CondorReader.Lib.WPF.ComponentRegistry;
using IDSR.CondorReader.Tests.SampleCredentials;
using Xunit;

namespace IDSR.CondorReader.Tests.InventoryTests
{
    public class Reader1Facts
    {
        private IInventoryReader _sut;

        public Reader1Facts()
        {
            using (var scope = CondorReaderIoC.BeginScope())
            {
                _sut = scope.Resolve<IInventoryReader>();
            }
        }


        [Fact(DisplayName = "Read Inventory 1")]
        public async void ReadInventory1()
        {
            var ok = await _sut.Connect(TestCfgs.Local_2017Jan21(), new System.Threading.CancellationToken());
            ok.Should().BeTrue();

            var qtys = await _sut.GetCurrentSellingAreaQtys(new CancellationToken());
            qtys[19].Should().Be(46);
            qtys[20].Should().Be(36);
            qtys[51].Should().Be(47);
        }
    }
}
