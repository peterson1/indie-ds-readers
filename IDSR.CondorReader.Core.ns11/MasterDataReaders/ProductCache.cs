using System;
using System.Collections.Generic;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.MasterDataReaders
{
    public class ProductCache
    {
        private SortedDictionary<int, CdrProduct> _dict = new SortedDictionary<int, CdrProduct>();



        public CdrProduct this[int productID, string missingDescription]
        {
            get
            {
                CdrProduct prod = null;

                if (_dict.TryGetValue(productID, out prod))
                    return prod;
                else
                    //return new CdrProduct
                    //{
                    //    ProductID          = productID,
                    //    Description = missingDescription
                    //};
                    return null;
            }
        }


        public void Add(CdrProduct product)
            => _dict.Add(product.ProductID, product);


        public void Clear() => _dict.Clear();
    }
}
