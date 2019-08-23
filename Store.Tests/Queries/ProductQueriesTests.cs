using Store.Domain.Entities;
using Store.Domain.Queries;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Store.Tests.Queries
{
    public class ProductQueriesTests
    {
        private readonly IList<Product> PRODUCTS;

        public ProductQueriesTests()
        {
            PRODUCTS = new List<Product>
            {
                new Product("Produto 01", 10, true),
                new Product("Produto 02", 20, true),
                new Product("Produto 03", 30, true),
                new Product("Produto 04", 40, false),
                new Product("Produto 05", 50, false)
            };
        }

        [Fact]
        public void ShouldReturn3WhenConsultingAtiveProducts()
        {
            var result = PRODUCTS.AsQueryable().Where(ProductQueries.GetAtiveProducts());
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void ShouldReturn2WhenConsultingInativeProducts()
        {
            var result = PRODUCTS.AsQueryable().Where(ProductQueries.GetInativeProducts());
            Assert.Equal(2, result.Count());
        }
    }
}
