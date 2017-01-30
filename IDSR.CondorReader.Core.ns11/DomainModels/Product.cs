using System;

namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class Product
    {
        public long        Id                      { get; set; }
        public string      Code                    { get; set; }
        public string      Description             { get; set; }
        public string      FieldA                  { get; set; }
        public string      FieldB                  { get; set; }
        public string      FieldC                  { get; set; }
        public string      FieldD                  { get; set; }
        public string      FieldE                  { get; set; }
        public string      Level1                  { get; set; }
        public string      Level2                  { get; set; }
        public string      Level3                  { get; set; }
        public string      FieldStyle              { get; set; }
        public string      ReportUoM               { get; set; }
        public decimal     ReportQty               { get; set; }
        public bool        Expirable               { get; set; }
        public bool        WithLotNo               { get; set; }
        public bool        WithSerialNo            { get; set; }
        public bool        Trackinventory          { get; set; }
        public bool        Inactive                { get; set; }
        public string      VendorCode              { get; set; }
        public decimal     MustReachForFree        { get; set; }
        public decimal     SellingArea             { get; set; }
        public decimal     StockRoom               { get; set; }
        public decimal     Damaged                 { get; set; }
        public decimal     Layaway                 { get; set; }
        public decimal     OnOrder                 { get; set; }
        public decimal     OnRequest               { get; set; }
        public decimal     OnAssembly              { get; set; }
        public decimal     SalesOrder              { get; set; }
        public DateTime?   LastSellingDate         { get; set; }
        public DateTime?   LastPurchaseDate        { get; set; }
        public decimal?    MinSAStock              { get; set; }
        public decimal?    MaxSAStock              { get; set; }
        public decimal?    MinSRStock              { get; set; }
        public decimal?    MaxSRStock              { get; set; }
        public DateTime?   LastDateModified        { get; set; }
        public decimal?    OrderCycle              { get; set; }
        public decimal?    ToDateFinishedSales     { get; set; }
        public bool        ShareWithBranch         { get; set; }
        public bool        POSOnLookup             { get; set; }
        public decimal     TotalUnitCostReceived   { get; set; }
        public decimal     TotalUnitQtyReceived    { get; set; }
        public string      UserName                { get; set; }
        public bool?       pVatable                { get; set; }
        public long?       pVatpercent             { get; set; }
        public string      ReportUOMSR             { get; set; }
        public decimal     ReportQtySR             { get; set; }
        public bool        Weighted                { get; set; }
        public string      ItemDetailsCode         { get; set; }
        public bool        OpenDepartment          { get; set; }
        public bool        IngredientAsDefaultCost { get; set; }
        public long        ProductType             { get; set; }
        public bool        TimeBased               { get; set; }
        public bool        Combo                   { get; set; }
        public decimal     ComputedAverageCost     { get; set; }

        public bool IsVatable => pVatable == true;
    }
}
