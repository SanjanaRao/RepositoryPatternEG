using System;
using Microsoft.EntityFrameworkCore;

namespace EGRepositoryPattern.Repositories
{
	public class Repository<T> : IRepository<T> where T:class
	{
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
		public Repository( ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
		}

        public void Add(T entity)
        {
            _dbSet.Add(entity);
           
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

       
    }
}

