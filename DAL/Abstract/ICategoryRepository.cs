using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ICategoryRepository: IDisposable
    {
        Category Add(Category category);
        Category Remove(int id);
        void Remove(Category category);
        Category Details(int id);

        Category Edit(int id);
        Category Edit(Category category);

        IQueryable<Category> GettAllCategories(bool published = true);

        void SaveChanges();
    }
}
