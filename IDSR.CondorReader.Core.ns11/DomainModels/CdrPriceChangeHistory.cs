using IDSR.CondorReader.Core.ns11.Converters;
using Repo2.Core.ns11.Extensions;
using System;
using System.Collections.Generic;
using System.Data;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrPriceChangeHistory
    {
        public CdrPriceChangeHistory(IDataRecord r)
        {
            lineid        = r.ToInt   ( 0);// int       
            productid     = r.ToInt_  ( 1);// int?      
            barcode       = r.ToText  ( 2);// string    
            PriceModecode = r.ToText  ( 3);// string    
            dateposted    = r.ToDate_ ( 4);// DateTime? 
            postedby      = r.ToText  ( 5);// string    
            fromsrp       = r.ToDouble( 6);// double    
            tosrp         = r.ToDouble( 7);// double    
            UOM           = r.ToText  ( 8);// string    
            markup        = r.ToDouble( 9);// double    
            initialprice  = r.ToBool  (10);// bool      

            ParsedBarCode = barcode.ToBarCode("");
        }

        public int       lineid        { get; }// integer NOT NULL,
        public int?      productid     { get; }// integer,
        public string    barcode       { get; }// varchar(20) COLLATE NOCASE,
        public string    PriceModecode { get; }// varchar(2) COLLATE NOCASE,
        public DateTime? dateposted    { get; }// datetime,
        public string    postedby      { get; }// nvarchar(20) COLLATE NOCASE,
        public double    fromsrp       { get; }// float DEFAULT 0,
        public double    tosrp         { get; }// float DEFAULT 0,
        public string    UOM           { get; }// varchar(6) COLLATE NOCASE DEFAULT 0,
        public double    markup        { get; }// float DEFAULT 0,
        public bool      initialprice  { get; }// bit DEFAULT 0

        public ulong     ParsedBarCode { get; }

        public List<CdrPOS_Products> SellingBarcodes { get; set; }
    }
}
/*
CREATE TABLE [PriceChangeHistory] (
    [lineid       ]	integer NOT NULL,
    [productid    ]	integer,
    [barcode      ]	varchar(20) COLLATE NOCASE,
    [PriceModecode]	varchar(2) COLLATE NOCASE,
    [dateposted   ]	datetime,
    [postedby     ]	nvarchar(20) COLLATE NOCASE,
    [fromsrp      ]	float DEFAULT 0,
    [tosrp        ]	float DEFAULT 0,
    [UOM          ]	varchar(6) COLLATE NOCASE DEFAULT 0,
    [markup       ]	float DEFAULT 0,
    [initialprice ]	bit DEFAULT 0
);

 */
