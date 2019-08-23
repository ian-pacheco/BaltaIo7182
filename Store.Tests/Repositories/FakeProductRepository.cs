using Store.Domain.Entities;
using Store.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Store.Tests.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Get(IEnumerable<Guid> guids)
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product("Produto 01", 10, true));
            products.Add(new Product("Produto 02", 10, true));
            products.Add(new Product("Produto 03", 10, true));
            products.Add(new Product("Produto 04", 10, false));
            products.Add(new Product("Produto 05", 10, false));

            return products;
        }
    }
}
