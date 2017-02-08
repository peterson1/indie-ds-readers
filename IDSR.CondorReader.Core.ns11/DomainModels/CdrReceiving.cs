using System;
using System.Data;
using Repo2.Core.ns11.Extensions;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrReceiving
    {
        public CdrReceiving(IDataRecord r)
        {
            Id                      = r.ToLong    ( 0);//[ReceivingID]	integer NOT NULL,
            ReceivingNo             = r.GetString ( 1);//[ReceivingNo]	varchar(10) NOT NULL COLLATE NOCASE,
            PurchaseOrderID         = r.ToDecimal_( 2);//[PurchaseOrderID]	numeric,
            PurchaseOrderNo         = r.ToText    ( 3);//[PurchaseOrderNo]	varchar(10) COLLATE NOCASE,
            ReferenceNo             = r.ToText    ( 4);//[ReferenceNo]	varchar(10) COLLATE NOCASE,
            SourceDRNo              = r.ToText    ( 5);//[SourceDRNo]	varchar(10) COLLATE NOCASE,
            SourceInvoiceNo         = r.ToText    ( 6);//[SourceInvoiceNo]	varchar(10) COLLATE NOCASE,
            VendorCode              = r.GetString ( 7);//[VendorCode]	varchar(10) NOT NULL COLLATE NOCASE,
            Description             = r.GetString ( 8);//[Description]	varchar(40) NOT NULL COLLATE NOCASE,
            Address                 = r.ToText    ( 9);//[Address]	varchar(100) COLLATE NOCASE,
            ContactPerson           = r.ToText    (10);//[ContactPerson]	varchar(30) COLLATE NOCASE,
            Remarks                 = r.ToText    (11);//[Remarks]	varchar(100) COLLATE NOCASE,
            EDA                     = r.ToDate_   (12);//[EDA]	datetime,
            CancellationDate        = r.ToDate_   (13);//[CancellationDate]	datetime,
            Terms                   = r.ToLong    (14);//[Terms]	integer NOT NULL DEFAULT 0,
            DeliverTo               = r.GetInt16  (15);//[DeliverTo]	smallint NOT NULL DEFAULT 2,
            DeliveryDescription     = r.GetString (16);//[DeliveryDescription]	varchar(100) NOT NULL COLLATE NOCASE,
            DeliveryAddress         = r.GetString (17);//[DeliveryAddress]	varchar(100) NOT NULL COLLATE NOCASE,
            CreatedBy               = r.ToText    (18);//[CreatedBy]	varchar(10) COLLATE NOCASE,
            DateCreated             = r.ToDate_   (19);//[DateCreated]	datetime,
            DateReceived            = r.ToDate_   (20);//[DateReceived]	datetime,
            ReceivedBy              = r.ToText    (21);//[ReceivedBy]	varchar(50) COLLATE NOCASE,
            LastModifiedBy          = r.ToText    (22);//[LastModifiedBy]	varchar(10) COLLATE NOCASE,
            LastDateModified        = r.ToDate_   (23);//[LastDateModified]	datetime,
            PostedBy                = r.ToText    (24);//[PostedBy]	varchar(10) COLLATE NOCASE,
            PostedDate              = r.ToDate_   (25);//[PostedDate]	datetime,
            Status                  = r.GetChar   (26);//[Status]	varchar(1) COLLATE NOCASE,
            Paid                    = r.GetBoolean(27);//[Paid]	bit NOT NULL DEFAULT 0,
            SubTotal                = r.ToDouble_ (28);//[SubTotal]	float,
            NetTotal                = r.ToDouble_ (29);//[NetTotal]	float,
            StatusDescription       = r.ToText    (30);//[StatusDescription]	varchar(20) COLLATE NOCASE,
            CashDiscount            = r.ToText    (31);//[CashDiscount]	varchar(20) COLLATE NOCASE,
            FrBranchCode            = r.ToText    (32);//[FrBranchCode]	varchar(4) COLLATE NOCASE DEFAULT '',
            FieldStyleCode          = r.ToText    (33);//[FieldStyleCode]	varchar(20) COLLATE NOCASE DEFAULT '',
            BranchCode              = r.ToText    (34);//[BranchCode]	varchar(4) COLLATE NOCASE DEFAULT '',
            OtherExpenses           = r.GetDouble (35);//[OtherExpenses]	float NOT NULL DEFAULT 0,
            ForexRate               = r.GetDouble (36);//[ForexRate]	float NOT NULL DEFAULT 0,
            ForexCurrency           = r.ToText    (37);//[ForexCurrency]	varchar(10) COLLATE NOCASE DEFAULT '',
            IncludeLineDiscounts    = r.GetBoolean(38);//[IncludeLineDiscounts]	bit NOT NULL DEFAULT 0,
            discountcode1           = r.ToText    (39);//[discountcode1]	varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            discountcode2           = r.ToText    (40);//[discountcode2]	varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            discountcode3           = r.ToText    (41);//[discountcode3]	varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            discount1               = r.GetDecimal(42);//[discount1]	numeric NOT NULL DEFAULT 0,
            discount2               = r.GetDecimal(43);//[discount2]	numeric NOT NULL DEFAULT 0,
            discount3               = r.GetDecimal(44);//[discount3]	numeric NOT NULL DEFAULT 0,
            DATACOLLECTORCONTROLNO  = r.GetDecimal(45);//[DATACOLLECTORCONTROLNO]	numeric NOT NULL DEFAULT 0,
            DiscValue1              = r.GetString (46);//[DiscValue1]	varchar(50) NOT NULL COLLATE NOCASE DEFAULT 0,
            DiscValue2              = r.GetString (47);//[DiscValue2]	varchar(50) NOT NULL COLLATE NOCASE DEFAULT 0,
            DiscValue3              = r.GetString (48);//[DiscValue3]	varchar(50) NOT NULL COLLATE NOCASE DEFAULT 0,
            RequestForPaymentStatus = r.ToText    (49);//[RequestForPaymentStatus]	char(10) COLLATE NOCASE,
            RemarksReason           = r.GetString (50);//[RemarksReason]	varchar(100) NOT NULL COLLATE NOCASE DEFAULT ''
        }

        public long        Id                      { get; }
        public string      ReceivingNo             { get; }
        public decimal?    PurchaseOrderID         { get; }
        public string      PurchaseOrderNo         { get; }
        public string      ReferenceNo             { get; }
        public string      SourceDRNo              { get; }
        public string      SourceInvoiceNo         { get; }
        public string      VendorCode              { get; }
        public string      Description             { get; }
        public string      Address                 { get; }
        public string      ContactPerson           { get; }
        public string      Remarks                 { get; }
        public DateTime?   EDA                     { get; }
        public DateTime?   CancellationDate        { get; }
        public long        Terms                   { get; }
        public short       DeliverTo               { get; }
        public string      DeliveryDescription     { get; }
        public string      DeliveryAddress         { get; }
        public string      CreatedBy               { get; }
        public DateTime?   DateCreated             { get; }
        public DateTime?   DateReceived            { get; }
        public string      ReceivedBy              { get; }
        public string      LastModifiedBy          { get; }
        public DateTime?   LastDateModified        { get; }
        public string      PostedBy                { get; }
        public DateTime?   PostedDate              { get; }
        public char?       Status                  { get; }
        public bool        Paid                    { get; }
        public double?     SubTotal                { get; }
        public double?     NetTotal                { get; }
        public string      StatusDescription       { get; }
        public string      CashDiscount            { get; }
        public string      FrBranchCode            { get; }
        public string      FieldStyleCode          { get; }
        public string      BranchCode              { get; }
        public double      OtherExpenses           { get; }
        public double      ForexRate               { get; }
        public string      ForexCurrency           { get; }
        public bool        IncludeLineDiscounts    { get; }
        public string      discountcode1           { get; }
        public string      discountcode2           { get; }
        public string      discountcode3           { get; }
        public decimal     discount1               { get; }
        public decimal     discount2               { get; }
        public decimal     discount3               { get; }
        public decimal     DATACOLLECTORCONTROLNO  { get; }
        public string      DiscValue1              { get; }
        public string      DiscValue2              { get; }
        public string      DiscValue3              { get; }
        public string      RequestForPaymentStatus { get; }
        public string      RemarksReason           { get; }
    }
}
