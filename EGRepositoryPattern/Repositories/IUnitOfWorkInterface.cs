using System;
namespace EGRepositoryPattern.Repositories
{
	public interface IUnitOfWorkInterface
	{
        IProductRepository ProductRepository { get; }
        public void SaveChanges();
	}
}

