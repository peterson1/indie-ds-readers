using Autofac;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Core.ns11.SqlTools;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.MasterDataReaders;
using IDSR.CondorReader.Core.ns11.TransactionReaders;
using IDSR.CondorReader.Lib.WPF.MasterDataReaders;
using IDSR.CondorReader.Lib.WPF.TransactionReaders;
using IDSR.CondorReader.Lib.WPF.Viewer;
using IDSR.CondorReader.Lib.WPF.Viewer.MainTabs;
using Repo2.Core.ns11.FileSystems;
using Repo2.SDK.WPF45.Configuration;
using Repo2.SDK.WPF45.Extensions.IOCExtensions;
using Repo2.SDK.WPF45.FileSystems;

namespace IDSR.CondorReader.Lib.WPF.ComponentRegistry
{
    public class CondorReaderIoC
    {
        public static ILifetimeScope BeginScope()
        {
            var b = new ContainerBuilder();

            RegisterComponentsTo(ref b);

            b.Register(c => c.Resolve<BesideExeCfgLoader<DsrConfiguration1>>()
                                .Load(DsrConfiguration1.CreateDefault()));

            var containr = b.Build();
            return containr.BeginLifetimeScope();
        }


        public static void RegisterComponentsTo(ref ContainerBuilder b)
        {
            //b.Solo<ISqlDbReader, SqlDbReader1>();
            b.Solo<ViewerMainWindowVM>();
            b.Solo<BesideExeCfgLoader<DsrConfiguration1>>();
            b.Solo<DbLoaderVM1>();
            b.Solo<YearEndInventoryTabVM1>();
            b.Solo<MonthlySalesTabVM1>();
            b.Solo<MonthlyPurchasesTabVM1>();
            b.Solo<ProductCache>();
            b.Solo<ProductsReader1>();
            b.Solo<VendorCache>();
            b.Solo<VendorsReader1>();

            b.Multi<LocalDbFinder>();
            b.Multi<IFileSystemAccesor, FileSystemAccesor1>();
            b.Multi<IDsrDbReader<FinishedSale>, FinishedSalesReader1>();
            b.Multi<IDsrDbReader<CdrPurchaseOrderLine>, PurchaseOrdersReader1>();
            b.Multi<IDsrDbReader<CdrReceivingLine>, ReceivingReader1>();
            b.Multi<IMovementsReader, MovementsReader1>();
            b.Multi<IPurchaseOrdersReader, PurchaseOrdersReader2>();
            b.Multi<IReceivingsReader, ReceivingsReader2>();
            b.Multi<CondorDataReader1>();
        }
    }
}
