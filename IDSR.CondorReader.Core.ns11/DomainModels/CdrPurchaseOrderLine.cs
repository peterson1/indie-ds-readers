using System.Data;
using Repo2.Core.ns11.Extensions;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrPurchaseOrderLine
    {
        public decimal   PurchaseOrderID    { get; }
        public decimal   LineID             { get; }
        public int?      ProductID          { get; }
        public string    VendorProductCode  { get; }
        public string    Description        { get; }
        public string    UoM                { get; }
        public decimal   UnitCost           { get; }
        public decimal   Qty                { get; }
        public decimal   NetUnitCost        { get; }
        public decimal   Extended           { get; }
        public decimal   Pack               { get; }
        public bool      Remarks            { get; }
        public bool      Free               { get; }
        public string    DiscountCode1      { get; }
        public string    DiscountCode2      { get; }
        public string    DiscountCode3      { get; }
        public decimal   DiscAmount1        { get; }
        public decimal   DiscAmount2        { get; }
        public decimal   DiscAmount3        { get; }
        public bool      Percent1           { get; }
        public bool      Percent2           { get; }
        public bool      Percent3           { get; }
        public bool      DiscPlus1          { get; }
        public bool      DiscPlus2          { get; }
        public bool      DiscPlus3          { get; }
        public string    Style              { get; }
        public string    StyleRow           { get; }
        public string    StyleCol           { get; }
        public decimal?  VAT                { get; }
        public decimal?  EWT                { get; }


        public CdrPurchaseOrder  Parent      { get; set; }
        public decimal           LandedCost  { get; set; }

        public decimal UnitCost_x_Qty => UnitCost * Qty;



        public CdrPurchaseOrderLine(IDataRecord r)
        {
            PurchaseOrderID   = r.ToDecimal  ( 0);//[PurchaseOrderID]	numeric NOT NULL,
            LineID            = r.ToDecimal  ( 1);//[LineID]	integer NOT NULL,
            ProductID         = r.ToInt_     ( 2);//[ProductID]	integer,
            VendorProductCode = r.GetString  ( 3);//[VendorProductCode]	varchar(20) NOT NULL COLLATE NOCASE,
            Description       = r.ToText     ( 4);//[Description]	varchar(100) COLLATE NOCASE,
            UoM               = r.ToText     ( 5);//[UOM]	varchar(6) COLLATE NOCASE,
            UnitCost          = r.GetDecimal ( 6);//[unitcost]	numeric NOT NULL DEFAULT 0,
            Qty               = r.GetDecimal ( 7);//[qty]	numeric NOT NULL DEFAULT 0,
            NetUnitCost       = r.GetDecimal ( 8);//[netunitcost]	numeric NOT NULL DEFAULT 0,
            Extended          = r.GetDecimal ( 9);//[extended]	numeric NOT NULL DEFAULT 0,
            Pack              = r.GetDecimal (10);//[pack]	numeric NOT NULL DEFAULT 0,
            Remarks           = r.GetBoolean (11);//[remarks]	bit NOT NULL,
            Free              = r.GetBoolean (12);//[free]	bit NOT NULL DEFAULT 0,
            DiscountCode1     = r.GetString  (13);//[DiscountCode1]	varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            DiscountCode2     = r.GetString  (14);//[DiscountCode2]	varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            DiscountCode3     = r.GetString  (15);//[DiscountCode3]	varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            DiscAmount1       = r.GetDecimal (16);//[DiscAmount1]	numeric NOT NULL DEFAULT 0,
            DiscAmount2       = r.GetDecimal (17);//[DiscAmount2]	numeric NOT NULL DEFAULT 0,
            DiscAmount3       = r.GetDecimal (18);//[DiscAmount3]	numeric NOT NULL DEFAULT 0,
            Percent1          = r.GetBoolean (19);//[Percent1]	bit NOT NULL DEFAULT 0,
            Percent2          = r.GetBoolean (20);//[Percent2]	bit NOT NULL DEFAULT 0,
            Percent3          = r.GetBoolean (21);//[Percent3]	bit NOT NULL DEFAULT 0,
            DiscPlus1         = r.GetBoolean (22);//[DiscPlus1]	bit NOT NULL DEFAULT 0,
            DiscPlus2         = r.GetBoolean (23);//[DiscPlus2]	bit NOT NULL DEFAULT 0,
            DiscPlus3         = r.GetBoolean (24);//[DiscPlus3]	bit NOT NULL DEFAULT 0,
            Style             = r.ToText     (25);//[style]	varchar(40) COLLATE NOCASE,
            StyleRow          = r.ToText     (26);//[stylerow]	varchar(30) COLLATE NOCASE,
            StyleCol          = r.ToText     (27);//[stylecol]	varchar(30) COLLATE NOCASE,
            VAT               = r.ToDecimal_ (28);//[VAT]	numeric DEFAULT 0,
            EWT               = r.ToDecimal_ (29);//[EWT]	numeric DEFAULT 0
        }
    }
}
