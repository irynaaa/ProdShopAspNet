using BLL.Abstract;
using BLL.ViewModels;
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

        public ActionResult Index()
        {
            var model = _productProvider.GetProducts();
            return View(model);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddProductViewModel product)
        {
            //doesn't work???
            if (!ModelState.IsValid)
            {
                var viewModel = new AddProductViewModel
                {
                    Name = product.Name,
                    Description=product.Description,
                    CreateDate=product.CreateDate,
                    ModefiedDate=product.ModefiedDate,
                    Categories = _productProvider.GetSelectCategories()
                };
                return View("Add", viewModel);
            }
            _productProvider.AddProduct(product);
            return RedirectToAction("Index");
        }
    }
}