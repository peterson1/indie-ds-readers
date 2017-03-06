using System;
using System.Data;
using Repo2.Core.ns11.Extensions;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrVendor
    {
        public CdrVendor(IDataRecord r)
        {
            vendorcode            = r.ToText    ( 0);// varchar(10) NOT NULL, 
            description           = r.ToText    ( 1);// varchar(40) NOT NULL, 
            address               = r.ToText    ( 2);// varchar(50), 
            city                  = r.ToText    ( 3);// varchar(20), 
            zipcode               = r.ToText    ( 4);// varchar(6), 
            country               = r.ToText    ( 5);// varchar(20), 
            fax                   = r.ToText    ( 6);// varchar(20), 
            email                 = r.ToText    ( 7);// varchar(50), 
            phone                 = r.ToText    ( 8);// varchar(20), 
            contactperson         = r.ToText    ( 9);// varchar(30), 
            termid                = r.ToInt     (10);// numeric(18, 0) NOT NULL DEFAULT ((0)),
            daystodeliver         = r.ToInt     (11);// int NOT NULL DEFAULT ((0)), 
            tradediscount         = r.ToText    (12);// varchar(20), 
            cashdiscount          = r.ToText    (13);// varchar(20), 
            terms                 = r.ToInt     (14);// int NOT NULL DEFAULT ((0)), 
            IncludeLineDiscounts  = r.GetBoolean(15);// bit NOT NULL DEFAULT ((0)), 
            discountcode1         = r.ToText    (16);// varchar(4) NOT NULL DEFAULT (''), 
            discountcode2         = r.ToText    (17);// varchar(4) NOT NULL DEFAULT (''), 
            discountcode3         = r.ToText    (18);// varchar(4) NOT NULL DEFAULT (''), 
            discount1             = r.ToDecimal (19);// numeric(18, 4) NOT NULL DEFAULT ((0)),
            discount2             = r.ToDecimal (20);// numeric(18, 4) NOT NULL DEFAULT ((0)),
            discount3             = r.ToDecimal (21);// numeric(18, 4) NOT NULL DEFAULT ((0)),
            daystosum             = r.ToInt     (22);// int NOT NULL DEFAULT ((0)), 
            reordermultiplier     = r.ToInt     (23);// int NOT NULL DEFAULT ((0)), 
            remarks               = r.ToText    (24);// varchar(20), 
            SHAREWITHBRANCH       = r.GetBoolean(25);// bit NOT NULL DEFAULT ((0)), 
            Consignor             = r.GetBoolean(26);// bit NOT NULL DEFAULT ((0)), 
            LASTDATEMODIFIED      = r.ToDate    (27);// datetime NOT NULL DEFAULT (getdate()),
            TIN                   = r.ToText    (28);// varchar(20) NOT NULL DEFAULT (''), 
            Cluster               = r.ToText    (29);// varchar(20) NOT NULL DEFAULT (''), 
            CeilingLimit          = r.ToDecimal (30);// numeric(18, 2) NOT NULL DEFAULT ((0)),
            CeilingCounter        = r.ToDecimal (31);// numeric(18, 2) NOT NULL DEFAULT ((0))
        }

        public string    vendorcode            { get; }// varchar(10) NOT NULL, 
        public string    description           { get; }// varchar(40) NOT NULL, 
        public string    address               { get; }// varchar(50), 
        public string    city                  { get; }// varchar(20), 
        public string    zipcode               { get; }// varchar(6), 
        public string    country               { get; }// varchar(20), 
        public string    fax                   { get; }// varchar(20), 
        public string    email                 { get; }// varchar(50), 
        public string    phone                 { get; }// varchar(20), 
        public string    contactperson         { get; }// varchar(30), 
        public decimal   termid                { get; }// numeric(18, 0) NOT NULL DEFAULT ((0)),
        public int       daystodeliver         { get; }// int NOT NULL DEFAULT ((0)), 
        public string    tradediscount         { get; }// varchar(20), 
        public string    cashdiscount          { get; }// varchar(20), 
        public int       terms                 { get; }// int NOT NULL DEFAULT ((0)), 
        public bool      IncludeLineDiscounts  { get; }// bit NOT NULL DEFAULT ((0)), 
        public string    discountcode1         { get; }// varchar(4) NOT NULL DEFAULT (''), 
        public string    discountcode2         { get; }// varchar(4) NOT NULL DEFAULT (''), 
        public string    discountcode3         { get; }// varchar(4) NOT NULL DEFAULT (''), 
        public decimal   discount1             { get; }// numeric(18, 4) NOT NULL DEFAULT ((0)),
        public decimal   discount2             { get; }// numeric(18, 4) NOT NULL DEFAULT ((0)),
        public decimal   discount3             { get; }// numeric(18, 4) NOT NULL DEFAULT ((0)),
        public int       daystosum             { get; }// int NOT NULL DEFAULT ((0)), 
        public int       reordermultiplier     { get; }// int NOT NULL DEFAULT ((0)), 
        public string    remarks               { get; }// varchar(20), 
        public bool      SHAREWITHBRANCH       { get; }// bit NOT NULL DEFAULT ((0)), 
        public bool      Consignor             { get; }// bit NOT NULL DEFAULT ((0)), 
        public DateTime  LASTDATEMODIFIED      { get; }// datetime NOT NULL DEFAULT (getdate()),
        public string    TIN                   { get; }// varchar(20) NOT NULL DEFAULT (''), 
        public string    Cluster               { get; }// varchar(20) NOT NULL DEFAULT (''), 
        public decimal   CeilingLimit          { get; }// numeric(18, 2) NOT NULL DEFAULT ((0)),
        public decimal   CeilingCounter        { get; }// numeric(18, 2) NOT NULL DEFAULT ((0))
    }
}
