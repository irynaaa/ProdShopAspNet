﻿using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;

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
            return this._context.Set<Product>()/*.Include(c=>c.Category)*/;
        }

        public void Delete(int id)
        {
            var product = this.GetProductById(id);
            if (product != null)
            {
                _context.Set<Product>().Remove(product);
                this.SaveChanges();
            }
        }

        public Product GetProductById(int id)
        {
            return this.GettAllProducts()
                .SingleOrDefault(c => c.Id == id);
        }

       

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
