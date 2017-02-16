using System;
using System.Data;
using Repo2.Core.ns11.Extensions;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrMovementLine
    {
        public CdrMovementLine(IDataRecord r)
        {
            MovementID     = r.GetDecimal ( 0);// numeric(18, 0) NOT NULL, 
            LineID         = r.GetDecimal ( 1);// decimal(18, 0) NOT NULL IDENTITY(1,1),
            ProductID      = r.ToInt_     ( 2);// int, 
            ProductCode    = r.ToText     ( 3);// varchar(20) NOT NULL, 
            Description    = r.ToText     ( 4);// varchar(100), 
            UOM            = r.ToText     ( 5);// varchar(6) NOT NULL, 
            unitcost       = r.GetDecimal ( 6);// decimal(18, 4) NOT NULL DEFAULT ((0)),
            qty            = r.GetDecimal ( 7);// decimal(18, 4) NOT NULL DEFAULT ((0)),
            netunitcost    = r.GetDecimal ( 8);// decimal(18, 4) NOT NULL DEFAULT ((0)),
            extended       = r.GetDecimal ( 9);// decimal(18, 4) NOT NULL DEFAULT ((0)),
            pack           = r.GetDecimal (10);// decimal(18, 4) NOT NULL DEFAULT ((0)),
            free           = r.GetBoolean (11);// bit NOT NULL DEFAULT ((0)), 
            DiscountCode1  = r.ToText     (12);// varchar(4) NOT NULL DEFAULT (''), 
            DiscountCode2  = r.ToText     (13);// varchar(4) NOT NULL DEFAULT (''), 
            DiscountCode3  = r.ToText     (14);// varchar(4) NOT NULL DEFAULT (''), 
            DiscAmount1    = r.GetDecimal (15);// decimal(18, 4) NOT NULL DEFAULT ((0)),
            DiscAmount2    = r.GetDecimal (16);// decimal(18, 4) NOT NULL DEFAULT ((0)),
            DiscAmount3    = r.GetDecimal (17);// decimal(18, 4) NOT NULL DEFAULT ((0)),
            Percent1       = r.GetBoolean (18);// bit NOT NULL DEFAULT ((0)), 
            Percent2       = r.GetBoolean (19);// bit NOT NULL DEFAULT ((0)), 
            Percent3       = r.GetBoolean (20);// bit NOT NULL DEFAULT ((0)), 
            DiscPlus1      = r.GetBoolean (21);// bit DEFAULT ((0)), 
            DiscPlus2      = r.GetBoolean (22);// bit NOT NULL DEFAULT ((0)), 
            DiscPlus3      = r.GetBoolean (23);// bit NOT NULL DEFAULT ((0)), 
            style          = r.ToText     (24);// varchar(40), 
            srp            = r.GetDecimal (25);// decimal(18, 4) NOT NULL DEFAULT ((0)),
            srpuom         = r.ToText     (26);// varchar(6) NOT NULL DEFAULT (''), 
            LotNo          = r.ToText     (27);// varchar(20), 
            ExpirationDate = r.ToDate_    (28);// datetime, 
            WithLotNo      = r.GetBoolean (29);// bit NOT NULL DEFAULT ((0)), 
            Expirable      = r.GetBoolean (30);// bit NOT NULL DEFAULT ((0)), 
            WithSerialNo   = r.GetBoolean (31);// bit NOT NULL DEFAULT ((0)), 
            StyleRow       = r.ToText     (32);// varchar(30), 
            StyleCol       = r.ToText     (33);// varchar(30), 
            Barcode        = r.ToText     (34);// varchar(20), 
            SerialNo       = r.ToText     (35);// varchar(200), 
            Remarks        = r.ToText     (36);// varchar(200) NOT NULL DEFAULT ('')
        }

        public decimal     MovementID      { get; }// numeric(18, 0) NOT NULL, 
        public decimal     LineID          { get; }// decimal(18, 0) NOT NULL IDENTITY(1,1),
        public int?        ProductID       { get; }// int, 
        public string      ProductCode     { get; }// varchar(20) NOT NULL, 
        public string      Description     { get; }// varchar(100), 
        public string      UOM             { get; }// varchar(6) NOT NULL, 
        public decimal     unitcost        { get; }// decimal(18, 4) NOT NULL DEFAULT ((0)),
        public decimal     qty             { get; }// decimal(18, 4) NOT NULL DEFAULT ((0)),
        public decimal     netunitcost     { get; }// decimal(18, 4) NOT NULL DEFAULT ((0)),
        public decimal     extended        { get; }// decimal(18, 4) NOT NULL DEFAULT ((0)),
        public decimal     pack            { get; }// decimal(18, 4) NOT NULL DEFAULT ((0)),
        public bool        free            { get; }// bit NOT NULL DEFAULT ((0)), 
        public string      DiscountCode1   { get; }// varchar(4) NOT NULL DEFAULT (''), 
        public string      DiscountCode2   { get; }// varchar(4) NOT NULL DEFAULT (''), 
        public string      DiscountCode3   { get; }// varchar(4) NOT NULL DEFAULT (''), 
        public decimal     DiscAmount1     { get; }// decimal(18, 4) NOT NULL DEFAULT ((0)),
        public decimal     DiscAmount2     { get; }// decimal(18, 4) NOT NULL DEFAULT ((0)),
        public decimal     DiscAmount3     { get; }// decimal(18, 4) NOT NULL DEFAULT ((0)),
        public bool        Percent1        { get; }// bit NOT NULL DEFAULT ((0)), 
        public bool        Percent2        { get; }// bit NOT NULL DEFAULT ((0)), 
        public bool        Percent3        { get; }// bit NOT NULL DEFAULT ((0)), 
        public bool        DiscPlus1       { get; }// bit DEFAULT ((0)), 
        public bool        DiscPlus2       { get; }// bit NOT NULL DEFAULT ((0)), 
        public bool        DiscPlus3       { get; }// bit NOT NULL DEFAULT ((0)), 
        public string      style           { get; }// varchar(40), 
        public decimal     srp             { get; }// decimal(18, 4) NOT NULL DEFAULT ((0)),
        public string      srpuom          { get; }// varchar(6) NOT NULL DEFAULT (''), 
        public string      LotNo           { get; }// varchar(20), 
        public DateTime?   ExpirationDate  { get; }// datetime, 
        public bool        WithLotNo       { get; }// bit NOT NULL DEFAULT ((0)), 
        public bool        Expirable       { get; }// bit NOT NULL DEFAULT ((0)), 
        public bool        WithSerialNo    { get; }// bit NOT NULL DEFAULT ((0)), 
        public string      StyleRow        { get; }// varchar(30), 
        public string      StyleCol        { get; }// varchar(30), 
        public string      Barcode         { get; }// varchar(20), 
        public string      SerialNo        { get; }// varchar(200), 
        public string      Remarks         { get; }// varchar(200) NOT NULL DEFAULT ('')

        public CdrMovement Parent { get; set; }
    }
}
