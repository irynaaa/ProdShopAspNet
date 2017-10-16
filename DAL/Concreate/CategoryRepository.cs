using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;

namespace DAL.Concreate
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IEFContext _context;

        public CategoryRepository(IEFContext context)
        {
            _context = context;
        }
        public Category Add(Category category)
        {
            _context.Set<Category>().Add(category);
            return category;
        }
        public Category Remove(int id)
        {
            return _context.Set<Category>().Single(x => x.Id == id);
        }

        public void Remove(Category category)
        {
            //_context.Set<Category>().Remove(category);
            _context.Deleted(category);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

       
        public void Dispose()
        {
            if (this._context != null)
                this._context.Dispose();
        }


        public IQueryable<Category> GettAllCategories(bool published = true)
        {
            return this._context.Set<Category>()
                .Where(c=>c.Published || c.Published==published);
        }

        public Category Details(int id)
        {
            return _context.Set<Category>().SingleOrDefault(x => x.Id == id);
        }
        public Category Edit(int id)
        {
            return _context.Set<Category>().SingleOrDefault(x => x.Id == id);
        }

        public Category Edit(Category category)
        {
            _context.Modified(category);
            _context.SaveChanges();
            return category;
        }
    }
}
