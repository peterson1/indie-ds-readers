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
        private IMovementsReader      _mvtReadr;

        public CondorDataReader1(LocalDbFinder localDbFinder, 
                                 DsrConfiguration1 dsrConfiguration1,
                                 IPurchaseOrdersReader purchaseOrdersReader,
                                 IReceivingsReader receivingsReader,
                                 IMovementsReader movementsReader) 
            : base(localDbFinder, dsrConfiguration1)
        {
            _poReadr  = purchaseOrdersReader;
            _rcvReadr = receivingsReader;
            _mvtReadr = movementsReader;
        }


        public async Task<List<CdrVendor>> GetVendors(CancellationToken cancelTkn)
        {
            var qry = "SELECT * FROM Vendor";
            var list = new List<CdrVendor>();
            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                    list.Add(new CdrVendor(rec));
            }
            return list;
        }


        public async Task<List<CdrProduct>> GetProducts(CancellationToken cancelTkn)
        {
            var qry = "SELECT * FROM Products";
            var list = new List<CdrProduct>();
            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                    list.Add(new CdrProduct(rec));
            }
            return list;
        }


        public Task<List<CdrPurchaseOrder>> GetPurchaseOrders(CancellationToken cancelTkn)
            => _poReadr.GetAllParents(cancelTkn);

        public Task<List<CdrPurchaseOrderLine>> GetPurchaseOrderLines(CancellationToken cancelTkn)
            => _poReadr.GetAllLines(cancelTkn);


        public Task<List<CdrReceiving>> GetReceivings(CancellationToken cancelTkn)
            => _rcvReadr.GetAllParents(cancelTkn);

        public Task<List<CdrReceivingLine>> GetReceivingLines(CancellationToken cancelTkn)
            => _rcvReadr.GetAllLines(cancelTkn);


        public Task<List<CdrMovement>> GetBadOrders(CancellationToken cancelTkn, bool withLines = false)
            => _mvtReadr.GetBadOrders(cancelTkn, withLines);

        public Task<List<CdrMovementLine>> GetBadOrderLines(CancellationToken cancelTkn)
            => _mvtReadr.GetBadOrderLines(cancelTkn);
    }
}
