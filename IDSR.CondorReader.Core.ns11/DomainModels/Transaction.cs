using System;
using System.Data;
using Repo2.Core.ns11.Extensions;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class Transaction
    {
        public Transaction()
        {
        }

        public Transaction(IDataRecord r)
        {
            var a = new Transaction
            {
                TransactionNo = r.GetInt64(0),//[TransactionNo]	integer DEFAULT 0,
                CustomerCode = r.ToText(1),//[CustomerCode]	varchar(20) COLLATE NOCASE DEFAULT '',
                Description = r.ToText(2),//[Description]	varchar(40) COLLATE NOCASE DEFAULT '',
                SubTotal = r.ToDecimal_(3),//[SubTotal]	numeric DEFAULT 0,
                GrandTotal = r.ToDecimal_(4),//[GrandTotal]	numeric DEFAULT 0,
                DownPayments = r.ToDecimal_(5),//[DownPayments]	numeric DEFAULT 0,
                Discount = r.ToDecimal_(6),//[Discount]	numeric DEFAULT 0,
                AmountDiscounted = r.ToDecimal_(7),//[AmountDiscounted]	numeric DEFAULT 0,
                Allowance = r.ToDecimal_(8),//[Allowance]	numeric DEFAULT 0,
                ChargeDiscount = r.ToDecimal_(9),//[ChargeDiscount]	numeric DEFAULT 0,
                ChargeAllowance = r.ToDecimal_(10),//[ChargeAllowance]	numeric DEFAULT 0,
                ChargeAmountDiscounted = r.ToDecimal_(11),//[ChargeAmountDiscounted]	numeric DEFAULT 0,
                Shift = r.GetInt64(12),//[Shift]	integer NOT NULL DEFAULT 0,
                UserID = r.GetString(13),//[UserID]	varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
                TerminalNo = r.GetString(14),//[TerminalNo]	varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
                BranchCode = r.GetString(15),//[BranchCode]	varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
                LogDate = r.GetDateTime(16),//[LogDate]	datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
                DateTime = r.ToDate_(17),//[DateTime]	datetime DEFAULT (CURRENT_TIMESTAMP),
                Voided = r.GetBoolean(18),//[Voided]	bit NOT NULL DEFAULT 0,
                //[VoidRemarks]	varchar(40) COLLATE NOCASE DEFAULT '',
                //[BaggerID]	numeric NOT NULL DEFAULT 0,
                //[Senior]	bit NOT NULL DEFAULT 0,
                //[ReturnSubtotal]	numeric DEFAULT 0,
                //[SalesmanID]	numeric DEFAULT 0,
                //[TimeOfFirstScan]	datetime,
                //[TimeOfLastScan]	datetime,
                //[TimeCashedOut]	datetime,
                //[TimeBaggingStarted]	datetime,
                //[TimeBaggingFinished]	datetime,
                //[Layaway]	bit DEFAULT 0,
                //[LayawayNumber]	integer,
                //[RoundedValue]	numeric NOT NULL DEFAULT 0,
                //[OnlineDealsSM]	integer DEFAULT 0,
                //[SERVICECHARGE]	numeric NOT NULL DEFAULT 0,
                //[ORDERTYPE]	varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
                //[GUESTCOUNT]	integer NOT NULL DEFAULT 0,
                //[SCID]	varchar(40) NOT NULL COLLATE NOCASE DEFAULT '',
                //[PWDID]	varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
                //[SENIORCITIZENDISCQSR]	numeric,
                //[SENIORCITIZENCOUNT]	numeric
            };
        }

        public long       TransactionNo          { get; set; }
        public string     CustomerCode           { get; set; }
        public string     Description            { get; set; }
        public decimal?   SubTotal               { get; set; }
        public decimal?   GrandTotal             { get; set; }
        public decimal?   DownPayments           { get; set; }
        public decimal?   Discount               { get; set; }
        public decimal?   AmountDiscounted       { get; set; }
        public decimal?   Allowance              { get; set; }
        public decimal?   ChargeDiscount         { get; set; }
        public decimal?   ChargeAllowance        { get; set; }
        public decimal?   ChargeAmountDiscounted { get; set; }
        public long       Shift                  { get; set; }
        public string     UserID                 { get; set; }
        public string     TerminalNo             { get; set; }
        public string     BranchCode             { get; set; }
        public DateTime   LogDate                { get; set; }
        public DateTime?  DateTime               { get; set; }
        public bool       Voided                 { get; set; }
        public string     VoidRemarks            { get; set; }
        public decimal    BaggerID               { get; set; }
        public bool       Senior                 { get; set; }
        public decimal    ReturnSubtotal         { get; set; }
        public decimal    SalesmanID             { get; set; }
        public DateTime?  TimeOfFirstScan        { get; set; }
        public DateTime?  TimeOfLastScan         { get; set; }
        public DateTime?  TimeCashedOut          { get; set; }
        public DateTime?  TimeBaggingStarted     { get; set; }
        public DateTime?  TimeBaggingFinished    { get; set; }
        public bool?      Layaway                { get; set; }
        public long?      LayawayNumber          { get; set; }
        public decimal    RoundedValue           { get; set; }
        public long?      OnlineDealsSM          { get; set; }
        public decimal    SERVICECHARGE          { get; set; }
        public string     ORDERTYPE              { get; set; }
        public long       GUESTCOUNT             { get; set; }
        public string     SCID                   { get; set; }
        public string     PWDID                  { get; set; }
        public decimal?   SENIORCITIZENDISCQSR   { get; set; }
        public decimal?   SENIORCITIZENCOUNT     { get; set; }
    }
}
