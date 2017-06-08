using Repo2.Core.ns11.Extensions;
using System;
using System.Data;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrRemittance
    {
        public CdrRemittance(IDataRecord r)
        {
            fldLineID              = r.ToInt    ( 0);// int     
            fldUserID              = r.ToInt    ( 1);// int     
            fldName                = r.ToText   ( 2);// string  
            fldTerminalNo          = r.ToText   ( 3);// string  
            fldShift               = r.ToInt    ( 4);// int     
            fldLogDate             = r.ToDate   ( 5);// DateTime
            fldRemittanceNo        = r.ToInt_   ( 6);// int?    
            fldReadingNetAmount    = r.ToDecimal( 7);// decimal 
            fldReadingGrossAmount  = r.ToDecimal( 8);// decimal 
            fldCancelledTran       = r.ToDecimal( 9);// decimal 
            fldVoidTran            = r.ToDecimal(10);// decimal 
            fldReturn              = r.ToDecimal(11);// decimal 
            fldLoan                = r.ToDecimal(12);// decimal 
            fldWithdrawal          = r.ToDecimal(13);// decimal 
            fldCashTender          = r.ToDecimal(14);// decimal 
            fldOtherTender         = r.ToDecimal(15);// decimal 
            fldSalaryDeduction     = r.ToDecimal(16);// decimal 
            fldCashRemitted        = r.ToDecimal(17);// decimal 
            fldOthersRemitted      = r.ToDecimal(18);// decimal 
            fldTotalAmountRemitted = r.ToDecimal(19);// decimal 
            fldShortage            = r.ToDecimal(20);// decimal 
            fldRemarks             = r.ToText   (21);// string  

            ParsedTerminalNo = uint.Parse(fldTerminalNo);
        }

        public int      fldLineID              { get; }// integer NOT NULL,
        public int      fldUserID              { get; }// integer NOT NULL,
        public string   fldName                { get; }// varchar(30) NOT NULL COLLATE NOCASE DEFAULT '',
        public string   fldTerminalNo          { get; }// varchar(5) NOT NULL COLLATE NOCASE,
        public int      fldShift               { get; }// integer NOT NULL,
        public DateTime fldLogDate             { get; }// datetime NOT NULL,
        public int?     fldRemittanceNo        { get; }// integer,
        public decimal  fldReadingNetAmount    { get; }// numeric NOT NULL DEFAULT 0,
        public decimal  fldReadingGrossAmount  { get; }// numeric NOT NULL DEFAULT 0,
        public decimal  fldCancelledTran       { get; }// numeric NOT NULL DEFAULT 0,
        public decimal  fldVoidTran            { get; }// numeric NOT NULL DEFAULT 0,
        public decimal  fldReturn              { get; }// numeric NOT NULL DEFAULT 0,
        public decimal  fldLoan                { get; }// numeric NOT NULL DEFAULT 0,
        public decimal  fldWithdrawal          { get; }// numeric NOT NULL DEFAULT 0,
        public decimal  fldCashTender          { get; }// numeric NOT NULL DEFAULT 0,
        public decimal  fldOtherTender         { get; }// numeric NOT NULL DEFAULT 0,
        public decimal  fldSalaryDeduction     { get; }// numeric NOT NULL DEFAULT 0,
        public decimal  fldCashRemitted        { get; }// numeric NOT NULL DEFAULT 0,
        public decimal  fldOthersRemitted      { get; }// numeric NOT NULL DEFAULT 0,
        public decimal  fldTotalAmountRemitted { get; }// numeric NOT NULL DEFAULT 0,
        public decimal  fldShortage            { get; }// numeric NOT NULL DEFAULT 0,
        public string   fldRemarks             { get; }// varchar(30) NOT NULL COLLATE NOCASE DEFAULT ''

        public uint ParsedTerminalNo { get; }
    }
}
/*
CREATE TABLE [Remittance] (
    [fldLineID             ]	integer NOT NULL,
    [fldUserID             ]	integer NOT NULL,
    [fldName               ]	varchar(30) NOT NULL COLLATE NOCASE DEFAULT '',
    [fldTerminalNo         ]	varchar(5) NOT NULL COLLATE NOCASE,
    [fldShift              ]	integer NOT NULL,
    [fldLogDate            ]	datetime NOT NULL,
    [fldRemittanceNo       ]	integer,
    [fldReadingNetAmount   ]	numeric NOT NULL DEFAULT 0,
    [fldReadingGrossAmount ]	numeric NOT NULL DEFAULT 0,
    [fldCancelledTran      ]	numeric NOT NULL DEFAULT 0,
    [fldVoidTran           ]	numeric NOT NULL DEFAULT 0,
    [fldReturn             ]	numeric NOT NULL DEFAULT 0,
    [fldLoan               ]	numeric NOT NULL DEFAULT 0,
    [fldWithdrawal         ]	numeric NOT NULL DEFAULT 0,
    [fldCashTender         ]	numeric NOT NULL DEFAULT 0,
    [fldOtherTender        ]	numeric NOT NULL DEFAULT 0,
    [fldSalaryDeduction    ]	numeric NOT NULL DEFAULT 0,
    [fldCashRemitted       ]	numeric NOT NULL DEFAULT 0,
    [fldOthersRemitted     ]	numeric NOT NULL DEFAULT 0,
    [fldTotalAmountRemitted]	numeric NOT NULL DEFAULT 0,
    [fldShortage           ]	numeric NOT NULL DEFAULT 0,
    [fldRemarks            ]	varchar(30) NOT NULL COLLATE NOCASE DEFAULT ''
);*/
