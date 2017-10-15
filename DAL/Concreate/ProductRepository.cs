using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Concreate
{
    public class ProductRepository : IProductRepository
    {
        private readonly IEFContext _context;

        public ProductRepository(IEFContext context)
        {
            _context = context;
        }

        public Product Add(Product product)
        {
            _context.Set<Product>().Add(product);
            return product;
        }

        public void Dispose()
        {
            if (this._context != null)
                this._context.Dispose();
        }

        public IQueryable<Product> GettAllProducts()
        {
            return this._context.Set<Product>();
        }

        //public Product Details(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Product Edit(Category product)
        //{
        //    throw new NotImplementedException();
        //}

        //public Product Edit(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public IQueryable<Product> GettAllProducts(bool published = true)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Remove(Category product)
        //{
        //    throw new NotImplementedException();
        //}

        //public Product Remove(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
