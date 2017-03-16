using System;
using System.Data;
using Repo2.Core.ns11.Extensions;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrReceivingLine
    {
        public CdrReceivingLine(IDataRecord r)
        {
            ReceivingID = Convert.ToInt64(r.GetDecimal(0)); //[ReceivingID]	numeric NOT NULL,
            LineId            = r.ToLong     ( 1);//[LineID]	integer NOT NULL,
            ProductID         = r.ToLong_    ( 2);//[ProductID]	integer,
            ProductCode       = r.ToText     ( 3); //[PRODUCTCODE]	varchar(20) COLLATE NOCASE,
            VendorProductCode = r.GetString  ( 4);//[VendorProductCode]	varchar(20) NOT NULL COLLATE NOCASE,
            Description       = r.ToText     ( 5);//[Description]	varchar(100) COLLATE NOCASE,
            UoM               = r.ToText     ( 6);//[UOM]	varchar(6) COLLATE NOCASE,
            UnitCost          = r.GetDecimal ( 7);//[unitcost]	numeric NOT NULL DEFAULT 0,
            qty               = r.GetDecimal ( 8);//[qty]	numeric NOT NULL DEFAULT 0,
            netunitcost       = r.GetDecimal ( 9);//[netunitcost]	numeric NOT NULL DEFAULT 0,
            extended          = r.GetDecimal (10);//[extended]	numeric NOT NULL DEFAULT 0,
            pack              = r.GetDecimal (11);//[pack]	numeric NOT NULL DEFAULT 0,
            totalqtypurchased = r.ToDecimal_ (12);//[totalqtypurchased]	numeric,
            remarks           = r.GetBoolean (13);//[remarks]	bit NOT NULL,
            free              = r.GetBoolean (14);//[free]	bit NOT NULL,
            lotno             = r.ToText     (15);//[lotno]	varchar(20) COLLATE NOCASE,
            ExpirationDate    = r.ToDate_    (16);//[ExpirationDate]	datetime,
            DiscountCode1     = r.GetString  (17);//[DiscountCode1]	varchar(4) NOT NULL COLLATE NOCASE,
            DiscountCode2     = r.GetString  (18);//[DiscountCode2]	varchar(4) NOT NULL COLLATE NOCASE,
            DiscountCode3     = r.GetString  (19);//[DiscountCode3]	varchar(4) NOT NULL COLLATE NOCASE,
            DiscAmount1       = r.GetDecimal (20);//[DiscAmount1]	numeric NOT NULL DEFAULT 0,
            DiscAmount2       = r.GetDecimal (21);//[DiscAmount2]	numeric NOT NULL DEFAULT 0,
            DiscAmount3       = r.GetDecimal (22);//[DiscAmount3]	numeric NOT NULL DEFAULT 0,
            DiscValue1        = r.GetString  (23);//[DiscValue1]	varchar(50) NOT NULL COLLATE NOCASE DEFAULT 0,
            DiscValue2        = r.GetString  (24);//[DiscValue2]	varchar(50) NOT NULL COLLATE NOCASE DEFAULT 0,
            DiscValue3        = r.GetString  (25);//[DiscValue3]	varchar(50) NOT NULL COLLATE NOCASE DEFAULT 0,
            Percent1          = r.GetBoolean (26);//[Percent1]	bit NOT NULL DEFAULT 0,
            Percent2          = r.GetBoolean (27);//[Percent2]	bit NOT NULL DEFAULT 0,
            Percent3          = r.GetBoolean (28);//[Percent3]	bit NOT NULL DEFAULT 0,
            DiscPlus1         = r.GetBoolean (29);//[DiscPlus1]	bit NOT NULL DEFAULT 0,
            DiscPlus2         = r.GetBoolean (30);//[DiscPlus2]	bit NOT NULL DEFAULT 0,
            DiscPlus3         = r.GetBoolean (31);//[DiscPlus3]	bit NOT NULL DEFAULT 0,
            style             = r.ToText     (32);//[style]	varchar(40) COLLATE NOCASE,
            WithLotNo         = r.GetBoolean (33);//[WithLotNo]	bit NOT NULL DEFAULT 0,
            Expirable         = r.GetBoolean (34);//[Expirable]	bit NOT NULL DEFAULT 0,
            StyleRow          = r.ToText     (35);//[StyleRow]	varchar(30) COLLATE NOCASE,
            StyleCol          = r.ToText     (36);//[StyleCol]	varchar(30) COLLATE NOCASE,
            Barcode           = r.ToText     (37);//[Barcode]	varchar(20) COLLATE NOCASE,
            VAT               = r.ToDecimal_ (38);//[VAT]	numeric DEFAULT 0,
            EWT               = r.ToDecimal_ (39);//[EWT]	numeric DEFAULT 0,
            AverageNetCost    = r.ToDecimal_ (40);//[AverageNetCost]	numeric DEFAULT 0,
            RemarksReason     = r.GetString  (41);//[RemarksReason]	varchar(100) NOT NULL COLLATE NOCASE DEFAULT ''
        }

        public long       ReceivingID        { get; }
        public long       LineId             { get; }
        public long?      ProductID          { get; }
        public string     ProductCode        { get; }
        public string     VendorProductCode  { get; }
        public string     Description        { get; }
        public string     UoM                { get; }
        public decimal    UnitCost           { get; }
        public decimal    qty                { get; }
        public decimal    netunitcost        { get; }//ignorable
        public decimal    extended           { get; }
        public decimal    pack               { get; }
        public decimal?   totalqtypurchased  { get; }
        public bool       remarks            { get; }
        public bool       free               { get; }
        public string     lotno              { get; }
        public DateTime?  ExpirationDate     { get; }
        public string     DiscountCode1      { get; }
        public string     DiscountCode2      { get; }
        public string     DiscountCode3      { get; }
        public decimal    DiscAmount1        { get; }
        public decimal    DiscAmount2        { get; }
        public decimal    DiscAmount3        { get; }
        public string     DiscValue1         { get; }
        public string     DiscValue2         { get; }
        public string     DiscValue3         { get; }
        public bool       Percent1           { get; }
        public bool       Percent2           { get; }
        public bool       Percent3           { get; }
        public bool       DiscPlus1          { get; }
        public bool       DiscPlus2          { get; }
        public bool       DiscPlus3          { get; }
        public string     style              { get; }
        public bool       WithLotNo          { get; }
        public bool       Expirable          { get; }
        public string     StyleRow           { get; }
        public string     StyleCol           { get; }
        public string     Barcode            { get; }
        public decimal?   VAT                { get; }
        public decimal?   EWT                { get; }
        public decimal?   AverageNetCost     { get; }
        public string     RemarksReason      { get; }


        public CdrReceiving Parent   { get; set; }
        public CdrProduct   Product  { get; set; }
    }
}
