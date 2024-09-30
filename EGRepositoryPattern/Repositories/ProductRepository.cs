using System;
using EGRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace EGRepositoryPattern.Repositories
{
	public class ProductRepository : Repository<Product>,IProductRepository
	{
 
  
        ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)//base passes parameter to base repository<Category>
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }

    }
}

