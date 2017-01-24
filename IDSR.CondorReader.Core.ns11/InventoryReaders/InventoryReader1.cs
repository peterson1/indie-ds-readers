using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Authentication;
using IDSR.Common.Core.ns11.SqlTools;

namespace IDSR.CondorReader.Core.ns11.InventoryReaders
{
    public class InventoryReader1 : IInventoryReader
    {
        private ISqlDbReader _readr;


        public InventoryReader1(ISqlDbReader sqlDbReader)
        {
            _readr = sqlDbReader;
        }


        public Task<IDictionary<long, decimal>> GetCurrentSellingAreaQtys(CancellationToken cancelToken)
        {
            var qry = "SELECT ProductID, SellingArea FROM Products;";
            return _readr.QueryDictionary<long, decimal>(qry, cancelToken);
        }


        public Task<bool> Connect(DatabaseCredentials dbCredentials, CancellationToken cancelToken)
            => _readr.Connect(dbCredentials, cancelToken);
    }
}
