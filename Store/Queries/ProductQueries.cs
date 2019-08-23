using Store.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Store.Domain.Queries
{
    public static class ProductQueries
    {
        public static Expression<Func<Product, bool>> GetAtiveProducts()
        {
            return x => x.Active;
        }
        public static Expression<Func<Product, bool>> GetInativeProducts()
        {
            return x => x.Active == false;
        }
    }
}
