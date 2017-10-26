using System;
using System.Data;
using Repo2.Core.ns11.Extensions;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrPurchaseOrderLine
    {
        public CdrPurchaseOrderLine(IDataRecord r, bool fromServer)
        {
            if (fromServer)
                FillFromSqlServer(r);
            else
                FillFromSQLite(r);
        }


        private void FillFromSqlServer(IDataRecord r)
        {
            PurchaseOrderID   = r.GetDecimal  ( 0);//numeric NOT NULL,
            LineID            = r.GetDecimal  ( 1);//integer NOT NULL,
            ProductID         = r.IsDBNull(2) ? null : (int?)r.GetInt32     ( 2);//integer,
            VendorProductCode = r.GetString  ( 3);//varchar(20) NOT NULL COLLATE NOCASE,
            Description       = r.GetString     ( 4);//varchar(100) COLLATE NOCASE,
            UoM               = r.GetString     ( 5);//varchar(6) COLLATE NOCASE,
            UnitCost          = r.GetDecimal ( 6);//numeric NOT NULL DEFAULT 0,
            Qty               = r.GetDecimal ( 7);//numeric NOT NULL DEFAULT 0,
            NetUnitCost       = r.GetDecimal ( 8);//numeric NOT NULL DEFAULT 0,
            Extended          = r.GetDecimal ( 9);//numeric NOT NULL DEFAULT 0,
            Pack              = r.GetDecimal (10);//numeric NOT NULL DEFAULT 0,
            Remarks           = r.GetBoolean (11);//bit NOT NULL,
            Free              = r.GetBoolean (12);//bit NOT NULL DEFAULT 0,
            DiscountCode1     = r.GetString  (13);//varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            DiscountCode2     = r.GetString  (14);//varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            DiscountCode3     = r.GetString  (15);//varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            DiscAmount1       = r.GetDecimal (16);//numeric NOT NULL DEFAULT 0,
            DiscAmount2       = r.GetDecimal (17);//numeric NOT NULL DEFAULT 0,
            DiscAmount3       = r.GetDecimal (18);//numeric NOT NULL DEFAULT 0,
            Percent1          = r.GetBoolean (19);//bit NOT NULL DEFAULT 0,
            Percent2          = r.GetBoolean (20);//bit NOT NULL DEFAULT 0,
            Percent3          = r.GetBoolean (21);//bit NOT NULL DEFAULT 0,
            DiscPlus1         = r.GetBoolean (22);//bit NOT NULL DEFAULT 0,
            DiscPlus2         = r.GetBoolean (23);//bit NOT NULL DEFAULT 0,
            DiscPlus3         = r.GetBoolean (24);//bit NOT NULL DEFAULT 0,
            Style             = r.GetString     (25);//varchar(40) COLLATE NOCASE,
            StyleRow          = r.GetString     (26);//varchar(30) COLLATE NOCASE,
            StyleCol          = r.GetString     (27);//varchar(30) COLLATE NOCASE,
            VAT               = r.GetDecimal (28);//numeric DEFAULT 0,
            EWT               = r.GetDecimal (29);//numeric DEFAULT 0
        }


        public decimal   PurchaseOrderID    { get; set; }
        public decimal   LineID             { get; set; }
        public int?      ProductID          { get; set; }
        public string    VendorProductCode  { get; set; }
        public string    Description        { get; set; }
        public string    UoM                { get; set; }
        public decimal   UnitCost           { get; set; }
        public decimal   Qty                { get; set; }
        public decimal   NetUnitCost        { get; set; }
        public decimal   Extended           { get; set; }
        public decimal   Pack               { get; set; }
        public bool      Remarks            { get; set; }
        public bool      Free               { get; set; }
        public string    DiscountCode1      { get; set; }
        public string    DiscountCode2      { get; set; }
        public string    DiscountCode3      { get; set; }
        public decimal   DiscAmount1        { get; set; }
        public decimal   DiscAmount2        { get; set; }
        public decimal   DiscAmount3        { get; set; }
        public bool      Percent1           { get; set; }
        public bool      Percent2           { get; set; }
        public bool      Percent3           { get; set; }
        public bool      DiscPlus1          { get; set; }
        public bool      DiscPlus2          { get; set; }
        public bool      DiscPlus3          { get; set; }
        public string    Style              { get; set; }
        public string    StyleRow           { get; set; }
        public string    StyleCol           { get; set; }
        public decimal?  VAT                { get; set; }
        public decimal?  EWT                { get; set; }


        public CdrPurchaseOrder  Parent      { get; set; }
        public CdrProduct        Product     { get; set; }
        public decimal           LandedCost  { get; set; }

        public decimal UnitCost_x_Qty => UnitCost * Qty;



        private void FillFromSQLite(IDataRecord r)
        {
            PurchaseOrderID   = r.GetDecimal  ( 0);//numeric NOT NULL,
            LineID            = r.GetInt64  ( 1);//integer NOT NULL,
            ProductID         = r.IsDBNull(2) ? null : (int?)r.GetInt64     ( 2);//integer,
            VendorProductCode = r.GetString  ( 3);//varchar(20) NOT NULL COLLATE NOCASE,
            Description       = r.GetString     ( 4);//varchar(100) COLLATE NOCASE,
            UoM               = r.GetString     ( 5);//varchar(6) COLLATE NOCASE,
            UnitCost          = r.GetDecimal ( 6);//numeric NOT NULL DEFAULT 0,
            Qty               = r.GetDecimal ( 7);//numeric NOT NULL DEFAULT 0,
            NetUnitCost       = r.GetDecimal ( 8);//numeric NOT NULL DEFAULT 0,
            Extended          = r.GetDecimal ( 9);//numeric NOT NULL DEFAULT 0,
            Pack              = r.GetDecimal (10);//numeric NOT NULL DEFAULT 0,
            Remarks           = r.GetBoolean (11);//bit NOT NULL,
            Free              = r.GetBoolean (12);//bit NOT NULL DEFAULT 0,
            DiscountCode1     = r.GetString  (13);//varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            DiscountCode2     = r.GetString  (14);//varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            DiscountCode3     = r.GetString  (15);//varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            DiscAmount1       = r.GetDecimal (16);//numeric NOT NULL DEFAULT 0,
            DiscAmount2       = r.GetDecimal (17);//numeric NOT NULL DEFAULT 0,
            DiscAmount3       = r.GetDecimal (18);//numeric NOT NULL DEFAULT 0,
            Percent1          = r.GetBoolean (19);//bit NOT NULL DEFAULT 0,
            Percent2          = r.GetBoolean (20);//bit NOT NULL DEFAULT 0,
            Percent3          = r.GetBoolean (21);//bit NOT NULL DEFAULT 0,
            DiscPlus1         = r.GetBoolean (22);//bit NOT NULL DEFAULT 0,
            DiscPlus2         = r.GetBoolean (23);//bit NOT NULL DEFAULT 0,
            DiscPlus3         = r.GetBoolean (24);//bit NOT NULL DEFAULT 0,
            Style             = r.GetString     (25);//varchar(40) COLLATE NOCASE,
            StyleRow          = r.GetString     (26);//varchar(30) COLLATE NOCASE,
            StyleCol          = r.GetString     (27);//varchar(30) COLLATE NOCASE,
            VAT               = r.GetDecimal (28);//numeric DEFAULT 0,
            EWT               = r.GetDecimal (29);//numeric DEFAULT 0
        }
    }
}
