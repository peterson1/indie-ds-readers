using System;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class Vendor
    {
        public string    Code                  { get; set; }
        public string    Description           { get; set; }
        public string    Address               { get; set; }
        public string    City                  { get; set; }
        public string    ZipCode               { get; set; }
        public string    Country               { get; set; }
        public string    Fax                   { get; set; }
        public string    Email                 { get; set; }
        public string    Phone                 { get; set; }
        public string    Contactperson         { get; set; }
        public decimal   TermId                { get; set; }
        public long?     DaysToDeliver         { get; set; }
        public string    TradeDiscount         { get; set; }
        public string    CashDiscount          { get; set; }
        public long?     Terms                 { get; set; }
        public bool      IncludeLineDiscounts  { get; set; }
        public string    DiscountCode1         { get; set; }
        public string    DiscountCode2         { get; set; }
        public string    DiscountCode3         { get; set; }
        public decimal   Discount1             { get; set; }
        public decimal   Discount2             { get; set; }
        public decimal   Discount3             { get; set; }
        public long?     DaysToSum             { get; set; }
        public long?     ReorderMultiplier     { get; set; }
        public string    Remarks               { get; set; }
        public bool      ShareWithBranch       { get; set; }
        public bool      Consignor             { get; set; }
        public DateTime  LastDateModified      { get; set; }
        public string    TIN                   { get; set; }
        public string    Cluster               { get; set; }
        public decimal   CeilingLimit          { get; set; }
        public decimal   CeilingCounter        { get; set; }
    }
}
