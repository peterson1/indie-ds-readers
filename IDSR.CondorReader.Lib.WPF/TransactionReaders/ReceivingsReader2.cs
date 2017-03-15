using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.TransactionReaders;
using IDSR.CondorReader.Lib.WPF.BaseReaders;
using Repo2.Core.ns11.Extensions;
using static IDSR.CondorReader.Core.ns11.SqlQueries.ReceivingsSQL;

namespace IDSR.CondorReader.Lib.WPF.TransactionReaders
{
    public class ReceivingsReader2 : CondorReaderBase1, IReceivingsReader
    {
        public ReceivingsReader2(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
        }


        public async Task<List<CdrReceiving>> GetAllParents(CancellationToken cancelTkn)
        {
            var usrs = await QueryUsers(cancelTkn);
            var list = new List<CdrReceiving>();

            using (var results = await ConnectAndReadAsync(ParentQuery, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                {
                    var re = new CdrReceiving(rec);

                    int usrID;
                    if (int.TryParse(re.PostedBy, out usrID))
                        re.PostedByName = usrs.GetOrDefault(usrID, "‹deleted-user›");

                    list.Add(re);
                }
            }
            return list;
        }

        public Task<List<CdrReceivingLine>> GetAllLines(CancellationToken cancelTkn)
        {
            throw new NotImplementedException();
        }
    }
}
