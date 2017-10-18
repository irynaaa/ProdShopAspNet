using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IProductRepository: IDisposable
    {
        Product Add(Product product);
        //Product Remove(int id);
        //void Remove(Category product);
        //Product Details(int id);

        //Product Edit(int id);
        //Product Edit(Category product);

        IQueryable<Product> GettAllProducts();

        void SaveChanges();
        void Delete(int id);
        Product GetProductById(int id);



    }
}
