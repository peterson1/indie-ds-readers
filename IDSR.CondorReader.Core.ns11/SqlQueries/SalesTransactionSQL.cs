using System;

namespace IDSR.CondorReader.Core.ns11.SqlQueries
{
    public static class SalesTransactionSQL
    {
        public static string HeadersQuery(DateTime start, DateTime end)
            => @"SELECT * 
                   FROM FinishedTransaction h"
                + WHERE_BETWEEN("h.LogDate", start, end);


        public static string LinesQuery(DateTime start, DateTime end)
            => @"SELECT ln.* 
                   FROM FinishedSales ln
              LEFT JOIN FinishedTransaction h
                     ON h.TransactionNo = ln.TransactionNo
                    AND h.TerminalNo    = ln.TerminalNo
                    AND h.DateTime      = ln.DateTime"
                + WHERE_BETWEEN("h.LogDate", start, end);


        public static string PaymentsQuery(DateTime start, DateTime end)
            => @"SELECT py.* 
                   FROM FinishedPayments py
              LEFT JOIN FinishedTransaction h
                     ON h.TransactionNo = py.TransactionNo
                    AND h.TerminalNo    = py.TerminalNo
                    AND h.DateTime      = py.DateTime"
                + WHERE_BETWEEN("h.LogDate", start, end);


        private static string WHERE_BETWEEN(string fieldName, DateTime start, DateTime end)
            => $@" WHERE {fieldName} >= '{start.Date:yyyy-MM-dd}'
                     AND {fieldName} <  '{end.Date.AddDays(1):yyyy-MM-dd}'";


        public static string AND_Terminal(this string query, uint terminalId)
            => $"{query} AND h.TerminalNo = '{terminalId:000}'";


        public static string AND_Cashier(this string query, int cdrUserId)
            => $"{query} AND h.UserID = {cdrUserId}";
    }
}
