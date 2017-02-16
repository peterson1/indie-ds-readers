using System;
using System.Data;
using Repo2.Core.ns11.Extensions;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrProduct
    {
        public CdrProduct(IDataRecord rec)
        {
            ProductID               = rec.ToInt      ( 0);// [ProductID]	integer NOT NULL,
            ProductCode             = rec.GetString  ( 1);// [ProductCode]	varchar(20) NOT NULL COLLATE NOCASE,
            Description             = rec.GetString  ( 2);// [Description]	varchar(100) NOT NULL COLLATE NOCASE,
            FieldACode              = rec.GetString  ( 3);// [FieldACode]	varchar(5) COLLATE NOCASE,
            FieldBCode              = rec.GetString  ( 4);// [FieldBCode]	varchar(5) COLLATE NOCASE,
            FieldCCode              = rec.GetString  ( 5);// [FieldCCode]	varchar(5) COLLATE NOCASE,
            FieldDCode              = rec.GetString  ( 6);// [FieldDCode]	varchar(5) COLLATE NOCASE,
            FieldECode              = rec.GetString  ( 7);// [FieldECode]	varchar(5) COLLATE NOCASE,
            LevelField1Code         = rec.GetString  ( 8);// [LevelField1Code]	varchar(5) COLLATE NOCASE,
            LevelField2Code         = rec.GetString  ( 9);// [LevelField2Code]	varchar(5) COLLATE NOCASE,
            LevelField3Code         = rec.GetString  (10);// [LevelField3Code]	varchar(5) COLLATE NOCASE,
            FieldStyleCode          = rec.GetString  (11);// [FieldStyleCode]	varchar(20) COLLATE NOCASE,
            ReportUoM               = rec.GetString  (12);// [reportuom]	varchar(6) NOT NULL COLLATE NOCASE DEFAULT 'PC',
            ReportQty               = rec.GetDecimal (13);// [reportqty]	numeric NOT NULL DEFAULT 1,
            Expirable               = rec.GetBoolean (14);// [expirable]	bit NOT NULL DEFAULT 0,
            WithLotNo               = rec.GetBoolean (15);// [withlotno]	bit NOT NULL DEFAULT 0,
            WithSerialNo            = rec.GetBoolean (16);// [withserialno]	bit NOT NULL DEFAULT 0,
            Trackinventory          = rec.GetBoolean (17);// [trackinventory]	bit NOT NULL DEFAULT 1,
            Inactive                = rec.GetBoolean (18);// [inactive]	bit NOT NULL DEFAULT 0,
            VendorCode              = rec.GetString  (19);// [vendorcode]	varchar(10) COLLATE NOCASE,
            MustReachForFree        = rec.GetDecimal (20);// [mustreachforfree]	numeric NOT NULL DEFAULT 0,
            SellingArea             = rec.GetDecimal (21);// [SellingArea]	numeric NOT NULL DEFAULT 0,
            StockRoom               = rec.GetDecimal (22);// [StockRoom]	numeric NOT NULL DEFAULT 0,
            Damaged                 = rec.GetDecimal (23);// [Damaged]	numeric NOT NULL DEFAULT 0,
            Layaway                 = rec.GetDecimal (24);// [Layaway]	numeric NOT NULL DEFAULT 0,
            OnOrder                 = rec.GetDecimal (25);// [OnOrder]	numeric NOT NULL DEFAULT 0,
            OnRequest               = rec.GetDecimal (26);// [OnRequest]	numeric NOT NULL DEFAULT 0,
            OnAssembly              = rec.GetDecimal (27);// [OnAssembly]	numeric NOT NULL DEFAULT 0,
            SalesOrder              = rec.GetDecimal (28);// [SalesOrder]	numeric NOT NULL DEFAULT 0,
            LastSellingDate         = rec.ToDate_    (29);// [LastSellingDate]	datetime,
            LastPurchaseDate        = rec.ToDate_    (30);// [LastPurchaseDate]	datetime,
            MinSAStock              = rec.ToDecimal_ (31);// [MinSAStock]	numeric DEFAULT 0,
            MaxSAStock              = rec.ToDecimal_ (32);// [MaxSAStock]	numeric DEFAULT 0,
            MinSRStock              = rec.ToDecimal_ (33);// [MinSRStock]	numeric DEFAULT 0,
            MaxSRStock              = rec.ToDecimal_ (34);// [MaxSRStock]	numeric DEFAULT 0,
            LastDateModified        = rec.ToDate_    (35);// [LastDateModified]	datetime DEFAULT (CURRENT_TIMESTAMP),
            OrderCycle              = rec.ToDecimal_ (36);// [OrderCycle]	numeric DEFAULT 0,
            ToDateFinishedSales     = rec.ToDecimal_ (37);// [todatefinishedsales]	numeric DEFAULT 0,
            ShareWithBranch         = rec.GetBoolean (38);// [ShareWithBranch]	bit NOT NULL DEFAULT 1,
            POSOnLookup             = rec.GetBoolean (39);// [POSOnLookup]	bit NOT NULL DEFAULT 0,
            TotalUnitCostReceived   = rec.GetDecimal (40);// [TotalUnitCostReceived]	numeric NOT NULL DEFAULT 0,
            TotalUnitQtyReceived    = rec.GetDecimal (41);// [TotalUnitQtyReceived]	numeric NOT NULL DEFAULT 0,
            UserName                = rec.ToText     (42);// [UserName]	nvarchar(40) COLLATE NOCASE,
            pVatable                = rec.ToBool_    (43);// [pVatable]	bit,
            pVatpercent             = rec.ToInt_     (44);// [pVatpercent]	integer,
            ReportUOMSR             = rec.GetString  (45);// [ReportUOMSR]	varchar(6) NOT NULL COLLATE NOCASE DEFAULT 'PC',
            ReportQtySR             = rec.GetDecimal (46);// [ReportQtySR]	numeric NOT NULL DEFAULT 1,
            Weighted                = rec.GetBoolean (47);// [Weighted]	bit NOT NULL DEFAULT 0,
            ItemDetailsCode         = rec.GetString  (48);// [ItemDetailsCode]	varchar(5) NOT NULL COLLATE NOCASE DEFAULT '',
            OpenDepartment          = rec.GetBoolean (49);// [OpenDepartment]	bit NOT NULL DEFAULT 0,
            IngredientAsDefaultCost = rec.GetBoolean (50);// [IngredientAsDefaultCost]	bit NOT NULL DEFAULT 0,
            ProductType             = rec.ToInt      (51);// [ProductType]	integer NOT NULL DEFAULT 0,
            TimeBased               = rec.GetBoolean (52);// [TimeBased]	bit NOT NULL DEFAULT 0,
            Combo                   = rec.GetBoolean (53);// [Combo]	bit NOT NULL DEFAULT 0,
            ComputedAverageCost     = rec.GetDecimal (54);// [ComputedAverageCost]	numeric NOT NULL DEFAULT 0
        }

        public int         ProductID               { get; }
        public string      ProductCode             { get; }
        public string      Description             { get; }
        public string      FieldACode              { get; }
        public string      FieldBCode              { get; }
        public string      FieldCCode              { get; }
        public string      FieldDCode              { get; }
        public string      FieldECode              { get; }
        public string      LevelField1Code         { get; }
        public string      LevelField2Code         { get; }
        public string      LevelField3Code         { get; }
        public string      FieldStyleCode          { get; }
        public string      ReportUoM               { get; }
        public decimal     ReportQty               { get; }
        public bool        Expirable               { get; }
        public bool        WithLotNo               { get; }
        public bool        WithSerialNo            { get; }
        public bool        Trackinventory          { get; }
        public bool        Inactive                { get; }
        public string      VendorCode              { get; }
        public decimal     MustReachForFree        { get; }
        public decimal     SellingArea             { get; }
        public decimal     StockRoom               { get; }
        public decimal     Damaged                 { get; }
        public decimal     Layaway                 { get; }
        public decimal     OnOrder                 { get; }
        public decimal     OnRequest               { get; }
        public decimal     OnAssembly              { get; }
        public decimal     SalesOrder              { get; }
        public DateTime?   LastSellingDate         { get; }
        public DateTime?   LastPurchaseDate        { get; }
        public decimal?    MinSAStock              { get; }
        public decimal?    MaxSAStock              { get; }
        public decimal?    MinSRStock              { get; }
        public decimal?    MaxSRStock              { get; }
        public DateTime?   LastDateModified        { get; }
        public decimal?    OrderCycle              { get; }
        public decimal?    ToDateFinishedSales     { get; }
        public bool        ShareWithBranch         { get; }
        public bool        POSOnLookup             { get; }
        public decimal     TotalUnitCostReceived   { get; }
        public decimal     TotalUnitQtyReceived    { get; }
        public string      UserName                { get; }
        public bool?       pVatable                { get; }
        public int?        pVatpercent             { get; }
        public string      ReportUOMSR             { get; }
        public decimal     ReportQtySR             { get; }
        public bool        Weighted                { get; }
        public string      ItemDetailsCode         { get; }
        public bool        OpenDepartment          { get; }
        public bool        IngredientAsDefaultCost { get; }
        public int         ProductType             { get; }
        public bool        TimeBased               { get; }
        public bool        Combo                   { get; }
        public decimal     ComputedAverageCost     { get; }

        public bool IsVatable => pVatable == true;
    }
}
