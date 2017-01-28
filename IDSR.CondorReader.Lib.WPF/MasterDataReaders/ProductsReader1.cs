using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.LocalDbReaders;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.MasterDataReaders;

namespace IDSR.CondorReader.Lib.WPF.MasterDataReaders
{
    public class ProductsReader1 : LocalDbReaderBase
    {
        private ProductsCache _cache;


        public ProductsReader1(LocalDbFinder localDbFinder, ProductsCache productsCache) : base(localDbFinder)
        {
            _cache = productsCache;
        }


        public async Task CacheInMemory(CancellationToken cancelTkn)
        {
            using (var readr = await ConnectAndReadAsync(SQL_QUERY, cancelTkn))
            {
                _cache.Clear();
                foreach (IDataRecord rec in readr)
                {
                    _cache.Add(ToProduct(rec));
                }
            }
        }


        const string SQL_QUERY = "SELECT * FROM Products";

        private Product ToProduct(IDataRecord rec)
            => new Product
            {
                Id             = rec.GetInt64   ( 0),// [ProductID]	integer NOT NULL,
                Code           = rec.GetString  ( 1),// [ProductCode]	varchar(20) NOT NULL COLLATE NOCASE,
                Description    = rec.GetString  ( 2),// [Description]	varchar(100) NOT NULL COLLATE NOCASE,
                FieldA         = rec.GetString  ( 3),// [FieldACode]	varchar(5) COLLATE NOCASE,
                FieldB         = rec.GetString  ( 4),// [FieldBCode]	varchar(5) COLLATE NOCASE,
                FieldC         = rec.GetString  ( 5),// [FieldCCode]	varchar(5) COLLATE NOCASE,
                FieldD         = rec.GetString  ( 6),// [FieldDCode]	varchar(5) COLLATE NOCASE,
                FieldE         = rec.GetString  ( 7),// [FieldECode]	varchar(5) COLLATE NOCASE,
                Level1         = rec.GetString  ( 8),// [LevelField1Code]	varchar(5) COLLATE NOCASE,
                Level2         = rec.GetString  ( 9),// [LevelField2Code]	varchar(5) COLLATE NOCASE,
                Level3         = rec.GetString  (10),// [LevelField3Code]	varchar(5) COLLATE NOCASE,
                FieldStyle     = rec.GetString  (11),// [FieldStyleCode]	varchar(20) COLLATE NOCASE,
                ReportUoM      = rec.GetString  (12),// [reportuom]	varchar(6) NOT NULL COLLATE NOCASE DEFAULT 'PC',
                ReportQty      = rec.GetDecimal (13),// [reportqty]	numeric NOT NULL DEFAULT 1,
                Expirable      = rec.GetBoolean (14),// [expirable]	bit NOT NULL DEFAULT 0,
                WithLotNo      = rec.GetBoolean (15),// [withlotno]	bit NOT NULL DEFAULT 0,
                WithSerialNo   = rec.GetBoolean (16),// [withserialno]	bit NOT NULL DEFAULT 0,
                Trackinventory = rec.GetBoolean (17),// [trackinventory]	bit NOT NULL DEFAULT 1,
                Inactive       = rec.GetBoolean (18),// [inactive]	bit NOT NULL DEFAULT 0,
                // [vendorcode]	varchar(10) COLLATE NOCASE,
                // [mustreachforfree]	numeric NOT NULL DEFAULT 0,
                // [SellingArea]	numeric NOT NULL DEFAULT 0,
                // [StockRoom]	numeric NOT NULL DEFAULT 0,
                // [Damaged]	numeric NOT NULL DEFAULT 0,
                // [Layaway]	numeric NOT NULL DEFAULT 0,
                // [OnOrder]	numeric NOT NULL DEFAULT 0,
                // [OnRequest]	numeric NOT NULL DEFAULT 0,
                // [OnAssembly]	numeric NOT NULL DEFAULT 0,
                // [SalesOrder]	numeric NOT NULL DEFAULT 0,
                // [LastSellingDate]	datetime,
                // [LastPurchaseDate]	datetime,
                // [MinSAStock]	numeric DEFAULT 0,
                // [MaxSAStock]	numeric DEFAULT 0,
                // [MinSRStock]	numeric DEFAULT 0,
                // [MaxSRStock]	numeric DEFAULT 0,
                // [LastDateModified]	datetime DEFAULT (CURRENT_TIMESTAMP),
                // [OrderCycle]	numeric DEFAULT 0,
                // [todatefinishedsales]	numeric DEFAULT 0,
                // [ShareWithBranch]	bit NOT NULL DEFAULT 1,
                // [POSOnLookup]	bit NOT NULL DEFAULT 0,
                // [TotalUnitCostReceived]	numeric NOT NULL DEFAULT 0,
                // [TotalUnitQtyReceived]	numeric NOT NULL DEFAULT 0,
                // [UserName]	nvarchar(40) COLLATE NOCASE,
                // [pVatable]	bit,
                // [pVatpercent]	integer,
                // [ReportUOMSR]	varchar(6) NOT NULL COLLATE NOCASE DEFAULT 'PC',
                // [ReportQtySR]	numeric NOT NULL DEFAULT 1,
                // [Weighted]	bit NOT NULL DEFAULT 0,
                // [ItemDetailsCode]	varchar(5) NOT NULL COLLATE NOCASE DEFAULT '',
                // [OpenDepartment]	bit NOT NULL DEFAULT 0,
                // [IngredientAsDefaultCost]	bit NOT NULL DEFAULT 0,
                // [ProductType]	integer NOT NULL DEFAULT 0,
                // [TimeBased]	bit NOT NULL DEFAULT 0,
                // [Combo]	bit NOT NULL DEFAULT 0,
                // [ComputedAverageCost]	numeric NOT NULL DEFAULT 0
            };
    }
}
