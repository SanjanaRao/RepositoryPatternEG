using System;
using EGRepositoryPattern.Models;

namespace EGRepositoryPattern.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);

    }
}

