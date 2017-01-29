﻿using Autofac;
using IDSR.Common.Core.ns11.SqlTools;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.SqlTools;
using IDSR.CondorReader.Core.ns11.MasterDataReaders;
using IDSR.CondorReader.Core.ns11.SalesReaders;
using IDSR.CondorReader.Lib.WPF.MasterDataReaders;
using IDSR.CondorReader.Lib.WPF.SalesReaders;
using IDSR.CondorReader.Lib.WPF.Viewer;
using IDSR.CondorReader.Lib.WPF.Viewer.MainTabs;
using Repo2.Core.ns11.FileSystems;
using Repo2.SDK.WPF45.Extensions.IOCExtensions;
using Repo2.SDK.WPF45.FileSystems;

namespace IDSR.CondorReader.Lib.WPF.ComponentRegistry
{
    public class CondorReaderIoC
    {
        public static ILifetimeScope BeginScope()
        {
            var b = new ContainerBuilder();

            b.Solo<ISqlDbReader, SqlDbReader1>();
            b.Solo<ViewerMainWindowVM>();
            b.Solo<ConfigFileLoader>();
            b.Solo<DbLoaderVM1>();
            b.Solo<YearEndInventoryTabVM1>();
            b.Solo<MonthlySalesTabVM1>();
            b.Solo<ProductsCache>();
            b.Solo<ProductsReader1>();

            b.Register(c => c.Resolve<ConfigFileLoader>().GetLastLoaded());

            b.Multi<LocalDbFinder>();
            b.Multi<IFileSystemAccesor, FileSystemAccesor1>();
            b.Multi<IMonthlySalesReader, MonthlySalesReader1>();

            var containr = b.Build();
            return containr.BeginLifetimeScope();
        }
    }
}
