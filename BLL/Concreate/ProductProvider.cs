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

        public ProductProvider(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
            var model=_categoryRepository.GettAllCategories()
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
    }
}
