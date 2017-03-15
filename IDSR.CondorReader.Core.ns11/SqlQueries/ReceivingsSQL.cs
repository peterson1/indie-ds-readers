namespace IDSR.CondorReader.Core.ns11.SqlQueries
{
    public static class ReceivingsSQL
    {
        public const string ParentQuery = 
            @"SELECT * 
                FROM Receiving r";


        public const string LinesQuery =
            @"SELECT ln.* 
                FROM ReceivingLine ln
           LEFT JOIN Receiving r
                  ON r.ReceivingID = ln.ReceivingID";
    }
}
