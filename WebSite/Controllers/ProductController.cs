using BLL.Abstract;
using BLL.ViewModels;
using DAL.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private readonly IProductProvider _productProvider;

        public ProductController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }
        // GET: Category

        public ActionResult Index(int? page)
        {
            var model = _productProvider.GetProducts().OrderBy(i=>i.Id);

            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //return View(phones.ToPagedList(pageNumber, pageSize));
            //List<ProductViewModel> list = new List<ProductViewModel>();
            //foreach(var item in model)
            //{
            //    list.Add(item);
            //}
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            //list.ToPagedList(pageNumber, pageSize);

            //model.ToPagedList(pageNumber, pageSize);

            //var resultGroup = allResults.OrderByDescending(r => r.DatePosted)
            //                                   .Skip(60)
            //                                   .Take(30)
            //                                   .GroupBy(p => new { Total = allResults.Count() })
            //                                   .First();

            //var results = new ResultObject
            //{
            //    ResultCount = resultGroup.Key.Total,
            //    Results = resultGrouping.Select(r => r)
            //};


            return View(_productProvider.GetProducts().OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Add()
        {
            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = _productProvider.GetSelectCategories();

            var viewModel = new AddProductViewModel
            {
                CreateDate = DateTime.Now,
                ModefiedDate = DateTime.Now,
                Categories = categoriesList
            };
            return View(viewModel/*"Add", viewModel*/);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddProductViewModel product)
        {
            //doesn't work???
            if (!ModelState.IsValid)
            {
                IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
                categoriesList = _productProvider.GetSelectCategories();

                var viewModel = new AddProductViewModel
                {
                    Name = product.Name,
                    Description = product.Description,
                    CreateDate = product.CreateDate,
                    ModefiedDate = product.ModefiedDate,
                    CategoryId = product.CategoryId,
                    Category = product.Category,
                    Categories= categoriesList

                    //Product = product.Product,
                    //Categories = categoriesList
                };
                return View("Add", viewModel);
            }
            _productProvider.AddProduct(product);
            return RedirectToAction("Index");
            //IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            //categoriesList = _productProvider.GetSelectCategories();

            //var viewModel = new AddProductViewModel
            //{
            //    Product = new Product(),
            //    Categories = categoriesList
            //};

            // return View("CustomerForm", viewModel);
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new AddProductViewModel
            //    {
            //        Product=product.Product,
            //        Categories = product.Categories
            //    };
            // //   return View("Add", viewModel);
            //}
            //_productProvider.AddProduct(product);
            //return RedirectToAction("Index");
        }
    }
}