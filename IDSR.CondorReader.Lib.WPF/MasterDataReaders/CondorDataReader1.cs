using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.TransactionReaders;
using IDSR.CondorReader.Lib.WPF.BaseReaders;

namespace IDSR.CondorReader.Lib.WPF.MasterDataReaders
{
    public class CondorDataReader1 : CondorReaderBase1
    {
        private IPurchaseOrdersReader _poReadr;
        private IReceivingsReader     _rcvReadr;

        public CondorDataReader1(LocalDbFinder localDbFinder, 
                                 DsrConfiguration1 dsrConfiguration1,
                                 IPurchaseOrdersReader purchaseOrdersReader,
                                 IReceivingsReader receivingsReader) 
            : base(localDbFinder, dsrConfiguration1)
        {
            _poReadr  = purchaseOrdersReader;
            _rcvReadr = receivingsReader;
        }


        public async Task<List<CdrVendor>> GetVendors()
        {
            var qry = "SELECT * FROM Vendor";
            var list = new List<CdrVendor>();
            using (var results = await ConnectAndReadAsync(qry, new CancellationToken()))
            {
                foreach (IDataRecord rec in results)
                    list.Add(new CdrVendor(rec));
            }
            return list;
        }


        public async Task<List<CdrProduct>> GetProducts()
        {
            var qry = "SELECT * FROM Products";
            var list = new List<CdrProduct>();
            using (var results = await ConnectAndReadAsync(qry, new CancellationToken()))
            {
                foreach (IDataRecord rec in results)
                    list.Add(new CdrProduct(rec));
            }
            return list;
        }


        public Task<List<CdrPurchaseOrder>> GetPurchaseOrders()
            => _poReadr.GetAllParents(new CancellationToken());

        public Task<List<CdrPurchaseOrderLine>> GetPurchaseOrderLines()
            => _poReadr.GetAllLines(new CancellationToken());


        public Task<List<CdrReceiving>> GetReceivings()
            => _rcvReadr.GetAllParents(new CancellationToken());

        public Task<List<CdrReceivingLine>> GetReceivingLines()
            => _rcvReadr.GetAllLines(new CancellationToken());
    }
}
