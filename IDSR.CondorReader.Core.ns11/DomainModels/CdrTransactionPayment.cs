using Repo2.Core.ns11.Extensions;
using System;
using System.Data;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrTransactionPayment
    {
        public CdrTransactionPayment(IDataRecord r)
        {
            TransactionNo    = r.ToLong( 0);// long     integer DEFAULT 0,
            TenderCode       = r.ToText( 1);// string   varchar(3) COLLATE NOCASE DEFAULT '',
            Description      = r.ToText( 2);// string   varchar(20) COLLATE NOCASE DEFAULT '',
            Amount           = r.ToDecimal( 3);// decimal  numeric DEFAULT 0,
            Cash             = r.ToBool( 4);// bool     bit NOT NULL DEFAULT 0,
            Change           = r.ToBool( 5);// bool     bit NOT NULL DEFAULT 0,
            ChargeToAccount  = r.ToBool( 6);// bool     bit NOT NULL DEFAULT 0,
            Validate         = r.ToBool( 7);// bool     bit NOT NULL DEFAULT 0,
            AccountNo        = r.ToText( 8);// string   varchar(20) COLLATE NOCASE DEFAULT '',
            ApprovalNo       = r.ToText( 9);// string   varchar(20) COLLATE NOCASE DEFAULT '',
            Remarks          = r.ToText(10);// string   varchar(30) COLLATE NOCASE DEFAULT '',
            Shift            = (int)r.ToLong(11);// int      integer NOT NULL DEFAULT 0,
            UserID           = r.ToText(12);// string   varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
            TerminalNo       = r.ToText(13);// string   varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
            BranchCode       = r.ToText(14);// string   varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
            LogDate          = r.ToDate(15);// DateTime datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
            DateTime         = r.ToDate(16);// DateTime datetime DEFAULT (CURRENT_TIMESTAMP),
            Voided           = r.ToBool(17);// bool     bit NOT NULL DEFAULT 0,
            Layaway          = r.ToBool(18);// bool     bit DEFAULT 0,
            LayawayNumber    = (int?)r.ToLong_(19);// int?     integer,
            Deposit          = r.ToBool(20);// bool     bit DEFAULT 0,
            Memo             = r.ToText(21);// string   varchar(50) NOT NULL COLLATE NOCASE DEFAULT '',
            DateDue          = r.ToText(22);// string   varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
            GCValidationCode = r.ToText(23);// string   varchar(50) COLLATE NOCASE
        }

        public long     TransactionNo    { get; }// integer DEFAULT 0,
        public string   TenderCode       { get; }// varchar(3) COLLATE NOCASE DEFAULT '',
        public string   Description      { get; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public decimal  Amount           { get; }// numeric DEFAULT 0,
        public bool     Cash             { get; }// bit NOT NULL DEFAULT 0,
        public bool     Change           { get; }// bit NOT NULL DEFAULT 0,
        public bool     ChargeToAccount  { get; }// bit NOT NULL DEFAULT 0,
        public bool     Validate         { get; }// bit NOT NULL DEFAULT 0,
        public string   AccountNo        { get; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public string   ApprovalNo       { get; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public string   Remarks          { get; }// varchar(30) COLLATE NOCASE DEFAULT '',
        public int      Shift            { get; }// integer NOT NULL DEFAULT 0,
        public string   UserID           { get; }// varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
        public string   TerminalNo       { get; }// varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
        public string   BranchCode       { get; }// varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
        public DateTime LogDate          { get; }// datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        public DateTime DateTime         { get; }// datetime DEFAULT (CURRENT_TIMESTAMP),
        public bool     Voided           { get; }// bit NOT NULL DEFAULT 0,
        public bool     Layaway          { get; }// bit DEFAULT 0,
        public int?     LayawayNumber    { get; }// integer,
        public bool     Deposit          { get; }// bit DEFAULT 0,
        public string   Memo             { get; }// varchar(50) NOT NULL COLLATE NOCASE DEFAULT '',
        public string   DateDue          { get; }// varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
        public string   GCValidationCode { get; }// varchar(50) COLLATE NOCASE
    }
}
/*
CREATE TABLE [FinishedPayments] (
    [TransactionNo   ]	integer DEFAULT 0,
    [TenderCode      ]	varchar(3) COLLATE NOCASE DEFAULT '',
    [Description     ]	varchar(20) COLLATE NOCASE DEFAULT '',
    [Amount          ]	numeric DEFAULT 0,
    [Cash            ]	bit NOT NULL DEFAULT 0,
    [Change          ]	bit NOT NULL DEFAULT 0,
    [ChargeToAccount ]	bit NOT NULL DEFAULT 0,
    [Validate        ]	bit NOT NULL DEFAULT 0,
    [AccountNo       ]	varchar(20) COLLATE NOCASE DEFAULT '',
    [ApprovalNo      ]	varchar(20) COLLATE NOCASE DEFAULT '',
    [Remarks         ]	varchar(30) COLLATE NOCASE DEFAULT '',
    [Shift           ]	integer NOT NULL DEFAULT 0,
    [UserID          ]	varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
    [TerminalNo      ]	varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
    [BranchCode      ]	varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
    [LogDate         ]	datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [DateTime        ]	datetime DEFAULT (CURRENT_TIMESTAMP),
    [Voided          ]	bit NOT NULL DEFAULT 0,
    [Layaway         ]	bit DEFAULT 0,
    [LayawayNumber   ]	integer,
    [Deposit         ]	bit DEFAULT 0,
    [Memo            ]	varchar(50) NOT NULL COLLATE NOCASE DEFAULT '',
    [DateDue         ]	varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
    [GCValidationCode]	varchar(50) COLLATE NOCASE
);
*/
