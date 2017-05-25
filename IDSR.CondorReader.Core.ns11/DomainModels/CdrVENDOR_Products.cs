using IDSR.CondorReader.Core.ns11.Converters;
using Repo2.Core.ns11.Extensions;
using System;
using System.Data;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrVENDOR_Products
    {
        public CdrVENDOR_Products(IDataRecord r)
        {
            ProductID         = r.ToInt     ( 0);// int      integer NOT NULL,
            Description       = r.ToText    ( 1);// string   varchar(100) NOT NULL COLLATE NOCASE,
            VendorProductCode = r.ToText    ( 2);// string   varchar(20) NOT NULL COLLATE NOCASE,
            VendorCode        = r.ToText    ( 3);// string   varchar(10) NOT NULL COLLATE NOCASE,
            uom               = r.ToText    ( 4);// string   varchar(6) NOT NULL COLLATE NOCASE DEFAULT 'PC',
            qty               = r.ToDecimal ( 5);// decimal  numeric NOT NULL DEFAULT 1,
            cost              = r.ToDecimal ( 6);// decimal  numeric NOT NULL DEFAULT 0,
            averagecost       = r.ToDecimal ( 7);// decimal  numeric NOT NULL DEFAULT 0,
            defa              = r.ToBool    ( 8);// bool     bit NOT NULL DEFAULT 0,
            averagenetcost    = r.ToDecimal ( 9);// decimal  numeric NOT NULL DEFAULT 0,
            includediscounts  = r.ToBool    (10);// bool     bit NOT NULL DEFAULT 0,
            MULTIPLIER        = r.ToDouble  (11);// double   float NOT NULL DEFAULT 0,
            discountcode1     = r.ToText    (12);// string   varchar(4) COLLATE NOCASE,
            discountcode2     = r.ToText    (13);// string   varchar(4) COLLATE NOCASE,
            discountcode3     = r.ToText    (14);// string   varchar(4) COLLATE NOCASE,
            discount1         = r.ToDecimal (15);// decimal  numeric NOT NULL DEFAULT 0,
            discount2         = r.ToDecimal (16);// decimal  numeric NOT NULL DEFAULT 0,
            discount3         = r.ToDecimal (17);// decimal  numeric NOT NULL DEFAULT 0,
            totalcost         = r.ToDecimal (18);// decimal  numeric NOT NULL DEFAULT 0,
            tradediscount     = r.ToText    (19);// string   varchar(20) COLLATE NOCASE,
            LastDateModified  = r.ToDate    (20);// DateTime datetime DEFAULT (CURRENT_TIMESTAMP)

            ParsedBarCode     = VendorProductCode.ToBarCode(Description);
        }

        public int        ProductID          { get; }// integer NOT NULL,
        public string     Description        { get; }// varchar(100) NOT NULL COLLATE NOCASE,
        public string     VendorProductCode  { get; }// varchar(20) NOT NULL COLLATE NOCASE,
        public string     VendorCode         { get; }// varchar(10) NOT NULL COLLATE NOCASE,
        public string     uom                { get; }// varchar(6) NOT NULL COLLATE NOCASE DEFAULT 'PC',
        public decimal    qty                { get; }// numeric NOT NULL DEFAULT 1,
        public decimal    cost               { get; }// numeric NOT NULL DEFAULT 0,
        public decimal    averagecost        { get; }// numeric NOT NULL DEFAULT 0,
        public bool       defa               { get; }// bit NOT NULL DEFAULT 0,
        public decimal    averagenetcost     { get; }// numeric NOT NULL DEFAULT 0,
        public bool       includediscounts   { get; }// bit NOT NULL DEFAULT 0,
        public double     MULTIPLIER         { get; }// float NOT NULL DEFAULT 0,
        public string     discountcode1      { get; }// varchar(4) COLLATE NOCASE,
        public string     discountcode2      { get; }// varchar(4) COLLATE NOCASE,
        public string     discountcode3      { get; }// varchar(4) COLLATE NOCASE,
        public decimal    discount1          { get; }// numeric NOT NULL DEFAULT 0,
        public decimal    discount2          { get; }// numeric NOT NULL DEFAULT 0,
        public decimal    discount3          { get; }// numeric NOT NULL DEFAULT 0,
        public decimal    totalcost          { get; }// numeric NOT NULL DEFAULT 0,
        public string     tradediscount      { get; }// varchar(20) COLLATE NOCASE,
        public DateTime   LastDateModified   { get; }// datetime DEFAULT (CURRENT_TIMESTAMP)

        public ulong      ParsedBarCode      { get; }
    }
}
/*
CREATE TABLE [VENDOR_Products] (
    [ProductID        ]	integer NOT NULL,
    [Description      ]	varchar(100) NOT NULL COLLATE NOCASE,
    [VendorProductCode]	varchar(20) NOT NULL COLLATE NOCASE,
    [VendorCode       ]	varchar(10) NOT NULL COLLATE NOCASE,
    [uom              ]	varchar(6) NOT NULL COLLATE NOCASE DEFAULT 'PC',
    [qty              ]	numeric NOT NULL DEFAULT 1,
    [cost             ]	numeric NOT NULL DEFAULT 0,
    [averagecost      ]	numeric NOT NULL DEFAULT 0,
    [defa             ]	bit NOT NULL DEFAULT 0,
    [averagenetcost   ]	numeric NOT NULL DEFAULT 0,
    [includediscounts ]	bit NOT NULL DEFAULT 0,
    [MULTIPLIER       ]	float NOT NULL DEFAULT 0,
    [discountcode1    ]	varchar(4) COLLATE NOCASE,
    [discountcode2    ]	varchar(4) COLLATE NOCASE,
    [discountcode3    ]	varchar(4) COLLATE NOCASE,
    [discount1        ]	numeric NOT NULL DEFAULT 0,
    [discount2        ]	numeric NOT NULL DEFAULT 0,
    [discount3        ]	numeric NOT NULL DEFAULT 0,
    [totalcost        ]	numeric NOT NULL DEFAULT 0,
    [tradediscount    ]	varchar(20) COLLATE NOCASE,
    [LastDateModified ]	datetime DEFAULT (CURRENT_TIMESTAMP)
);
 */
