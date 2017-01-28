namespace IDSR.CondorReader.Core.ns11.DomainModels
{
    public class Product
    {
        public long    Id             { get; set; }
        public string  Code           { get; set; }
        public string  Description    { get; set; }
        public string  FieldA         { get; set; }
        public string  FieldB         { get; set; }
        public string  FieldC         { get; set; }
        public string  FieldD         { get; set; }
        public string  FieldE         { get; set; }
        public string  Level1         { get; set; }
        public string  Level2         { get; set; }
        public string  Level3         { get; set; }
        public string  FieldStyle     { get; set; }
        public string  ReportUoM      { get; set; }
        public decimal ReportQty      { get; set; }
        public bool    Expirable      { get; set; }
        public bool    WithLotNo      { get; set; }
        public bool    WithSerialNo   { get; set; }
        public bool    Trackinventory { get; set; }
        public bool    Inactive       { get; set; }
    }
}
