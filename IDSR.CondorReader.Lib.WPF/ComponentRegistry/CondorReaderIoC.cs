using Autofac;
using IDSR.Common.Core.ns11.SqlTools;
using IDSR.Common.Lib.WPF.SqlTools;
using IDSR.CondorReader.Core.ns11.InventoryReaders;
using IDSR.CondorReader.Lib.WPF.Viewer;
using Repo2.SDK.WPF45.Extensions.IOCExtensions;

namespace IDSR.CondorReader.Lib.WPF.ComponentRegistry
{
    public class CondorReaderIoC
    {
        public static ILifetimeScope BeginScope()
        {
            var b = new ContainerBuilder();

            b.Solo<IInventoryReader, InventoryReader1>();
            b.Solo<ISqlDbReader, SqlDbReader1>();
            b.Solo<ViewerMainWindowVM>();
            b.Solo<DbLoaderVM>();

            var containr = b.Build();
            return containr.BeginLifetimeScope();
        }
    }
}
