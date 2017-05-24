﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IDSR.Common.Core.ns11.Configuration;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.SqlDbReaders;
using IDSR.CondorReader.Core.ns11.DomainModels;
using Repo2.Core.ns11.Extensions;
using System;

namespace IDSR.CondorReader.Lib.WPF.BaseReaders
{
    public abstract class CondorReaderBase1 : SqlDbReaderBase
    {
        public CondorReaderBase1(LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
        }


        protected async Task<Dictionary<int, string>> QueryUsers(CancellationToken cancelTokn)
        {
            var qry = "SELECT userid, name FROM MarkUsers";
            var dict = new Dictionary<int, string>();
            using (var results = await ConnectAndReadAsync(qry, cancelTokn))
            {
                foreach (IDataRecord rec in results)
                    dict.Add(rec.ToInt(0), rec.ToText(1));
            }
            return dict;
        }


        protected async Task<Dictionary<int, decimal>> QueryLandedCost(CancellationToken cancelTokn)
        {
            var qry = "SELECT ProductID, ComputedAverageCost FROM Products";
            var dict = new Dictionary<int, decimal>();
            using (var results = await ConnectAndReadAsync(qry, cancelTokn))
            {
                foreach (IDataRecord rec in results)
                    dict.Add(rec.ToInt(0), rec.ToDecimal(1));
            }
            return dict;
        }


        protected async Task<Dictionary<int, CdrProduct>> GetProductsDict(CancellationToken cancelTkn)
        {
            var list = await QueryList<CdrProduct>("SELECT * FROM Products", 
                                        r => new CdrProduct(r), cancelTkn);
            return list.ToDictionary(x => x.ProductID);
        }


        protected async Task<List<T>> GetAllRecords<T>(string tableName, CancellationToken cancelTkn)
            where T : class
        {
            var qry = $"SELECT * FROM {tableName}";
            var list = new List<T>();
            using (var results = await ConnectAndReadAsync(qry, cancelTkn))
            {
                foreach (IDataRecord rec in results)
                {
                    var obj = Activator.CreateInstance(typeof(T), rec);
                    list.Add(obj as T);
                }
            }
            return list;
        }
    }
}
