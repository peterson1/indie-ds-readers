using System;
using System.Collections.Generic;
using IDSR.CondorReader.Core.ns11.DomainModels;

namespace IDSR.CondorReader.Core.ns11.MasterDataReaders
{
    public class ProductsCache
    {
        private SortedDictionary<long, Product> _dict = new SortedDictionary<long, Product>();



        public Product this[long productID, string missingDescription]
        {
            get
            {
                Product prod = null;

                if (_dict.TryGetValue(productID, out prod))
                    return prod;
                else
                    return new Product
                    {
                        Id          = productID,
                        Description = missingDescription
                    };
            }
        }


        public void Add(Product product)
            => _dict.Add(product.Id, product);


        public void Clear() => _dict.Clear();
    }
}
