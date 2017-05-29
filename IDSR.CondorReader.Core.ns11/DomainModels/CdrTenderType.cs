using Repo2.Core.ns11.Extensions;
using System;
using System.Data;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrTenderType
    {
        public CdrTenderType(IDataRecord r)
        {
            TenderCode       = r.ToText ( 0);// 
            Description      = r.ToText ( 1);// 
            Cash             = r.ToBool ( 2);// 
            Change           = r.ToBool ( 3);// 
            ChargeToAccount  = r.ToBool ( 4);// 
            Validate         = r.ToBool ( 5);// 
            AccountNo        = r.ToBool ( 6);// 
            AccountNoSize    = r.ToInt  ( 7);// 
            ApprovalNo       = r.ToBool ( 8);// 
            Remarks          = r.ToBool ( 9);// 
            RemarksLabel     = r.ToText (10);// 
            Memo             = r.ToBool (11);// 
            MemoLabel        = r.ToText (12);// 
            DateDue          = r.ToBool (13);// 
            Hotkey           = r.ToInt_ (14);// 
            logo             = r.ToText (15);// 
            MSR              = r.ToBool (16);// 
            LastDateModified = r.ToDate (17);// 
        }

        public string    TenderCode        { get; }// nvarchar(3) COLLATE NOCASE,
        public string    Description       { get; }// nvarchar(20) COLLATE NOCASE,
        public bool      Cash              { get; }// bit NOT NULL,
        public bool      Change            { get; }// bit NOT NULL,
        public bool      ChargeToAccount   { get; }// bit NOT NULL,
        public bool      Validate          { get; }// bit NOT NULL,
        public bool      AccountNo         { get; }// bit NOT NULL,
        public int       AccountNoSize     { get; }// integer NOT NULL,
        public bool      ApprovalNo        { get; }// bit NOT NULL,
        public bool      Remarks           { get; }// bit NOT NULL,
        public string    RemarksLabel      { get; }// varchar(40) COLLATE NOCASE DEFAULT '',
        public bool?     Memo              { get; }// bit,
        public string    MemoLabel         { get; }// varchar(40) COLLATE NOCASE DEFAULT '',
        public bool?     DateDue           { get; }// bit,
        public int?      Hotkey            { get; }// integer,
        public string    logo              { get; }// nvarchar(100) COLLATE NOCASE,
        public bool      MSR               { get; }// bit NOT NULL DEFAULT 0,
        public DateTime  LastDateModified  { get; }// datetime DEFAULT (CURRENT_TIMESTAMP)
    }
}
/*
CREATE TABLE [TenderTypes] (
    [TenderCode      ]	nvarchar(3) COLLATE NOCASE,
    [Description     ]	nvarchar(20) COLLATE NOCASE,
    [Cash            ]	bit NOT NULL,
    [Change          ]	bit NOT NULL,
    [ChargeToAccount ]	bit NOT NULL,
    [Validate        ]	bit NOT NULL,
    [AccountNo       ]	bit NOT NULL,
    [AccountNoSize   ]	integer NOT NULL,
    [ApprovalNo      ]	bit NOT NULL,
    [Remarks         ]	bit NOT NULL,
    [RemarksLabel    ]	varchar(40) COLLATE NOCASE DEFAULT '',
    [Memo            ]	bit,
    [MemoLabel       ]	varchar(40) COLLATE NOCASE DEFAULT '',
    [DateDue         ]	bit,
    [Hotkey          ]	integer,
    [logo            ]	nvarchar(100) COLLATE NOCASE,
    [MSR             ]	bit NOT NULL DEFAULT 0,
    [LastDateModified]	datetime DEFAULT (CURRENT_TIMESTAMP)
);
 */
