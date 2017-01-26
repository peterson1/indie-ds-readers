using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.LocalDbReaders;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.SalesReaders;

namespace IDSR.CondorReader.Lib.WPF.SalesReaders
{
    public class MonthlySalesReader1 : LocalDbReaderBase, IMonthlySalesReader
    {
        public MonthlySalesReader1(LocalDbFinder localDbFinder) : base(localDbFinder)
        {
        }

        const string SQL_QUERY =
            @"SELECT CAST(ProductID AS INTEGER),
                     TotalQty,
                     TerminalNo,
                     TimeScanned
              FROM FinishedSales
              WHERE TimeScanned >= '{0}' AND TimeScanned < '{1}';";


        private FinishedSale CastFinishedSale(IDataRecord rec)
            => new FinishedSale
            {
                Product     = FindProduct(rec, 0),
                TotalQty    = rec.GetDecimal  (1),
                TerminalNo  = rec.GetString   (2),
                TimeScanned = rec.GetDateTime (3)
            };


        private Product FindProduct(IDataRecord rec, int fieldIndx)
        {
            return new Product { Id = rec.GetInt64(fieldIndx) };
        }


        public IEnumerable<FinishedSale> Query
            (int year, int month, CancellationToken cancelTkn)
        {
            var qry    = ComposeSqlQuery(year, month);


            var result = RunQuery(qry, cancelTkn);
            foreach (var record in result)
            {
                yield return CastFinishedSale(record);
            }
        }


        private string ComposeSqlQuery(int year, int month)
        {
            var start = new DateTime(year, month, 1);
            var end   = start.AddMonths(1);
            return string.Format(SQL_QUERY, Param(start), Param(end));
        }
    }
}
