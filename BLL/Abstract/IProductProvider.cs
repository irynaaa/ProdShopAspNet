using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IProductProvider
    {
        int AddCategory(AddCategoryProdViewModel addCategory);
        int AddProduct(AddProductViewModel addProduct);
        IEnumerable<SelectItemViewModel> GetSelectCategories();
        int RemoveCategory(CategoryItemProdViewModel removeCategory);
        CategoryItemProdViewModel RemoveCategory(int id);
        CategoryItemProdViewModel EditCategory(int id);
        int EditCategory(CategoryItemProdViewModel editCategory);
        IEnumerable<CategoryItemProdViewModel> GetCategories();
        IEnumerable<ProductViewModel> GetProducts();
        CategoryItemProdViewModel GetCategoryDetails(int id);

        void Delete(int id);
        ProductViewModel GetProductInfo(int id);
        EditProductViewModel EditProduct(int id);
        int EditProduct(EditProductViewModel editCategory);
    }
}
