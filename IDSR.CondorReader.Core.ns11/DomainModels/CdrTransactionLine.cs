using IDSR.CondorReader.Core.ns11.Converters;
using Repo2.Core.ns11.Extensions;
using Repo2.Core.ns11.Extensions.StringExtensions;
using System;
using System.Data;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrTransactionLine
    {
        public CdrTransactionLine(IDataRecord r)
        {
            LineID                 = r.ToLong    ( 0);// long      integer NOT NULL,
            TransactionNo          = r.ToLong    ( 1);// long      integer NOT NULL DEFAULT 0,
            ProductID              = r.ToDouble  ( 2);// decimal   float DEFAULT 0,
            ProductCode            = r.ToText    ( 3);// string    varchar(20) COLLATE NOCASE DEFAULT '',
            Barcode                = r.ToText    ( 4);// string    varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
            Description            = r.ToText    ( 5);// string    varchar(40) NOT NULL COLLATE NOCASE DEFAULT '',
            UOM                    = r.ToText    ( 6);// string    varchar(6) COLLATE NOCASE DEFAULT '',
            Qty                    = r.ToDecimal ( 7);// decimal   numeric DEFAULT 0,
            Packing                = r.ToDecimal ( 8);// decimal   numeric DEFAULT 0,
            TotalQty               = r.ToDecimal ( 9);// decimal   numeric DEFAULT 0,
            AverageUnitCost        = r.ToDecimal (10);// decimal   numeric DEFAULT 0,
            Price                  = r.ToDecimal (11);// decimal   numeric DEFAULT 0,
            Discount               = r.ToDecimal (12);// decimal   numeric DEFAULT 0,
            Allowance              = r.ToDecimal (13);// decimal   numeric DEFAULT 0,
            AmountDiscounted       = r.ToDecimal (14);// decimal   numeric DEFAULT 0,
            ChargeDiscount         = r.ToDecimal (15);// decimal   numeric DEFAULT 0,
            ChargeAllowance        = r.ToDecimal (16);// decimal   numeric DEFAULT 0,
            ChargeAmountDiscounted = r.ToDecimal (17);// decimal   numeric DEFAULT 0,
            DiscountedPrice        = r.ToDecimal (18);// decimal   numeric DEFAULT 0,
            DiscountDescription    = r.ToText    (19);// string    varchar(40) COLLATE NOCASE DEFAULT '',
            Extended               = r.ToDecimal (20);// decimal   numeric DEFAULT 0,
            ExtendedDescription    = r.ToText    (21);// string    varchar(20) COLLATE NOCASE DEFAULT '',
            Multiplier             = r.ToDouble  (22);// decimal   float DEFAULT 1,
            PriceModeCode          = r.ToText    (23);// string    varchar(2) COLLATE NOCASE DEFAULT '',
            Return                 = r.ToBool    (24);// bool      bit NOT NULL DEFAULT 0,
            ReturnDescription      = r.ToText    (25);// string    varchar(6) COLLATE NOCASE DEFAULT '',
            ReturnRemarks          = r.ToText    (26);// string    varchar(100) COLLATE NOCASE DEFAULT '',
            OldTransactionNo       = r.ToLong    (27);// long      integer DEFAULT 0,
            OldTransactionDate     = r.ToDate    (28);// DateTime  datetime DEFAULT (CURRENT_TIMESTAMP),
            OldTransactionDiscount = r.ToDecimal (29);// decimal   numeric DEFAULT 0,
            OldTerminalNo          = r.ToText    (30);// string    varchar(10) COLLATE NOCASE DEFAULT '',
            Shift                  = (int)r.ToLong  (31);// int       integer NOT NULL DEFAULT 0,
            UserID                 = r.ToText    (32);// string    varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
            TerminalNo             = r.ToText    (33);// string    varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
            BranchCode             = r.ToText    (34);// string    varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
            LogDate                = r.ToDate    (35);// DateTime  datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
            DateTime               = r.ToDate    (36);// DateTime  datetime DEFAULT (CURRENT_TIMESTAMP),
            Voided                 = r.ToBool    (37);// bool      bit NOT NULL DEFAULT 0,
            MustReachForFree       = r.ToDecimal (38);// decimal   numeric DEFAULT 0,
            Points                 = r.ToDecimal (39);// decimal   numeric NOT NULL DEFAULT 0,
            PointsPosted           = r.ToBool    (40);// bool      bit NOT NULL DEFAULT 0,
            AmountSaved            = r.ToDecimal (41);// decimal   numeric NOT NULL DEFAULT 0,
            QtyReturned            = r.ToDecimal (42);// decimal   numeric NOT NULL DEFAULT 0,
            PriceOverride          = r.ToBool    (43);// bool      bit NOT NULL DEFAULT 0,
            MarkDown               = r.ToBool    (44);// bool      bit NOT NULL DEFAULT 0,
            SerialNo               = r.ToText    (45);// string    varchar(40) COLLATE NOCASE DEFAULT '',
            PROMOPERSONID          = r.ToDecimal (46);// decimal   numeric DEFAULT 0,
            SONumber               = r.ToText    (47);// string    varchar(10) COLLATE NOCASE DEFAULT '',
            TimeScanned            = r.ToDate_   (48);// DateTime? datetime,
            Layaway                = r.ToBool    (49);// bool      bit DEFAULT 0,
            LayawayNumber          = (int?)r.ToLong_    (50);// int?      integer,
            pVatable               = (int)r.ToLong  (51);// int       integer DEFAULT 0,
            pVatPercent            = (int)r.ToLong  (52);// int       integer DEFAULT 0,
            ChilledCharge          = r.ToBool    (53);// bool      bit DEFAULT 0,
            Remarks                = r.ToText    (54);// string    varchar(30) COLLATE NOCASE DEFAULT '',
            Senior                 = r.ToBool    (55);// bool      bit NOT NULL DEFAULT 0,
            discounttype1          = r.ToBool    (56);// bool      bit NOT NULL DEFAULT 0,
            discounttype2          = r.ToBool    (57);// bool      bit NOT NULL DEFAULT 0,
            discounttype3          = r.ToBool    (58);// bool      bit NOT NULL DEFAULT 0,
            discounttype4          = r.ToBool    (59);// bool      bit NOT NULL DEFAULT 0,
            discounttype5          = r.ToBool    (60);// bool      bit NOT NULL DEFAULT 0,
            discounttype6          = r.ToBool    (61);// bool      bit NOT NULL DEFAULT 0,
            discounttype7          = r.ToBool    (62);// bool      bit NOT NULL DEFAULT 0,
            discounttype8          = r.ToBool    (63);// bool      bit NOT NULL DEFAULT 0,
            discounttype9          = r.ToBool    (64);// bool      bit NOT NULL DEFAULT 0,
            discounttype10         = r.ToBool    (65);// bool      bit NOT NULL DEFAULT 0,
            Diplomat               = r.ToBool    (66);// bool      bit NOT NULL DEFAULT 0,
            BonusPoints            = r.ToDecimal (67);// decimal   numeric NOT NULL DEFAULT 0,
            Tax                    = r.ToDecimal (68);// decimal   numeric NOT NULL DEFAULT 0,
            TaxID                  = (int)r.ToLong(69);// int       integer DEFAULT 0,
            DateTimeStart          = r.ToDate_   (70);// DateTime? datetime,
            DateTimeEnd            = r.ToDate_   (71);// DateTime? datetime,
            ServiceCharge          = r.ToDecimal (72);// decimal   numeric NOT NULL DEFAULT 0

            ParsedBarCode          = Barcode.ToBarCode_();
        }

        public long        LineID                 { get; }// integer NOT NULL,
        public long        TransactionNo          { get; }// integer NOT NULL DEFAULT 0,
        public double      ProductID              { get; }// float DEFAULT 0,
        public string      ProductCode            { get; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public string      Barcode                { get; }// varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
        public string      Description            { get; }// varchar(40) NOT NULL COLLATE NOCASE DEFAULT '',
        public string      UOM                    { get; }// varchar(6) COLLATE NOCASE DEFAULT '',
        public decimal     Qty                    { get; }// numeric DEFAULT 0,
        public decimal     Packing                { get; }// numeric DEFAULT 0,
        public decimal     TotalQty               { get; }// numeric DEFAULT 0,
        public decimal     AverageUnitCost        { get; }// numeric DEFAULT 0,
        public decimal     Price                  { get; }// numeric DEFAULT 0,
        public decimal     Discount               { get; }// numeric DEFAULT 0,
        public decimal     Allowance              { get; }// numeric DEFAULT 0,
        public decimal     AmountDiscounted       { get; }// numeric DEFAULT 0,
        public decimal     ChargeDiscount         { get; }// numeric DEFAULT 0,
        public decimal     ChargeAllowance        { get; }// numeric DEFAULT 0,
        public decimal     ChargeAmountDiscounted { get; }// numeric DEFAULT 0,
        public decimal     DiscountedPrice        { get; }// numeric DEFAULT 0,
        public string      DiscountDescription    { get; }// varchar(40) COLLATE NOCASE DEFAULT '',
        public decimal     Extended               { get; }// numeric DEFAULT 0,
        public string      ExtendedDescription    { get; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public double      Multiplier             { get; }// float DEFAULT 1,
        public string      PriceModeCode          { get; }// varchar(2) COLLATE NOCASE DEFAULT '',
        public bool        Return                 { get; }// bit NOT NULL DEFAULT 0,
        public string      ReturnDescription      { get; }// varchar(6) COLLATE NOCASE DEFAULT '',
        public string      ReturnRemarks          { get; }// varchar(100) COLLATE NOCASE DEFAULT '',
        public long        OldTransactionNo       { get; }// integer DEFAULT 0,
        public DateTime    OldTransactionDate     { get; }// datetime DEFAULT (CURRENT_TIMESTAMP),
        public decimal     OldTransactionDiscount { get; }// numeric DEFAULT 0,
        public string      OldTerminalNo          { get; }// varchar(10) COLLATE NOCASE DEFAULT '',
        public int         Shift                  { get; }// integer NOT NULL DEFAULT 0,
        public string      UserID                 { get; }// varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
        public string      TerminalNo             { get; }// varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
        public string      BranchCode             { get; }// varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
        public DateTime    LogDate                { get; }// datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        public DateTime    DateTime               { get; }// datetime DEFAULT (CURRENT_TIMESTAMP),
        public bool        Voided                 { get; }// bit NOT NULL DEFAULT 0,
        public decimal     MustReachForFree       { get; }// numeric DEFAULT 0,
        public decimal     Points                 { get; }// numeric NOT NULL DEFAULT 0,
        public bool        PointsPosted           { get; }// bit NOT NULL DEFAULT 0,
        public decimal     AmountSaved            { get; }// numeric NOT NULL DEFAULT 0,
        public decimal     QtyReturned            { get; }// numeric NOT NULL DEFAULT 0,
        public bool        PriceOverride          { get; }// bit NOT NULL DEFAULT 0,
        public bool        MarkDown               { get; }// bit NOT NULL DEFAULT 0,
        public string      SerialNo               { get; }// varchar(40) COLLATE NOCASE DEFAULT '',
        public decimal     PROMOPERSONID          { get; }// numeric DEFAULT 0,
        public string      SONumber               { get; }// varchar(10) COLLATE NOCASE DEFAULT '',
        public DateTime?   TimeScanned            { get; }// datetime,
        public bool        Layaway                { get; }// bit DEFAULT 0,
        public int?        LayawayNumber          { get; }// integer,
        public int         pVatable               { get; }// integer DEFAULT 0,
        public int         pVatPercent            { get; }// integer DEFAULT 0,
        public bool        ChilledCharge          { get; }// bit DEFAULT 0,
        public string      Remarks                { get; }// varchar(30) COLLATE NOCASE DEFAULT '',
        public bool        Senior                 { get; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype1          { get; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype2          { get; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype3          { get; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype4          { get; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype5          { get; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype6          { get; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype7          { get; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype8          { get; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype9          { get; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype10         { get; }// bit NOT NULL DEFAULT 0,
        public bool        Diplomat               { get; }// bit NOT NULL DEFAULT 0,
        public decimal     BonusPoints            { get; }// numeric NOT NULL DEFAULT 0,
        public decimal     Tax                    { get; }// numeric NOT NULL DEFAULT 0,
        public int         TaxID                  { get; }// integer DEFAULT 0,
        public DateTime?   DateTimeStart          { get; }// datetime,
        public DateTime?   DateTimeEnd            { get; }// datetime,
        public decimal     ServiceCharge          { get; }// numeric NOT NULL DEFAULT 0

        public ulong?      ParsedBarCode          { get; }


        public override string ToString()
            => $"LineID                \t\t:  {LineID                }{L.f}"
             + $"TransactionNo         \t\t:  {TransactionNo         }{L.f}"
             + $"ProductID             \t\t:  {ProductID             }{L.f}"
             + $"ProductCode           \t\t:  {ProductCode           }{L.f}"
             + $"Barcode               \t\t:  {Barcode               }{L.f}"
             + $"Description           \t\t:  {Description           }{L.f}"
             + $"UOM                   \t\t:  {UOM                   }{L.f}"
             + $"Qty                   \t\t:  {Qty                   }{L.f}"
             + $"Packing               \t\t:  {Packing               }{L.f}"
             + $"TotalQty              \t\t:  {TotalQty              }{L.f}"
             + $"AverageUnitCost       \t\t:  {AverageUnitCost       }{L.f}"
             + $"Price                 \t\t:  {Price                 }{L.f}"
             + $"Discount              \t\t:  {Discount              }{L.f}"
             + $"Allowance             \t\t:  {Allowance             }{L.f}"
             + $"AmountDiscounted      \t\t:  {AmountDiscounted      }{L.f}"
             + $"ChargeDiscount        \t\t:  {ChargeDiscount        }{L.f}"
             + $"ChargeAllowance       \t\t:  {ChargeAllowance       }{L.f}"
             + $"ChargeAmountDiscounted\t\t:  {ChargeAmountDiscounted}{L.f}"
             + $"DiscountedPrice       \t\t:  {DiscountedPrice       }{L.f}"
             + $"DiscountDescription   \t\t:  {DiscountDescription   }{L.f}"
             + $"Extended              \t\t:  {Extended              }{L.f}"
             + $"ExtendedDescription   \t\t:  {ExtendedDescription   }{L.f}"
             + $"Multiplier            \t\t:  {Multiplier            }{L.f}"
             + $"PriceModeCode         \t\t:  {PriceModeCode         }{L.f}"
             + $"Return                \t\t:  {Return                }{L.f}"
             + $"ReturnDescription     \t\t:  {ReturnDescription     }{L.f}"
             + $"ReturnRemarks         \t\t:  {ReturnRemarks         }{L.f}"
             + $"OldTransactionNo      \t\t:  {OldTransactionNo      }{L.f}"
             + $"OldTransactionDate    \t\t:  {OldTransactionDate    }{L.f}"
             + $"OldTransactionDiscount\t\t:  {OldTransactionDiscount}{L.f}"
             + $"OldTerminalNo         \t\t:  {OldTerminalNo         }{L.f}"
             + $"Shift                 \t\t:  {Shift                 }{L.f}"
             + $"UserID                \t\t:  {UserID                }{L.f}"
             + $"TerminalNo            \t\t:  {TerminalNo            }{L.f}"
             + $"BranchCode            \t\t:  {BranchCode            }{L.f}"
             + $"LogDate               \t\t:  {LogDate               }{L.f}"
             + $"DateTime              \t\t:  {DateTime              }{L.f}"
             + $"Voided                \t\t:  {Voided                }{L.f}"
             + $"MustReachForFree      \t\t:  {MustReachForFree      }{L.f}"
             + $"Points                \t\t:  {Points                }{L.f}"
             + $"PointsPosted          \t\t:  {PointsPosted          }{L.f}"
             + $"AmountSaved           \t\t:  {AmountSaved           }{L.f}"
             + $"QtyReturned           \t\t:  {QtyReturned           }{L.f}"
             + $"PriceOverride         \t\t:  {PriceOverride         }{L.f}"
             + $"MarkDown              \t\t:  {MarkDown              }{L.f}"
             + $"SerialNo              \t\t:  {SerialNo              }{L.f}"
             + $"PROMOPERSONID         \t\t:  {PROMOPERSONID         }{L.f}"
             + $"SONumber              \t\t:  {SONumber              }{L.f}"
             + $"TimeScanned           \t\t:  {TimeScanned           }{L.f}"
             + $"Layaway               \t\t:  {Layaway               }{L.f}"
             + $"LayawayNumber         \t\t:  {LayawayNumber         }{L.f}"
             + $"pVatable              \t\t:  {pVatable              }{L.f}"
             + $"pVatPercent           \t\t:  {pVatPercent           }{L.f}"
             + $"ChilledCharge         \t\t:  {ChilledCharge         }{L.f}"
             + $"Remarks               \t\t:  {Remarks               }{L.f}"
             + $"Senior                \t\t:  {Senior                }{L.f}"
             + $"discounttype1         \t\t:  {discounttype1         }{L.f}"
             + $"discounttype2         \t\t:  {discounttype2         }{L.f}"
             + $"discounttype3         \t\t:  {discounttype3         }{L.f}"
             + $"discounttype4         \t\t:  {discounttype4         }{L.f}"
             + $"discounttype5         \t\t:  {discounttype5         }{L.f}"
             + $"discounttype6         \t\t:  {discounttype6         }{L.f}"
             + $"discounttype7         \t\t:  {discounttype7         }{L.f}"
             + $"discounttype8         \t\t:  {discounttype8         }{L.f}"
             + $"discounttype9         \t\t:  {discounttype9         }{L.f}"
             + $"discounttype10        \t\t:  {discounttype10        }{L.f}"
             + $"Diplomat              \t\t:  {Diplomat              }{L.f}"
             + $"BonusPoints           \t\t:  {BonusPoints           }{L.f}"
             + $"Tax                   \t\t:  {Tax                   }{L.f}"
             + $"TaxID                 \t\t:  {TaxID                 }{L.f}"
             + $"DateTimeStart         \t\t:  {DateTimeStart         }{L.f}"
             + $"DateTimeEnd           \t\t:  {DateTimeEnd           }{L.f}"
             + $"ServiceCharge         \t\t:  {ServiceCharge         }{L.f}"
             + $"ParsedBarCode         \t\t:  {ParsedBarCode         }";
    }
}

/*
CREATE TABLE [FinishedSales] (
    [LineID                ]	integer NOT NULL,
    [TransactionNo         ]	integer NOT NULL DEFAULT 0,
    [ProductID             ]	float DEFAULT 0,
    [ProductCode           ]	varchar(20) COLLATE NOCASE DEFAULT '',
    [Barcode               ]	varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
    [Description           ]	varchar(40) NOT NULL COLLATE NOCASE DEFAULT '',
    [UOM                   ]	varchar(6) COLLATE NOCASE DEFAULT '',
    [Qty                   ]	numeric DEFAULT 0,
    [Packing               ]	numeric DEFAULT 0,
    [TotalQty              ]	numeric DEFAULT 0,
    [AverageUnitCost       ]	numeric DEFAULT 0,
    [Price                 ]	numeric DEFAULT 0,
    [Discount              ]	numeric DEFAULT 0,
    [Allowance             ]	numeric DEFAULT 0,
    [AmountDiscounted      ]	numeric DEFAULT 0,
    [ChargeDiscount        ]	numeric DEFAULT 0,
    [ChargeAllowance       ]	numeric DEFAULT 0,
    [ChargeAmountDiscounted]	numeric DEFAULT 0,
    [DiscountedPrice       ]	numeric DEFAULT 0,
    [DiscountDescription   ]	varchar(40) COLLATE NOCASE DEFAULT '',
    [Extended              ]	numeric DEFAULT 0,
    [ExtendedDescription   ]	varchar(20) COLLATE NOCASE DEFAULT '',
    [Multiplier            ]	float DEFAULT 1,
    [PriceModeCode         ]	varchar(2) COLLATE NOCASE DEFAULT '',
    [Return                ]	bit NOT NULL DEFAULT 0,
    [ReturnDescription     ]	varchar(6) COLLATE NOCASE DEFAULT '',
    [ReturnRemarks         ]	varchar(100) COLLATE NOCASE DEFAULT '',
    [OldTransactionNo      ]	integer DEFAULT 0,
    [OldTransactionDate    ]	datetime DEFAULT (CURRENT_TIMESTAMP),
    [OldTransactionDiscount]	numeric DEFAULT 0,
    [OldTerminalNo         ]	varchar(10) COLLATE NOCASE DEFAULT '',
    [Shift                 ]	integer NOT NULL DEFAULT 0,
    [UserID                ]	varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
    [TerminalNo            ]	varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
    [BranchCode            ]	varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
    [LogDate               ]	datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    [DateTime              ]	datetime DEFAULT (CURRENT_TIMESTAMP),
    [Voided                ]	bit NOT NULL DEFAULT 0,
    [MustReachForFree      ]	numeric DEFAULT 0,
    [Points                ]	numeric NOT NULL DEFAULT 0,
    [PointsPosted          ]	bit NOT NULL DEFAULT 0,
    [AmountSaved           ]	numeric NOT NULL DEFAULT 0,
    [QtyReturned           ]	numeric NOT NULL DEFAULT 0,
    [PriceOverride         ]	bit NOT NULL DEFAULT 0,
    [MarkDown              ]	bit NOT NULL DEFAULT 0,
    [SerialNo              ]	varchar(40) COLLATE NOCASE DEFAULT '',
    [PROMOPERSONID         ]	numeric DEFAULT 0,
    [SONumber              ]	varchar(10) COLLATE NOCASE DEFAULT '',
    [TimeScanned           ]	datetime,
    [Layaway               ]	bit DEFAULT 0,
    [LayawayNumber         ]	integer,
    [pVatable              ]	integer DEFAULT 0,
    [pVatPercent           ]	integer DEFAULT 0,
    [ChilledCharge         ]	bit DEFAULT 0,
    [Remarks               ]	varchar(30) COLLATE NOCASE DEFAULT '',
    [Senior                ]	bit NOT NULL DEFAULT 0,
    [discounttype1         ]	bit NOT NULL DEFAULT 0,
    [discounttype2         ]	bit NOT NULL DEFAULT 0,
    [discounttype3         ]	bit NOT NULL DEFAULT 0,
    [discounttype4         ]	bit NOT NULL DEFAULT 0,
    [discounttype5         ]	bit NOT NULL DEFAULT 0,
    [discounttype6         ]	bit NOT NULL DEFAULT 0,
    [discounttype7         ]	bit NOT NULL DEFAULT 0,
    [discounttype8         ]	bit NOT NULL DEFAULT 0,
    [discounttype9         ]	bit NOT NULL DEFAULT 0,
    [discounttype10        ]	bit NOT NULL DEFAULT 0,
    [Diplomat              ]	bit NOT NULL DEFAULT 0,
    [BonusPoints           ]	numeric NOT NULL DEFAULT 0,
    [Tax                   ]	numeric NOT NULL DEFAULT 0,
    [TaxID                 ]	integer DEFAULT 0,
    [DateTimeStart         ]	datetime,
    [DateTimeEnd           ]	datetime,
    [ServiceCharge         ]	numeric NOT NULL DEFAULT 0
);
 
*/
