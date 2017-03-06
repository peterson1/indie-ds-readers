using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Lib.WPF.BaseReaders;

namespace IDSR.CondorReader.Lib.WPF.MasterDataReaders
{
    public class CdrMasterDataReader1 : CondorReaderBase1
    {
        public CdrMasterDataReader1(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
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
    }
}
