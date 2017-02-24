using System;
using System.Collections.Generic;
using System.Data;
using Repo2.Core.ns11.Extensions;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrMovement
    {
        public CdrMovement(IDataRecord r)
        {
            MovementID        = r.ToDecimal  ( 0);// numeric(18, 0) NOT NULL IDENTITY(1,1), 
            MovementNo        = r.ToText     ( 1);// varchar(10) NOT NULL, 
            MovementCode      = r.ToText     ( 2);// varchar(5) NOT NULL, 
            ReferenceNo       = r.ToText     ( 3);// varchar(10), 
            SourceInvoiceNo   = r.ToText     ( 4);// varchar(10), 
            SourceDRNo        = r.ToText     ( 5);// varchar(10), 
            ToDescription     = r.ToText     ( 6);// varchar(50), 
            ToAddress         = r.ToText     ( 7);// varchar(100), 
            ContactPerson     = r.ToText     ( 8);// varchar(30), 
            FromDescription   = r.ToText     ( 9);// varchar(50), 
            FromAddress       = r.ToText     (10);// varchar(100), 
            DateCreated       = r.ToDate_    (11);// smalldatetime, 
            LastModifiedBy    = r.ToText     (12);// varchar(10), 
            LastDateModified  = r.ToDate_    (13);// smalldatetime, 
            Status            = r.ToChar_    (14);// varchar(1), 
            PostedBy          = r.ToText     (15);// varchar(10), 
            PostedDate        = r.ToDate_    (16);// smalldatetime, 
            Terms             = r.ToInt      (17);// int NOT NULL DEFAULT ((0)), 
            TransactionDate   = r.ToDate_    (18);// smalldatetime, 
            FieldStyleCode1   = r.ToText     (19);// varchar(20), 
            NetTotal          = r.ToDouble_  (20);// float, 
            StatusDescription = r.ToText     (21);// varchar(10), 
            TotalQty          = r.ToDouble_  (22);// float, 
            CreatedBy         = r.ToText     (23);// varchar(10), 
            Remarks           = r.ToText     (24);// varchar(1000), 
            CustomerCode      = r.ToText     (25);// varchar(20), 
            VendorCode        = r.ToText     (26);// varchar(10), 
            BranchCode        = r.ToText     (27);// varchar(10), 
            CashDiscount      = r.ToText     (28);// varchar(20), 
            FieldStyleCode    = r.ToText     (29);// varchar(20), 
            ToBranchCode      = r.ToText     (30);// varchar(4) DEFAULT (''), 
            FrBranchCode      = r.ToText     (31);// varchar(4) DEFAULT (''), 
            sourcemovementno  = r.ToText     (32);// varchar(10) DEFAULT (''), 
            countered         = r.GetInt16   (33);// smallint NOT NULL DEFAULT ((0)), 
            Transmitted       = r.ToInt      (34);// int NOT NULL DEFAULT ((0)), 
            WithPayable       = r.GetBoolean (35);// bit NOT NULL DEFAULT ((0)), 
            WithReceivable    = r.GetBoolean (36);// bit NOT NULL DEFAULT ((0)), 
            OtherExpenses     = r.GetDouble  (37);// float DEFAULT ((0)), 
            ForexRate         = r.GetDouble  (38);// float DEFAULT ((0)), 
            ForexCurrency     = r.ToText     (39);// varchar(10) DEFAULT (''), 
            SalesmanID        = r.ToText     (40);// varchar(20), 
            RECEIVEDBY        = r.ToText     (41);// varchar(50), 
            Paid              = r.GetBoolean (42);// bit NOT NULL DEFAULT ((0))
        }

        public decimal    MovementID         { get; }  
        public string     MovementNo         { get; }  
        public string     MovementCode       { get; }  
        public string     ReferenceNo        { get; }  
        public string     SourceInvoiceNo    { get; }  
        public string     SourceDRNo         { get; }  
        public string     ToDescription      { get; }  
        public string     ToAddress          { get; }  
        public string     ContactPerson      { get; }  
        public string     FromDescription    { get; }  
        public string     FromAddress        { get; }  
        public DateTime?  DateCreated        { get; }  
        public string     LastModifiedBy     { get; }  
        public DateTime?  LastDateModified   { get; }  
        public char?      Status             { get; }  
        public string     PostedBy           { get; }  
        public DateTime?  PostedDate         { get; }  
        public int        Terms              { get; }  
        public DateTime?  TransactionDate    { get; }  
        public string     FieldStyleCode1    { get; }  
        public double?    NetTotal           { get; }  
        public string     StatusDescription  { get; }  
        public double?    TotalQty           { get; }  
        public string     CreatedBy          { get; }  
        public string     Remarks            { get; }  
        public string     CustomerCode       { get; }  
        public string     VendorCode         { get; }  
        public string     BranchCode         { get; }  
        public string     CashDiscount       { get; }  
        public string     FieldStyleCode     { get; }  
        public string     ToBranchCode       { get; }  
        public string     FrBranchCode       { get; }  
        public string     sourcemovementno   { get; }  
        public short      countered          { get; }  
        public int        Transmitted        { get; }  
        public bool       WithPayable        { get; }  
        public bool       WithReceivable     { get; }  
        public double     OtherExpenses      { get; }  
        public double     ForexRate          { get; }  
        public string     ForexCurrency      { get; }  
        public string     SalesmanID         { get; }  
        public string     RECEIVEDBY         { get; }  
        public bool       Paid               { get; }

        public string PostedByName { get; set; }

        public List<CdrMovementLine> Lines { get; set; }

        public long MovementNum => long.Parse(MovementNo);

        //public decimal? TotalQty => Lines?.Sum(x => x.qty);
    }
}
