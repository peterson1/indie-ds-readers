﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.TransactionReaders
{
    public interface IMovementsReader
    {
        Task<List<CdrMovementLine>> GetOpenReturns(IEnumerable<string> vendorCodes, CancellationToken cancelTokn);
    }
}
