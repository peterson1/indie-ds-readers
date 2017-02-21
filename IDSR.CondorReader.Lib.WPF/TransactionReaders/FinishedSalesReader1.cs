using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Core.ns11.SqlTools;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.SqlDbReaders;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.MasterDataReaders;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class FinishedSalesReader1 : SqlDbReaderBase, IDsrDbReader<FinishedSale>
    {
        private ProductCache _products;


        public FinishedSalesReader1(LocalDbFinder localDbFinder, ProductCache productsDictionary, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
            _products = productsDictionary;
        }


        const string SQL_QUERY =
            @"SELECT CAST(ProductID AS INTEGER),
                     Qty,
                     TerminalNo,
                     TimeScanned,
                     Price,
                     DiscountedPrice,
                     ReturnRemarks,
                     pVatPercent,
                     TransactionNo,
                     Return
              FROM FinishedSales
              WHERE LogDate >= '{0}' AND LogDate < '{1}'
              AND Voided = 0";


        private FinishedSale ToFinishedSale(IDataRecord rec)
            => new FinishedSale
            {
                Product         = FindProduct(rec, 0),
                Qty             = rec.GetDecimal  (1),
                TerminalNo      = rec.GetString   (2),
                TimeScanned     = rec.GetDateTime (3),
                ScannedSRP      = rec.GetDecimal  (4),
                DiscountedPrice = rec.GetDecimal  (5),
                ReturnRemarks   = rec             [6].ToString(),
                VatPercent      = rec.GetInt64    (7),
                TransactionNo   = rec.GetInt64    (8),
                Return          = rec.GetBoolean  (9),
            };


        //private static string ComposeSqlQuery(int year, int month)
        //{
        //    var start = new DateTime(year, month, 1);
        //    var end = start.AddMonths(1);
        //    return string.Format(SQL_QUERY, Param(start), Param(end));
        //}


        private CdrProduct FindProduct(IDataRecord rec, int fieldIndx)
        {
            var id = rec.GetInt32(fieldIndx);
            return _products[id, "< unrecognized Product ID >"];
        }


        public async Task<List<FinishedSale>> GetMonthly(int year, int month, CancellationToken cancelTkn)
        {
            var qry  = AddParamsToMonthlySQL(SQL_QUERY, year, month);
            var list = new List<FinishedSale>();

            await Task.Run(async () =>
            {
                using (var results = await ConnectAndReadAsync(qry, cancelTkn))
                {
                    foreach (IDataRecord rec in results)
                    {
                        list.Add(ToFinishedSale(rec));
                    }
                }
            }).ConfigureAwait(false);

            return list;
        }

        public Task<List<FinishedSale>> GetDateRange(DateTime startDate, DateTime endDate, CancellationToken cancelTkn)
        {
            throw new NotImplementedException();
        }

        public Task<List<FinishedSale>> GetByIDs(IEnumerable<int> idsList, CancellationToken cancelTkn)
        {
            throw new NotImplementedException();
        }
    }
}
