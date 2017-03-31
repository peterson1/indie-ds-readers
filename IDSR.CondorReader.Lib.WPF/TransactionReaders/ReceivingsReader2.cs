using System.Collections.Generic;
using System.Linq;
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


        public async Task<List<CdrReceiving>> GetAllParents(CancellationToken cancelTkn, bool withLines)
        {
            List<CdrReceivingLine> lines = null;
            if (withLines) lines = await GetAllLines(cancelTkn);

            var usrs = await QueryUsers(cancelTkn);
            var list = await QueryList<CdrReceiving>(ParentQuery, r => new CdrReceiving(r), cancelTkn);
            foreach (var rcv in list)
            {
                int usrID;
                if (int.TryParse(rcv.PostedBy, out usrID))
                    rcv.PostedByName = usrs.GetOrDefault(usrID, "‹deleted-user›");

                if (withLines)
                    rcv.Lines = lines.Where(x => x.ReceivingID == rcv.ReceivingID).ToList();
            }
            return list;
        }


        public async Task<List<CdrReceivingLine>> GetAllLines(CancellationToken cancelTkn)
        {
            var parentsJob  = GetAllParents   (cancelTkn, false);
            var productsJob = GetProductsDict (cancelTkn);
            var linesJob    = QueryList<CdrReceivingLine>(LinesQuery, x => new CdrReceivingLine(x), cancelTkn);
            await Task.WhenAll(parentsJob, linesJob);

            var parents  = (await parentsJob).ToDictionary(x => x.ReceivingID);
            var products = await productsJob;
            var lines    = await linesJob;

            foreach (var line in lines)
            {
                line.Parent = parents.GetOrDefault(line.ReceivingID);

                if (line.ProductID.HasValue)
                    line.Product = products.GetOrDefault((int)line.ProductID.Value);
            }
            return lines;
        }
    }
}
