﻿using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.TransactionReaders;
using IDSR.CondorReader.Lib.WPF.BaseReaders;
using IDSR.CondorReader.Lib.WPF.TransactionReaders;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
                                 IMovementsReader movementsReader,
                                 SalesTransactionReader salesTransactionReader,
                                 ProductsMetaReader productsMetaReader) 
            : base(localDbFinder, dsrConfiguration1)
        {
            _poReadr          = purchaseOrdersReader;
            _rcvReadr         = receivingsReader;
            _mvtReadr         = movementsReader;
            SalesTransactions = salesTransactionReader;
            ProductsMeta      = productsMetaReader;
        }


        public SalesTransactionReader SalesTransactions { get; }
        public ProductsMetaReader     ProductsMeta      { get; }


        public Task<List<CdrVendor>> GetVendors(CancellationToken cancelTkn = new CancellationToken())
            => GetAllRecords<CdrVendor>("Vendor", cancelTkn);


        public Task<List<CdrProduct>> GetProducts(CancellationToken cancelTkn = new CancellationToken())
            => GetAllRecords<CdrProduct>("Products", cancelTkn);


        public Task<List<CdrCustomer>> GetCustomers(CancellationToken cancelTkn = new CancellationToken())
            => GetAllRecords<CdrCustomer>("Customer", cancelTkn);


        public Task<List<CdrTenderType>> GetTenderTypes(CancellationToken cancelTkn = new CancellationToken())
            => GetAllRecords<CdrTenderType>("TenderTypes", cancelTkn);


        public Task<List<CdrPurchaseOrder>> GetPurchaseOrders(CancellationToken cancelTkn, bool withLines = false)
            => _poReadr.GetAllParents(cancelTkn, withLines);

        public Task<List<CdrPurchaseOrderLine>> GetPurchaseOrderLines(CancellationToken cancelTkn)
            => _poReadr.GetAllLines(cancelTkn);


        public Task<List<CdrReceiving>> GetReceivings(CancellationToken cancelTkn, bool withLines = false)
            => _rcvReadr.GetAllParents(cancelTkn, withLines);

        public Task<List<CdrReceivingLine>> GetReceivingLines(CancellationToken cancelTkn)
            => _rcvReadr.GetAllLines(cancelTkn);


        public Task<List<CdrMovement>> GetBadOrders(CancellationToken cancelTkn, bool withLines = false)
            => _mvtReadr.GetBadOrders(cancelTkn, withLines);

        public Task<List<CdrMovementLine>> GetBadOrderLines(CancellationToken cancelTkn)
            => _mvtReadr.GetBadOrderLines(cancelTkn);
    }
}
