﻿using IDSR.CondorReader.Core.ns11.Converters;
using Repo2.Core.ns11.Extensions;
using System;
using System.Data;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrCustomer
    {
        public CdrCustomer(IDataRecord r)
        {
            customercode     = r.ToText    ( 0);// varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
            description      = r.ToText    ( 1);// varchar(50) NOT NULL COLLATE NOCASE DEFAULT '',
            address          = r.ToText    ( 2);// varchar(100) COLLATE NOCASE DEFAULT '',
            city             = r.ToText    ( 3);// varchar(50) COLLATE NOCASE DEFAULT '',
            zipcode          = r.ToText    ( 4);// varchar(6) COLLATE NOCASE DEFAULT '',
            country          = r.ToText    ( 5);// varchar(20) COLLATE NOCASE DEFAULT '',
            fax              = r.ToText    ( 6);// varchar(20) COLLATE NOCASE DEFAULT '',
            email            = r.ToText    ( 7);// varchar(50) COLLATE NOCASE DEFAULT '',
            phone            = r.ToText    ( 8);// varchar(20) COLLATE NOCASE DEFAULT '',
            creditlimit      = r.ToDecimal ( 9);// numeric NOT NULL DEFAULT 0,
            creditbalance    = r.ToDecimal (10);// numeric NOT NULL DEFAULT 0,
            discount         = r.ToDecimal (11);// numeric NOT NULL DEFAULT 0,
            allowance        = r.GetBoolean(12);// bit NOT NULL DEFAULT 0,
            pricemodecode    = r.ToText    (13);// varchar(2) COLLATE NOCASE DEFAULT '',
            remarks          = r.ToText    (14);// varchar(50) COLLATE NOCASE DEFAULT '',
            currentpoints    = r.ToDecimal (15);// numeric NOT NULL DEFAULT 0,
            LastDateModified = r.ToDate    (16);// datetime DEFAULT (CURRENT_TIMESTAMP),
            drdescription    = r.ToText    (17);// varchar(40) COLLATE NOCASE DEFAULT '',
            draddress        = r.ToText    (18);// varchar(50) COLLATE NOCASE DEFAULT '',
            drcity           = r.ToText    (19);// varchar(20) COLLATE NOCASE DEFAULT '',
            drzipcode        = r.ToText    (20);// varchar(6) COLLATE NOCASE DEFAULT '',
            drcountry        = r.ToText    (21);// varchar(20) COLLATE NOCASE DEFAULT '',
            SalesmanCode     = r.ToText    (22);// varchar(20) COLLATE NOCASE DEFAULT '',
            Category         = r.ToText    (23);// varchar(30) COLLATE NOCASE DEFAULT '',
            Status           = r.ToInt     (24);// integer DEFAULT 1,
            Branch           = r.ToText    (25);// varchar(10) COLLATE NOCASE DEFAULT '',
            ExpirationDate   = r.ToDate    (26);// datetime DEFAULT (CURRENT_TIMESTAMP),
            MemberSince      = r.ToDate    (27);// datetime DEFAULT (CURRENT_TIMESTAMP),
            ContactPerson    = r.ToText    (28);// varchar(40) COLLATE NOCASE DEFAULT '',
            Terms            = r.ToInt     (29);// integer NOT NULL DEFAULT 0,
            Birthday         = r.ToDate    (30);// datetime DEFAULT (CURRENT_TIMESTAMP),
            Mobile           = r.ToText    (31);// varchar(20) COLLATE NOCASE DEFAULT '',
            Business         = r.ToText    (32);// varchar(10) COLLATE NOCASE DEFAULT '',
            BusinessEmail    = r.ToText    (33);// varchar(50) NOT NULL COLLATE NOCASE DEFAULT '',
            Age              = r.ToInt     (34);// integer NOT NULL DEFAULT 0,
            Gender           = r.ToText    (35);// char(1) NOT NULL COLLATE NOCASE DEFAULT '',
            Biometric        = r.ToText    (36);// blob(5000)

            ParsedBarCode    = customercode.ToBarCode(description);
        }

        public string    customercode     { get; }// varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
        public string    description      { get; }// varchar(50) NOT NULL COLLATE NOCASE DEFAULT '',
        public string    address          { get; }// varchar(100) COLLATE NOCASE DEFAULT '',
        public string    city             { get; }// varchar(50) COLLATE NOCASE DEFAULT '',
        public string    zipcode          { get; }// varchar(6) COLLATE NOCASE DEFAULT '',
        public string    country          { get; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public string    fax              { get; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public string    email            { get; }// varchar(50) COLLATE NOCASE DEFAULT '',
        public string    phone            { get; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public decimal   creditlimit      { get; }// numeric NOT NULL DEFAULT 0,
        public decimal   creditbalance    { get; }// numeric NOT NULL DEFAULT 0,
        public decimal   discount         { get; }// numeric NOT NULL DEFAULT 0,
        public bool      allowance        { get; }// bit NOT NULL DEFAULT 0,
        public string    pricemodecode    { get; }// varchar(2) COLLATE NOCASE DEFAULT '',
        public string    remarks          { get; }// varchar(50) COLLATE NOCASE DEFAULT '',
        public decimal   currentpoints    { get; }// numeric NOT NULL DEFAULT 0,
        public DateTime  LastDateModified { get; }// datetime DEFAULT (CURRENT_TIMESTAMP),
        public string    drdescription    { get; }// varchar(40) COLLATE NOCASE DEFAULT '',
        public string    draddress        { get; }// varchar(50) COLLATE NOCASE DEFAULT '',
        public string    drcity           { get; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public string    drzipcode        { get; }// varchar(6) COLLATE NOCASE DEFAULT '',
        public string    drcountry        { get; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public string    SalesmanCode     { get; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public string    Category         { get; }// varchar(30) COLLATE NOCASE DEFAULT '',
        public int       Status           { get; }// integer DEFAULT 1,
        public string    Branch           { get; }// varchar(10) COLLATE NOCASE DEFAULT '',
        public DateTime  ExpirationDate   { get; }// datetime DEFAULT (CURRENT_TIMESTAMP),
        public DateTime  MemberSince      { get; }// datetime DEFAULT (CURRENT_TIMESTAMP),
        public string    ContactPerson    { get; }// varchar(40) COLLATE NOCASE DEFAULT '',
        public int       Terms            { get; }// integer NOT NULL DEFAULT 0,
        public DateTime  Birthday         { get; }// datetime DEFAULT (CURRENT_TIMESTAMP),
        public string    Mobile           { get; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public string    Business         { get; }// varchar(10) COLLATE NOCASE DEFAULT '',
        public string    BusinessEmail    { get; }// varchar(50) NOT NULL COLLATE NOCASE DEFAULT '',
        public int       Age              { get; }// integer NOT NULL DEFAULT 0,
        public string    Gender           { get; }// char(1) NOT NULL COLLATE NOCASE DEFAULT '',
        public string    Biometric        { get; }// blob(5000)
        public ulong     ParsedBarCode    { get; }
    }

    /*
        [customercode    ]	// varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
        [description     ]	// varchar(50) NOT NULL COLLATE NOCASE DEFAULT '',
        [address         ]	// varchar(100) COLLATE NOCASE DEFAULT '',
        [city            ]	// varchar(50) COLLATE NOCASE DEFAULT '',
        [zipcode         ]	// varchar(6) COLLATE NOCASE DEFAULT '',
        [country         ]	// varchar(20) COLLATE NOCASE DEFAULT '',
        [fax             ]	// varchar(20) COLLATE NOCASE DEFAULT '',
        [email           ]	// varchar(50) COLLATE NOCASE DEFAULT '',
        [phone           ]	// varchar(20) COLLATE NOCASE DEFAULT '',
        [creditlimit     ]	// numeric NOT NULL DEFAULT 0,
        [creditbalance   ]	// numeric NOT NULL DEFAULT 0,
        [discount        ]	// numeric NOT NULL DEFAULT 0,
        [allowance       ]	// bit NOT NULL DEFAULT 0,
        [pricemodecode   ]	// varchar(2) COLLATE NOCASE DEFAULT '',
        [remarks         ]	// varchar(50) COLLATE NOCASE DEFAULT '',
        [currentpoints   ]	// numeric NOT NULL DEFAULT 0,
        [LastDateModified]	// datetime DEFAULT (CURRENT_TIMESTAMP),
        [drdescription   ]	// varchar(40) COLLATE NOCASE DEFAULT '',
        [draddress       ]	// varchar(50) COLLATE NOCASE DEFAULT '',
        [drcity          ]	// varchar(20) COLLATE NOCASE DEFAULT '',
        [drzipcode       ]	// varchar(6) COLLATE NOCASE DEFAULT '',
        [drcountry       ]	// varchar(20) COLLATE NOCASE DEFAULT '',
        [SalesmanCode    ]	// varchar(20) COLLATE NOCASE DEFAULT '',
        [Category        ]	// varchar(30) COLLATE NOCASE DEFAULT '',
        [Status          ]	// integer DEFAULT 1,
        [Branch          ]	// varchar(10) COLLATE NOCASE DEFAULT '',
        [ExpirationDate  ]	// datetime DEFAULT (CURRENT_TIMESTAMP),
        [MemberSince     ]	// datetime DEFAULT (CURRENT_TIMESTAMP),
        [ContactPerson   ]	// varchar(40) COLLATE NOCASE DEFAULT '',
        [Terms           ]	// integer NOT NULL DEFAULT 0,
        [Birthday        ]	// datetime DEFAULT (CURRENT_TIMESTAMP),
        [Mobile          ]	// varchar(20) COLLATE NOCASE DEFAULT '',
        [Business        ]	// varchar(10) COLLATE NOCASE DEFAULT '',
        [BusinessEmail   ]	// varchar(50) NOT NULL COLLATE NOCASE DEFAULT '',
        [Age             ]	// integer NOT NULL DEFAULT 0,
        [Gender          ]	// char(1) NOT NULL COLLATE NOCASE DEFAULT '',
        [Biometric       ]	// blob(5000)


    */
}
