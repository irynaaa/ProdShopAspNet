using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;
using DAL.Abstract;
using DAL.Entities;

using DAL.Concreate;

namespace BLL.Concreate
{
    class ProductProvider : IProductProvider
    {
        ICategoryRepository _categoryRepository;
        IProductRepository _productRepository;

        public ProductProvider(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public int AddCategory(AddCategoryProdViewModel addCategory)
        {
            Category category = new Category
            {
                Name = addCategory.Name,
                Published = addCategory.Published
            };
            _categoryRepository.Add(category);
            _categoryRepository.SaveChanges();

            return category.Id;
        }

        public CategoryItemProdViewModel RemoveCategory(int id)
        {
            var category = _categoryRepository.Remove(id);
            var model_ = new CategoryItemProdViewModel(category);
            return model_;
        }

        public int RemoveCategory(CategoryItemProdViewModel RemoveCategory)
        {
            Category category = new Category
            {
                Id=RemoveCategory.Id,
                Name = RemoveCategory.Name,
                Published = RemoveCategory.Published
            };
            _categoryRepository.Remove(category);
           // _categoryRepository.SaveChanges();

            return category.Id;
        }

        public CategoryItemProdViewModel EditCategory(int id)
        {
            var category = _categoryRepository.Edit(id);
            var model_ = new CategoryItemProdViewModel(category);
            return model_;
        }

        public int EditCategory(CategoryItemProdViewModel editCategory)
        {
            Category category = new Category
            {
                Id=editCategory.Id,
                Name = editCategory.Name,
                Published = editCategory.Published
            };
            _categoryRepository.Edit(category);
            return category.Id;
        }

        public IEnumerable<CategoryItemProdViewModel> GetCategories()
        {
            var model=_categoryRepository.GettAllCategories(false)
                .Select(c=> new CategoryItemProdViewModel
                { Id=c.Id,
                    Name =c.Name,
                    Published =c.Published});
            return model.AsEnumerable();
        }
      

        public  CategoryItemProdViewModel GetCategoryDetails(int id)
        {
            var model_ = new CategoryItemProdViewModel();
            model_.Id = _categoryRepository.Details(id).Id;
            model_.Name = _categoryRepository.Details(id).Name;
            model_.Published = _categoryRepository.Details(id).Published;
            return model_;
        }

       
        public int AddProduct(AddProductViewModel addProduct)
        {
            var selecteditem =GetSelectCategories();
            var item = new SelectItemViewModel();

            Product product = new Product
            {
                Name = addProduct.Name,
                Description = addProduct.Description,
                CreateDate = DateTime.Now/*addProduct.CreateDate*/,
                ModefiedDate = DateTime.Now /*addProduct.ModefiedDate*/,
                CategoryId = addProduct.CategoryId,
                Category = addProduct.Category
            };
            
            _productRepository.Add(product);
            _productRepository.SaveChanges();

            return product.Id;
        }

        public IEnumerable<SelectItemViewModel> GetSelectCategories()
        {
            return _categoryRepository.GettAllCategories()
                .Select(c=>new SelectItemViewModel {
                    Id=c.Id,
                    Name=c.Name
                });
        }

        IEnumerable<ProductViewModel> IProductProvider.GetProducts()
        {
            Product Product = new Product();
            var model = _productRepository.GettAllProducts()
                .Select(c => new ProductViewModel
                {
                    Id=c.Id,
                   Name=c.Name,
                   Description=c.Description,
                   CreateDate=c.CreateDate,
                   ModefiedDate=c.ModefiedDate,
                   CategoryId=c.CategoryId,
                   Category=c.Category

                });
            
            return model.AsEnumerable();
        }

       
    }
}
