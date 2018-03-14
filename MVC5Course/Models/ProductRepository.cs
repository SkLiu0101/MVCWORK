using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => p.IsDeleted == false);
        }
        public IQueryable<Product> Get�Ҧ����R���ӫ~���TOP10() {
            return this.All().Take(10);
        }

        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }
        public void SaveChanges() {
            this.UnitOfWork.Commit();
        }
        public IQueryable<Product> Get�Ҧ����R���ӫ~���()
        {
            return this.All();
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}