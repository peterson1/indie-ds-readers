using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.SqlDbReaders;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.MasterDataReaders;
using Repo2.Core.ns11.Extensions;

namespace IDSR.CondorReader.Lib.WPF.MasterDataReaders
{
    public class ProductsReader1 : SqlDbReaderBase
    {
        private ProductCache _cache;


        public ProductsReader1(LocalDbFinder localDbFinder, ProductCache productsCache, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
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
                Id                      = rec.ToLong     ( 0),// [ProductID]	integer NOT NULL,
                Code                    = rec.GetString  ( 1),// [ProductCode]	varchar(20) NOT NULL COLLATE NOCASE,
                Description             = rec.GetString  ( 2),// [Description]	varchar(100) NOT NULL COLLATE NOCASE,
                FieldA                  = rec.GetString  ( 3),// [FieldACode]	varchar(5) COLLATE NOCASE,
                FieldB                  = rec.GetString  ( 4),// [FieldBCode]	varchar(5) COLLATE NOCASE,
                FieldC                  = rec.GetString  ( 5),// [FieldCCode]	varchar(5) COLLATE NOCASE,
                FieldD                  = rec.GetString  ( 6),// [FieldDCode]	varchar(5) COLLATE NOCASE,
                FieldE                  = rec.GetString  ( 7),// [FieldECode]	varchar(5) COLLATE NOCASE,
                Level1                  = rec.GetString  ( 8),// [LevelField1Code]	varchar(5) COLLATE NOCASE,
                Level2                  = rec.GetString  ( 9),// [LevelField2Code]	varchar(5) COLLATE NOCASE,
                Level3                  = rec.GetString  (10),// [LevelField3Code]	varchar(5) COLLATE NOCASE,
                FieldStyle              = rec.GetString  (11),// [FieldStyleCode]	varchar(20) COLLATE NOCASE,
                ReportUoM               = rec.GetString  (12),// [reportuom]	varchar(6) NOT NULL COLLATE NOCASE DEFAULT 'PC',
                ReportQty               = rec.GetDecimal (13),// [reportqty]	numeric NOT NULL DEFAULT 1,
                Expirable               = rec.GetBoolean (14),// [expirable]	bit NOT NULL DEFAULT 0,
                WithLotNo               = rec.GetBoolean (15),// [withlotno]	bit NOT NULL DEFAULT 0,
                WithSerialNo            = rec.GetBoolean (16),// [withserialno]	bit NOT NULL DEFAULT 0,
                Trackinventory          = rec.GetBoolean (17),// [trackinventory]	bit NOT NULL DEFAULT 1,
                Inactive                = rec.GetBoolean (18),// [inactive]	bit NOT NULL DEFAULT 0,
                VendorCode              = rec.GetString  (19),// [vendorcode]	varchar(10) COLLATE NOCASE,
                MustReachForFree        = rec.GetDecimal (20),// [mustreachforfree]	numeric NOT NULL DEFAULT 0,
                SellingArea             = rec.GetDecimal (21),// [SellingArea]	numeric NOT NULL DEFAULT 0,
                StockRoom               = rec.GetDecimal (22),// [StockRoom]	numeric NOT NULL DEFAULT 0,
                Damaged                 = rec.GetDecimal (23),// [Damaged]	numeric NOT NULL DEFAULT 0,
                Layaway                 = rec.GetDecimal (24),// [Layaway]	numeric NOT NULL DEFAULT 0,
                OnOrder                 = rec.GetDecimal (25),// [OnOrder]	numeric NOT NULL DEFAULT 0,
                OnRequest               = rec.GetDecimal (26),// [OnRequest]	numeric NOT NULL DEFAULT 0,
                OnAssembly              = rec.GetDecimal (27),// [OnAssembly]	numeric NOT NULL DEFAULT 0,
                SalesOrder              = rec.GetDecimal (28),// [SalesOrder]	numeric NOT NULL DEFAULT 0,
                LastSellingDate         = rec.ToDate_    (29),// [LastSellingDate]	datetime,
                LastPurchaseDate        = rec.ToDate_    (30),// [LastPurchaseDate]	datetime,
                MinSAStock              = rec.ToDecimal_ (31),// [MinSAStock]	numeric DEFAULT 0,
                MaxSAStock              = rec.ToDecimal_ (32),// [MaxSAStock]	numeric DEFAULT 0,
                MinSRStock              = rec.ToDecimal_ (33),// [MinSRStock]	numeric DEFAULT 0,
                MaxSRStock              = rec.ToDecimal_ (34),// [MaxSRStock]	numeric DEFAULT 0,
                LastDateModified        = rec.ToDate_    (35),// [LastDateModified]	datetime DEFAULT (CURRENT_TIMESTAMP),
                OrderCycle              = rec.ToDecimal_ (36),// [OrderCycle]	numeric DEFAULT 0,
                ToDateFinishedSales     = rec.ToDecimal_ (37),// [todatefinishedsales]	numeric DEFAULT 0,
                ShareWithBranch         = rec.GetBoolean (38),// [ShareWithBranch]	bit NOT NULL DEFAULT 1,
                POSOnLookup             = rec.GetBoolean (39),// [POSOnLookup]	bit NOT NULL DEFAULT 0,
                TotalUnitCostReceived   = rec.GetDecimal (40),// [TotalUnitCostReceived]	numeric NOT NULL DEFAULT 0,
                TotalUnitQtyReceived    = rec.GetDecimal (41),// [TotalUnitQtyReceived]	numeric NOT NULL DEFAULT 0,
                UserName                = rec.ToText     (42),// [UserName]	nvarchar(40) COLLATE NOCASE,
                pVatable                = rec.ToBool_    (43),// [pVatable]	bit,
                pVatpercent             = rec.ToLong_    (44),// [pVatpercent]	integer,
                ReportUOMSR             = rec.GetString  (45),// [ReportUOMSR]	varchar(6) NOT NULL COLLATE NOCASE DEFAULT 'PC',
                ReportQtySR             = rec.GetDecimal (46),// [ReportQtySR]	numeric NOT NULL DEFAULT 1,
                Weighted                = rec.GetBoolean (47),// [Weighted]	bit NOT NULL DEFAULT 0,
                ItemDetailsCode         = rec.GetString  (48),// [ItemDetailsCode]	varchar(5) NOT NULL COLLATE NOCASE DEFAULT '',
                OpenDepartment          = rec.GetBoolean (49),// [OpenDepartment]	bit NOT NULL DEFAULT 0,
                IngredientAsDefaultCost = rec.GetBoolean (50),// [IngredientAsDefaultCost]	bit NOT NULL DEFAULT 0,
                ProductType             = rec.ToLong     (51),// [ProductType]	integer NOT NULL DEFAULT 0,
                TimeBased               = rec.GetBoolean (52),// [TimeBased]	bit NOT NULL DEFAULT 0,
                Combo                   = rec.GetBoolean (53),// [Combo]	bit NOT NULL DEFAULT 0,
                ComputedAverageCost     = rec.GetDecimal (54),// [ComputedAverageCost]	numeric NOT NULL DEFAULT 0
            };
    }
}
