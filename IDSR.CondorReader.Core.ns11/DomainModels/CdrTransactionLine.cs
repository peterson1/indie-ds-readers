using IDSR.CondorReader.Core.ns11.Converters;
using Repo2.Core.ns11.Extensions;
using Repo2.Core.ns11.Extensions.StringExtensions;
using System;
using System.Data;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class CdrTransactionLine
    {
        public CdrTransactionLine()
        {
        }


        public CdrTransactionLine(IDataRecord r, bool fromServer)
        {
            if (fromServer)
                FillFromSqlServer(r);
            else
                FillFromSQLite(r);
        }


        private void FillFromSqlServer(IDataRecord r)
        {
            LineID                 = (int)r.GetDecimal (0);// long      integer NOT NULL,
            TransactionNo          = r.GetInt32   (1);// long      integer NOT NULL DEFAULT 0,
            ProductID              = r.GetDouble  (2);// decimal   float DEFAULT 0,
            ProductCode            = r.GetString  (3);// string    varchar(20) COLLATE NOCASE DEFAULT '',
            Barcode                = r.GetString  (4);// string    varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
            Description            = r.GetString  (5);// string    varchar(40) NOT NULL COLLATE NOCASE DEFAULT '',
            UOM                    = r.GetString  (6);// string    varchar(6) COLLATE NOCASE DEFAULT '',
            Qty                    = r.GetDecimal (7);// decimal   numeric DEFAULT 0,
            Packing                = r.GetDecimal (8);// decimal   numeric DEFAULT 0,
            TotalQty               = r.GetDecimal (9);// decimal   numeric DEFAULT 0,
            AverageUnitCost        = r.GetDecimal (10);// decimal   numeric DEFAULT 0,
            Price                  = r.GetDecimal (11);// decimal   numeric DEFAULT 0,
            Discount               = r.GetDecimal (12);// decimal   numeric DEFAULT 0,
            Allowance              = r.GetDecimal (13);// decimal   numeric DEFAULT 0,
            AmountDiscounted       = r.GetDecimal (14);// decimal   numeric DEFAULT 0,
            ChargeDiscount         = r.GetDecimal (15);// decimal   numeric DEFAULT 0,
            ChargeAllowance        = r.GetDecimal (16);// decimal   numeric DEFAULT 0,
            ChargeAmountDiscounted = r.GetDecimal (17);// decimal   numeric DEFAULT 0,
            DiscountedPrice        = r.GetDecimal (18);// decimal   numeric DEFAULT 0,
            DiscountDescription    = r.IsDBNull(19) ? null : r.GetString  (19);// string    varchar(40) COLLATE NOCASE DEFAULT '',
            Extended               = r.GetDecimal (20);// decimal   numeric DEFAULT 0,
            ExtendedDescription    = r.GetString  (21);// string    varchar(20) COLLATE NOCASE DEFAULT '',
            Multiplier             = r.GetDouble  (22);// decimal   float DEFAULT 1,
            PriceModeCode          = r.GetString  (23);// string    varchar(2) COLLATE NOCASE DEFAULT '',
            Return                 = r.GetBoolean (24);// bool      bit NOT NULL DEFAULT 0,
            ReturnDescription      = r.ToText     (25);// string    varchar(6) COLLATE NOCASE DEFAULT '',
            ReturnRemarks          = r.ToText     (26);// string    varchar(100) COLLATE NOCASE DEFAULT '',
            OldTransactionNo       = r.ToLong     (27);// long      integer DEFAULT 0,
            OldTransactionDate     = r.ToDate     (28);// DateTime  datetime DEFAULT (CURRENT_TIMESTAMP),
            OldTransactionDiscount = r.GetDecimal (29);// decimal   numeric DEFAULT 0,
            OldTerminalNo          = r.ToText     (30);// string    varchar(10) COLLATE NOCASE DEFAULT '',
            Shift                  = r.GetInt32   (31);// int       integer NOT NULL DEFAULT 0,
            UserID                 = r.GetString  (32);// string    varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
            TerminalNo             = r.GetString  (33);// string    varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
            BranchCode             = r.GetString  (34);// string    varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
            LogDate                = r.ToDate     (35);// DateTime  datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
            DateTime               = r.ToDate     (36);// DateTime  datetime DEFAULT (CURRENT_TIMESTAMP),
            Voided                 = r.GetBoolean (37);// bool      bit NOT NULL DEFAULT 0,
            MustReachForFree       = r.GetDecimal (38);// decimal   numeric DEFAULT 0,
            Points                 = r.GetDecimal (39);// decimal   numeric NOT NULL DEFAULT 0,
            PointsPosted           = r.GetBoolean (40);// bool      bit NOT NULL DEFAULT 0,
            AmountSaved            = r.GetDecimal (41);// decimal   numeric NOT NULL DEFAULT 0,
            QtyReturned            = r.GetDecimal (42);// decimal   numeric NOT NULL DEFAULT 0,
            PriceOverride          = r.GetBoolean (43);// bool      bit NOT NULL DEFAULT 0,
            MarkDown               = r.GetBoolean (44);// bool      bit NOT NULL DEFAULT 0,
            SerialNo               = r.IsDBNull(45) ? null : r.GetString  (45);// string    varchar(40) COLLATE NOCASE DEFAULT '',
            PROMOPERSONID          = r.GetDecimal (46);// decimal   numeric DEFAULT 0,
            SONumber               = r.IsDBNull(47) ? null : r.GetString  (47);// string    varchar(10) COLLATE NOCASE DEFAULT '',
            TimeScanned            = r.ToDate_    (48);// DateTime? datetime,
            Layaway                = r.GetBoolean (49);// bool      bit DEFAULT 0,
            LayawayNumber          = (int?)r.ToLong_(50);// int?      integer,
            pVatable               = r.GetInt32   (51);// int       integer DEFAULT 0,
            pVatPercent            = r.GetInt32   (52);// int       integer DEFAULT 0,
            ChilledCharge          = r.GetBoolean (53);// bool      bit DEFAULT 0,
            Remarks                = r.IsDBNull(54) ? null : r.GetString(54);// string    varchar(30) COLLATE NOCASE DEFAULT '',
            Senior                 = r.GetBoolean (55);// bool      bit NOT NULL DEFAULT 0,
            discounttype1          = r.GetBoolean (56);// bool      bit NOT NULL DEFAULT 0,
            discounttype2          = r.GetBoolean (57);// bool      bit NOT NULL DEFAULT 0,
            discounttype3          = r.GetBoolean (58);// bool      bit NOT NULL DEFAULT 0,
            discounttype4          = r.GetBoolean (59);// bool      bit NOT NULL DEFAULT 0,
            discounttype5          = r.GetBoolean (60);// bool      bit NOT NULL DEFAULT 0,
            discounttype6          = r.GetBoolean (61);// bool      bit NOT NULL DEFAULT 0,
            discounttype7          = r.GetBoolean (62);// bool      bit NOT NULL DEFAULT 0,
            discounttype8          = r.GetBoolean (63);// bool      bit NOT NULL DEFAULT 0,
            discounttype9          = r.GetBoolean (64);// bool      bit NOT NULL DEFAULT 0,
            discounttype10         = r.GetBoolean (65);// bool      bit NOT NULL DEFAULT 0,
            Diplomat               = r.GetBoolean (66);// bool      bit NOT NULL DEFAULT 0,
            BonusPoints            = r.GetDecimal (67);// decimal   numeric NOT NULL DEFAULT 0,
            Tax                    = r.GetDecimal (68);// decimal   numeric NOT NULL DEFAULT 0,
            TaxID                  = r.GetInt32   (69);// int       integer DEFAULT 0,
            DateTimeStart          = r.ToDate_    (70);// DateTime? datetime,
            DateTimeEnd            = r.ToDate_    (71);// DateTime? datetime,
            ServiceCharge          = r.GetDecimal (72);// decimal   numeric NOT NULL DEFAULT 0

            ParsedBarCode          = Barcode.ToBarCode_();
        }





        private void FillFromSQLite(IDataRecord r)
        {
            LineID                 = r.GetInt64   (0);// long      integer NOT NULL,
            TransactionNo          = r.GetInt64   (1);// long      integer NOT NULL DEFAULT 0,
            ProductID              = r.GetDouble  (2);// decimal   float DEFAULT 0,
            ProductCode            = r.GetString  (3);// string    varchar(20) COLLATE NOCASE DEFAULT '',
            Barcode                = r.GetString  (4);// string    varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
            Description            = r.GetString  (5);// string    varchar(40) NOT NULL COLLATE NOCASE DEFAULT '',
            UOM                    = r.GetString  (6);// string    varchar(6) COLLATE NOCASE DEFAULT '',
            Qty                    = r.GetDecimal (7);// decimal   numeric DEFAULT 0,
            Packing                = r.GetDecimal (8);// decimal   numeric DEFAULT 0,
            TotalQty               = r.GetDecimal (9);// decimal   numeric DEFAULT 0,
            AverageUnitCost        = r.GetDecimal (10);// decimal   numeric DEFAULT 0,
            Price                  = r.GetDecimal (11);// decimal   numeric DEFAULT 0,
            Discount               = r.GetDecimal (12);// decimal   numeric DEFAULT 0,
            Allowance              = r.GetDecimal (13);// decimal   numeric DEFAULT 0,
            AmountDiscounted       = r.GetDecimal (14);// decimal   numeric DEFAULT 0,
            ChargeDiscount         = r.GetDecimal (15);// decimal   numeric DEFAULT 0,
            ChargeAllowance        = r.GetDecimal (16);// decimal   numeric DEFAULT 0,
            ChargeAmountDiscounted = r.GetDecimal (17);// decimal   numeric DEFAULT 0,
            DiscountedPrice        = r.GetDecimal (18);// decimal   numeric DEFAULT 0,
            DiscountDescription    = r.GetString  (19);// string    varchar(40) COLLATE NOCASE DEFAULT '',
            Extended               = r.GetDecimal (20);// decimal   numeric DEFAULT 0,
            ExtendedDescription    = r.GetString  (21);// string    varchar(20) COLLATE NOCASE DEFAULT '',
            Multiplier             = r.GetDouble  (22);// decimal   float DEFAULT 1,
            PriceModeCode          = r.GetString  (23);// string    varchar(2) COLLATE NOCASE DEFAULT '',
            Return                 = r.GetBoolean (24);// bool      bit NOT NULL DEFAULT 0,
            ReturnDescription      = r.ToText     (25);// string    varchar(6) COLLATE NOCASE DEFAULT '',
            ReturnRemarks          = r.ToText     (26);// string    varchar(100) COLLATE NOCASE DEFAULT '',
            OldTransactionNo       = r.ToLong     (27);// long      integer DEFAULT 0,
            OldTransactionDate     = r.ToDate     (28);// DateTime  datetime DEFAULT (CURRENT_TIMESTAMP),
            OldTransactionDiscount = r.GetDecimal (29);// decimal   numeric DEFAULT 0,
            OldTerminalNo          = r.ToText     (30);// string    varchar(10) COLLATE NOCASE DEFAULT '',
            Shift                  = (int)r.GetInt64(31);// int       integer NOT NULL DEFAULT 0,
            UserID                 = r.GetString  (32);// string    varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
            TerminalNo             = r.GetString  (33);// string    varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
            BranchCode             = r.GetString  (34);// string    varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
            LogDate                = r.ToDate     (35);// DateTime  datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
            DateTime               = r.ToDate     (36);// DateTime  datetime DEFAULT (CURRENT_TIMESTAMP),
            Voided                 = r.GetBoolean (37);// bool      bit NOT NULL DEFAULT 0,
            MustReachForFree       = r.GetDecimal (38);// decimal   numeric DEFAULT 0,
            Points                 = r.GetDecimal (39);// decimal   numeric NOT NULL DEFAULT 0,
            PointsPosted           = r.GetBoolean (40);// bool      bit NOT NULL DEFAULT 0,
            AmountSaved            = r.GetDecimal (41);// decimal   numeric NOT NULL DEFAULT 0,
            QtyReturned            = r.GetDecimal (42);// decimal   numeric NOT NULL DEFAULT 0,
            PriceOverride          = r.GetBoolean (43);// bool      bit NOT NULL DEFAULT 0,
            MarkDown               = r.GetBoolean (44);// bool      bit NOT NULL DEFAULT 0,
            SerialNo               = r.GetString  (45);// string    varchar(40) COLLATE NOCASE DEFAULT '',
            PROMOPERSONID          = r.GetDecimal (46);// decimal   numeric DEFAULT 0,
            SONumber               = r.GetString  (47);// string    varchar(10) COLLATE NOCASE DEFAULT '',
            TimeScanned            = r.ToDate_    (48);// DateTime? datetime,
            Layaway                = r.GetBoolean (49);// bool      bit DEFAULT 0,
            LayawayNumber          = (int?)r.ToLong_(50);// int?      integer,
            pVatable               = (int)r.GetInt64(51);// int       integer DEFAULT 0,
            pVatPercent            = (int)r.GetInt64(52);// int       integer DEFAULT 0,
            ChilledCharge          = r.GetBoolean (53);// bool      bit DEFAULT 0,
            Remarks                = r.ToText     (54);// string    varchar(30) COLLATE NOCASE DEFAULT '',
            Senior                 = r.GetBoolean (55);// bool      bit NOT NULL DEFAULT 0,
            discounttype1          = r.GetBoolean (56);// bool      bit NOT NULL DEFAULT 0,
            discounttype2          = r.GetBoolean (57);// bool      bit NOT NULL DEFAULT 0,
            discounttype3          = r.GetBoolean (58);// bool      bit NOT NULL DEFAULT 0,
            discounttype4          = r.GetBoolean (59);// bool      bit NOT NULL DEFAULT 0,
            discounttype5          = r.GetBoolean (60);// bool      bit NOT NULL DEFAULT 0,
            discounttype6          = r.GetBoolean (61);// bool      bit NOT NULL DEFAULT 0,
            discounttype7          = r.GetBoolean (62);// bool      bit NOT NULL DEFAULT 0,
            discounttype8          = r.GetBoolean (63);// bool      bit NOT NULL DEFAULT 0,
            discounttype9          = r.GetBoolean (64);// bool      bit NOT NULL DEFAULT 0,
            discounttype10         = r.GetBoolean (65);// bool      bit NOT NULL DEFAULT 0,
            Diplomat               = r.GetBoolean (66);// bool      bit NOT NULL DEFAULT 0,
            BonusPoints            = r.GetDecimal (67);// decimal   numeric NOT NULL DEFAULT 0,
            Tax                    = r.GetDecimal (68);// decimal   numeric NOT NULL DEFAULT 0,
            TaxID                  = (int)r.GetInt64(69);// int       integer DEFAULT 0,
            DateTimeStart          = r.ToDate_    (70);// DateTime? datetime,
            DateTimeEnd            = r.ToDate_    (71);// DateTime? datetime,
            ServiceCharge          = r.GetDecimal (72);// decimal   numeric NOT NULL DEFAULT 0

            ParsedBarCode          = Barcode.ToBarCode_();
        }

        public long        LineID                 { get; set; }// integer NOT NULL,
        public long        TransactionNo          { get; set; }// integer NOT NULL DEFAULT 0,
        public double      ProductID              { get; set; }// float DEFAULT 0,
        public string      ProductCode            { get; set; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public string      Barcode                { get; set; }// varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
        public string      Description            { get; set; }// varchar(40) NOT NULL COLLATE NOCASE DEFAULT '',
        public string      UOM                    { get; set; }// varchar(6) COLLATE NOCASE DEFAULT '',
        public decimal     Qty                    { get; set; }// numeric DEFAULT 0,
        public decimal     Packing                { get; set; }// numeric DEFAULT 0,
        public decimal     TotalQty               { get; set; }// numeric DEFAULT 0,
        public decimal     AverageUnitCost        { get; set; }// numeric DEFAULT 0,
        public decimal     Price                  { get; set; }// numeric DEFAULT 0,
        public decimal     Discount               { get; set; }// numeric DEFAULT 0,
        public decimal     Allowance              { get; set; }// numeric DEFAULT 0,
        public decimal     AmountDiscounted       { get; set; }// numeric DEFAULT 0,
        public decimal     ChargeDiscount         { get; set; }// numeric DEFAULT 0,
        public decimal     ChargeAllowance        { get; set; }// numeric DEFAULT 0,
        public decimal     ChargeAmountDiscounted { get; set; }// numeric DEFAULT 0,
        public decimal     DiscountedPrice        { get; set; }// numeric DEFAULT 0,
        public string      DiscountDescription    { get; set; }// varchar(40) COLLATE NOCASE DEFAULT '',
        public decimal     Extended               { get; set; }// numeric DEFAULT 0,
        public string      ExtendedDescription    { get; set; }// varchar(20) COLLATE NOCASE DEFAULT '',
        public double      Multiplier             { get; set; }// float DEFAULT 1,
        public string      PriceModeCode          { get; set; }// varchar(2) COLLATE NOCASE DEFAULT '',
        public bool        Return                 { get; set; }// bit NOT NULL DEFAULT 0,
        public string      ReturnDescription      { get; set; }// varchar(6) COLLATE NOCASE DEFAULT '',
        public string      ReturnRemarks          { get; set; }// varchar(100) COLLATE NOCASE DEFAULT '',
        public long        OldTransactionNo       { get; set; }// integer DEFAULT 0,
        public DateTime    OldTransactionDate     { get; set; }// datetime DEFAULT (CURRENT_TIMESTAMP),
        public decimal     OldTransactionDiscount { get; set; }// numeric DEFAULT 0,
        public string      OldTerminalNo          { get; set; }// varchar(10) COLLATE NOCASE DEFAULT '',
        public int         Shift                  { get; set; }// integer NOT NULL DEFAULT 0,
        public string      UserID                 { get; set; }// varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
        public string      TerminalNo             { get; set; }// varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
        public string      BranchCode             { get; set; }// varchar(10) NOT NULL COLLATE NOCASE DEFAULT '',
        public DateTime    LogDate                { get; set; }// datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        public DateTime    DateTime               { get; set; }// datetime DEFAULT (CURRENT_TIMESTAMP),
        public bool        Voided                 { get; set; }// bit NOT NULL DEFAULT 0,
        public decimal     MustReachForFree       { get; set; }// numeric DEFAULT 0,
        public decimal     Points                 { get; set; }// numeric NOT NULL DEFAULT 0,
        public bool        PointsPosted           { get; set; }// bit NOT NULL DEFAULT 0,
        public decimal     AmountSaved            { get; set; }// numeric NOT NULL DEFAULT 0,
        public decimal     QtyReturned            { get; set; }// numeric NOT NULL DEFAULT 0,
        public bool        PriceOverride          { get; set; }// bit NOT NULL DEFAULT 0,
        public bool        MarkDown               { get; set; }// bit NOT NULL DEFAULT 0,
        public string      SerialNo               { get; set; }// varchar(40) COLLATE NOCASE DEFAULT '',
        public decimal     PROMOPERSONID          { get; set; }// numeric DEFAULT 0,
        public string      SONumber               { get; set; }// varchar(10) COLLATE NOCASE DEFAULT '',
        public DateTime?   TimeScanned            { get; set; }// datetime,
        public bool        Layaway                { get; set; }// bit DEFAULT 0,
        public int?        LayawayNumber          { get; set; }// integer,
        public int         pVatable               { get; set; }// integer DEFAULT 0,
        public int         pVatPercent            { get; set; }// integer DEFAULT 0,
        public bool        ChilledCharge          { get; set; }// bit DEFAULT 0,
        public string      Remarks                { get; set; }// varchar(30) COLLATE NOCASE DEFAULT '',
        public bool        Senior                 { get; set; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype1          { get; set; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype2          { get; set; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype3          { get; set; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype4          { get; set; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype5          { get; set; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype6          { get; set; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype7          { get; set; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype8          { get; set; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype9          { get; set; }// bit NOT NULL DEFAULT 0,
        public bool        discounttype10         { get; set; }// bit NOT NULL DEFAULT 0,
        public bool        Diplomat               { get; set; }// bit NOT NULL DEFAULT 0,
        public decimal     BonusPoints            { get; set; }// numeric NOT NULL DEFAULT 0,
        public decimal     Tax                    { get; set; }// numeric NOT NULL DEFAULT 0,
        public int         TaxID                  { get; set; }// integer DEFAULT 0,
        public DateTime?   DateTimeStart          { get; set; }// datetime,
        public DateTime?   DateTimeEnd            { get; set; }// datetime,
        public decimal     ServiceCharge          { get; set; }// numeric NOT NULL DEFAULT 0

        public ulong?      ParsedBarCode          { get; set; }


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
