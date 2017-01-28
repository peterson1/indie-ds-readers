using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.LocalDbReaders;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.MasterDataReaders;
using IDSR.CondorReader.Core.ns11.SalesReaders;

namespace IDSR.CondorReader.Lib.WPF.SalesReaders
{
    public class MonthlySalesReader1 : LocalDbReaderBase, IMonthlySalesReader
    {
        private ProductsCache _products;


        public MonthlySalesReader1(LocalDbFinder localDbFinder, ProductsCache productsDictionary) : base(localDbFinder)
        {
            _products = productsDictionary;
        }


        const string SQL_QUERY =
            @"SELECT CAST(ProductID AS INTEGER),
                     TotalQty,
                     TerminalNo,
                     TimeScanned
              FROM FinishedSales
              WHERE TimeScanned >= '{0}' AND TimeScanned < '{1}';";


        //public DbCommand FinishedSalesQuery(int year, int month)
        //{
        //    var conn        = ConnectToDB();
        //    var cmd         = conn.CreateCommand();
        //    cmd.CommandText = ComposeSqlQuery(year, month);
        //    return cmd;
        //}


        private static string ComposeSqlQuery(int year, int month)
        {
            var start = new DateTime(year, month, 1);
            var end = start.AddMonths(1);
            return string.Format(SQL_QUERY, Param(start), Param(end));
        }


        public DbDataReader ReadFinishedSales(int year, int month)
            => ConnectAndRead(ComposeSqlQuery(year, month));


        public FinishedSale ToFinishedSale(IDataRecord rec)
            => new FinishedSale
            {
                Product     = FindProduct(rec, 0),
                TotalQty    = rec.GetDecimal  (1),
                TerminalNo  = rec.GetString   (2),
                TimeScanned = rec.GetDateTime (3)
            };


        private Product FindProduct(IDataRecord rec, int fieldIndx)
        {
            var id = rec.GetInt64(fieldIndx);
            return _products[id, "< unrecognized Product ID >"];
        }
    }
}
