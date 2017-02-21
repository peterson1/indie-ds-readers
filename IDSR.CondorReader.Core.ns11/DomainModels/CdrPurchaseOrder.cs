using System;
using System.Data;
using Repo2.Core.ns11.Extensions;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrPurchaseOrder
    {
        public decimal   PurchaseOrderID      { get; }
        public string    PurchaseOrderNo      { get; }
        public string    ReferenceNo          { get; }
        public string    VendorCode           { get; }
        public string    Description          { get; }
        public string    Address              { get; }
        public string    ContactPerson        { get; }
        public string    Remarks              { get; }
        public DateTime? EDA                  { get; }
        public DateTime? CancellationDate     { get; }
        public long?     Terms                { get; }
        public short?    DeliverTo            { get; }
        public string    DeliveryDescription  { get; }
        public string    DeliveryAddress      { get; }
        public string    CreatedBy            { get; }
        public DateTime? DateCreated          { get; }
        public string    LastModifiedBy       { get; }
        public DateTime? LastDateModified     { get; }
        public string    PostedBy             { get; }
        public DateTime? PostedDate           { get; }
        public char?     Status               { get; }
        public double    SubTotal             { get; }
        public double    NetTotal             { get; }
        public long?     Transmitted          { get; }
        public string    StatusDescription    { get; }
        public string    CashDiscount         { get; }
        public string    FieldStyleCode       { get; }
        public string    BranchCode           { get; }
        public string    ToBranchCode         { get; }
        public string    FrBranchCode         { get; }
        public double?   OtherExpenses        { get; }
        public double?   ForexRate            { get; }
        public string    ForexCurrency        { get; }
        public bool      IncludeLineDiscounts { get; }
        public string    DiscountCode1        { get; }
        public string    DiscountCode2        { get; }
        public string    DiscountCode3        { get; }
        public decimal   Discount1            { get; }
        public decimal   Discount2            { get; }
        public decimal   Discount3            { get; }


        public CdrPurchaseOrder(IDataRecord r)
        {
            PurchaseOrderID      = r.ToDecimal  ( 0);//[PurchaseOrderID]	integer NOT NULL,
            PurchaseOrderNo      = r.GetString  ( 1);//[PurchaseOrderNo]	varchar(10) NOT NULL COLLATE NOCASE,
            ReferenceNo          = r.ToText     ( 2);//[ReferenceNo]	varchar(10) COLLATE NOCASE,
            VendorCode           = r.ToText     ( 3);//[VendorCode]	varchar(10) NOT NULL COLLATE NOCASE,
            Description          = r.ToText     ( 4);//[Description]	varchar(40) NOT NULL COLLATE NOCASE,
            Address              = r.ToText     ( 5);//[Address]	varchar(100) COLLATE NOCASE,
            ContactPerson        = r.ToText     ( 6);//[ContactPerson]	varchar(30) COLLATE NOCASE,
            Remarks              = r.ToText     ( 7);//[Remarks]	varchar(100) COLLATE NOCASE,
            EDA                  = r.ToDate_    ( 8);//[EDA]	datetime,
            CancellationDate     = r.ToDate_    ( 9);//[CancellationDate]	datetime,
            Terms                = r.ToLong_    (10);//[Terms]	integer NOT NULL DEFAULT 0,
            DeliverTo            = r.ToShort_   (11);//[DeliverTo]	smallint NOT NULL DEFAULT 2,
            DeliveryDescription  = r.ToText     (12);//[DeliveryDescription]	varchar(100) NOT NULL COLLATE NOCASE,
            DeliveryAddress      = r.ToText     (13);//[DeliveryAddress]	varchar(100) NOT NULL COLLATE NOCASE,
            CreatedBy            = r.ToText     (14);//[CreatedBy]	varchar(10) COLLATE NOCASE,
            DateCreated          = r.ToDate_    (15);//[DateCreated]	datetime,
            LastModifiedBy       = r.ToText     (16);//[LastModifiedBy]	varchar(10) COLLATE NOCASE,
            LastDateModified     = r.ToDate_    (17);//[LastDateModified]	datetime,
            PostedBy             = r.ToText     (18);//[PostedBy]	varchar(10) COLLATE NOCASE,
            PostedDate           = r.ToDate_    (19);//[PostedDate]	datetime,
            Status               = r.ToChar_    (20);//[Status]	varchar(1) COLLATE NOCASE,
            SubTotal             = r.GetDouble  (21);//[SubTotal]	float,
            NetTotal             = r.GetDouble  (22);//[NetTotal]	float,
            Transmitted          = r.ToLong_    (23);//[Transmitted]	integer NOT NULL DEFAULT 0,
            StatusDescription    = r.ToText     (24);//[StatusDescription]	varchar(20) COLLATE NOCASE,
            CashDiscount         = r.ToText     (25);//[CashDiscount]	varchar(20) COLLATE NOCASE,
            FieldStyleCode       = r.ToText     (26);//[FieldStyleCode]	varchar(20) COLLATE NOCASE,
            BranchCode           = r.ToText     (27);//[BranchCode]	varchar(4) COLLATE NOCASE,
            ToBranchCode         = r.ToText     (28);//[ToBranchCode]	varchar(4) COLLATE NOCASE,
            FrBranchCode         = r.ToText     (29);//[FrBranchCode]	varchar(4) COLLATE NOCASE,
            OtherExpenses        = r.ToDouble_  (30);//[OtherExpenses]	float DEFAULT 0,
            ForexRate            = r.ToDouble_  (31);//[ForexRate]	float DEFAULT 0,
            ForexCurrency        = r.ToText     (32);//[ForexCurrency]	varchar(10) COLLATE NOCASE DEFAULT '',
            IncludeLineDiscounts = r.GetBoolean (33);//[IncludeLineDiscounts]	bit NOT NULL DEFAULT 0,
            DiscountCode1        = r.ToText     (34);//[discountcode1]	varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            DiscountCode2        = r.ToText     (35);//[discountcode2]	varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            DiscountCode3        = r.ToText     (36);//[discountcode3]	varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
            Discount1            = r.GetDecimal (37);//[discount1]	numeric NOT NULL DEFAULT 0,
            Discount2            = r.GetDecimal (38);//[discount2]	numeric NOT NULL DEFAULT 0,
            Discount3            = r.GetDecimal (39);//[discount3]	numeric NOT NULL DEFAULT 0
        }
    }
}
