using System.Collections.Generic;
using System.Linq;

namespace IDSR.CondorReader.Core.ns11.SqlQueries
{
    public static class MovementsSQL
    {
        public const string ParentQuery =
            @"SELECT * 
                FROM Movements p";

        public const string LinesQuery =
            @"SELECT ln.* 
                FROM MovementLine ln
           LEFT JOIN Movements p
                  ON p.MovementID = ln.MovementID";


        public static string WHERE_MovementCode_IS(this string sqlQuery, string mvtCode)
            => $"{sqlQuery} WHERE p.MovementCode = '{mvtCode}'";


        public static string AND_StatusDescription_IS(this string sqlQuery, string statusDesc)
            => $"{sqlQuery} AND p.StatusDescription = '{statusDesc}'";


        public static string AND_VendorCode_IN(this string sqlQuery, IEnumerable<string> vendorCodes)
        {
            var joind = string.Join(",", vendorCodes.Select(x => $"'{x}'"));
            return $"{sqlQuery} AND p.VendorCode IN ({joind})";
        }
    }
}
