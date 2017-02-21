using System.Collections.Generic;
using System.Linq;

namespace IDSR.CondorReader.Core.ns11.SqlQueries
{
    public static class PurchaseOrdersSQL
    {
        public const string ParentQuery =
            @"SELECT * 
                FROM PurchaseOrder p";

        public const string LinesQuery =
            @"SELECT ln.* 
                FROM PurchaseOrderLine ln
           LEFT JOIN PurchaseOrder p
                  ON p.PurchaseOrderID = ln.PurchaseOrderID";


        public static string WHERE_PurchaseOrderID_IN(this string sqlQuery, IEnumerable<int> idsList)
        {
            var joind = string.Join(",", idsList.Select(x => $"'{x}'"));
            return $"{sqlQuery} WHERE p.PurchaseOrderID IN ({joind})";
        }


        //public static string WHERE_PostedDate_BETWEEN(this string sqlQuery, DateTime startDate, DateTime endDate, string dateFmt = "yyyy-MM-dd")
        //    => $@"{sqlQuery} WHERE p.PostedDate >= '{startDate.ToString(dateFmt)}'
        //                       AND p.PostedDate <  '{endDate.Date.AddDays(-1).ToString(dateFmt)}'";
    }
}
