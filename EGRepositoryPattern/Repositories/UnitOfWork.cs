using System;
using EGRepositoryPattern.Models;

namespace EGRepositoryPattern.Repositories
{
	public class UnitOfWork : IUnitOfWorkInterface
	{
        private IProductRepository _productRepository;

        private readonly ApplicationDbContext _dbContext;

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_dbContext);
                }
                return _productRepository;
            }
        }

        public UnitOfWork(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}

