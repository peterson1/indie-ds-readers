using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    AND h.TerminalNo = ln.TerminalNo"
                + WHERE_BETWEEN("h.LogDate", start, end);


        public static string PaymentsQuery(DateTime start, DateTime end)
            => @"SELECT ln.* 
                   FROM FinishedPayments py
              LEFT JOIN FinishedTransaction h
                     ON h.TransactionNo = py.TransactionNo
                    AND h.TerminalNo = py.TerminalNo"
                + WHERE_BETWEEN("h.LogDate", start, end);


        private static string WHERE_BETWEEN(string fieldName, DateTime start, DateTime end)
            => $@"WHERE {fieldName} >= {start.Date}
                    AND {fieldName} <  {end.Date.AddDays(1)}";
    }
}
