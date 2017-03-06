using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Repo2.Core.ns11.Extensions;
using IDSR.Common.Lib.WPF.DiskAccess;
using IDSR.Common.Lib.WPF.SqlDbReaders;
using IDSR.CondorReader.Core.ns11.DomainModels;
using IDSR.CondorReader.Core.ns11.MasterDataReaders;
using IDSR.Common.Core.ns11.Configuration;

namespace IDSR.CondorReader.Lib.WPF.MasterDataReaders
{
    public class VendorsReader1 : SqlDbReaderBase
    {
        private VendorCache _cache;


        public VendorsReader1(VendorCache vendorCache, LocalDbFinder localDbFinder, DsrConfiguration1 dsrConfiguration1) : base(localDbFinder, dsrConfiguration1)
        {
            _cache = vendorCache;
        }


        public async Task CacheInMemory(CancellationToken cancelTkn)
        {
            using (var readr = await ConnectAndReadAsync(SQL_QUERY, cancelTkn))
            {
                _cache.Clear();
                foreach (IDataRecord rec in readr)
                {
                    var obj = ToVendor(rec);
                    _cache.Add(obj.Code, obj);
                }
            }
        }

        const string SQL_QUERY = "SELECT * FROM Vendor";


        private _deprecated_Vendor ToVendor(IDataRecord r)
            => new _deprecated_Vendor
            {
                Code                 = r.ToText(      0),//[vendorcode]	varchar(10) NOT NULL COLLATE NOCASE,
                Description          = r.ToText(      1),//[description]	varchar(40) NOT NULL COLLATE NOCASE,
                Address              = r.ToText(      2),//[address]	varchar(50) COLLATE NOCASE,
                City                 = r.ToText(      3),//[city]	varchar(20) COLLATE NOCASE,
                ZipCode              = r.ToText(      4),//[zipcode]	varchar(6) COLLATE NOCASE,
                Country              = r.ToText(      5),//[country]	varchar(20) COLLATE NOCASE,
                Fax                  = r.ToText(      6),//[fax]	varchar(20) COLLATE NOCASE,
                Email                = r.ToText(      7),//[email]	varchar(50) COLLATE NOCASE,
                Phone                = r.ToText(      8),//[phone]	varchar(20) COLLATE NOCASE,
                Contactperson        = r.ToText(      9),//[contactperson]	varchar(30) COLLATE NOCASE,
                TermId               = r.GetDecimal (10),//[termid]	numeric NOT NULL DEFAULT 0,
                DaysToDeliver        = r.ToLong_    (11),//[daystodeliver]	integer NOT NULL DEFAULT 0,
                TradeDiscount        = r.ToText(     12),//[tradediscount]	varchar(20) COLLATE NOCASE,
                CashDiscount         = r.ToText(     13),//[cashdiscount]	varchar(20) COLLATE NOCASE,
                Terms                = r.ToLong_    (14),//[terms]	integer NOT NULL DEFAULT 0,
                IncludeLineDiscounts = r.GetBoolean (15),//[IncludeLineDiscounts]	bit NOT NULL DEFAULT 0,
                DiscountCode1        = r.ToText(     16),//[discountcode1]	varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
                DiscountCode2        = r.ToText(     17),//[discountcode2]	varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
                DiscountCode3        = r.ToText(     18),//[discountcode3]	varchar(4) NOT NULL COLLATE NOCASE DEFAULT '',
                Discount1            = r.GetDecimal (19),//[discount1]	numeric NOT NULL DEFAULT 0,
                Discount2            = r.GetDecimal (20),//[discount2]	numeric NOT NULL DEFAULT 0,
                Discount3            = r.GetDecimal (21),//[discount3]	numeric NOT NULL DEFAULT 0,
                DaysToSum            = r.ToLong_    (22),//[daystosum]	integer NOT NULL DEFAULT 0,
                ReorderMultiplier    = r.ToLong_    (23),//[reordermultiplier]	integer NOT NULL DEFAULT 0,
                Remarks              = r.ToText(     24),//[remarks]	varchar(20) COLLATE NOCASE,
                ShareWithBranch      = r.GetBoolean (25),//[SHAREWITHBRANCH]	bit NOT NULL DEFAULT 0,
                Consignor            = r.GetBoolean (26),//[Consignor]	bit NOT NULL DEFAULT 0,
                LastDateModified     = r.GetDateTime(27),//[LASTDATEMODIFIED]	datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
                TIN                  = r.ToText(     28),//[TIN]	varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
                Cluster              = r.ToText(     29),//[Cluster]	varchar(20) NOT NULL COLLATE NOCASE DEFAULT '',
                CeilingLimit         = r.GetDecimal (30),//[CeilingLimit]	numeric NOT NULL DEFAULT 0,
                CeilingCounter       = r.GetDecimal (31),//[CeilingCounter]	numeric NOT NULL DEFAULT 0
            };
    }
}
