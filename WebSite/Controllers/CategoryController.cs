using BLL.Abstract;
using BLL.ViewModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductProvider _productProvider;
        public CategoryController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }
        // GET: Category

        public ActionResult Index()
        {
            var model = _productProvider.GetCategories();
            return View(model);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddCategoryProdViewModel category)
        {
            _productProvider.AddCategory(category);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var model = _productProvider.RemoveCategory(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Remove(CategoryItemProdViewModel model)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        _productProvider.RemoveCategory(model);
            //        return RedirectToAction("Index");
            //    }
            //    return View(model);
            //}
            //catch (Exception)
            //{
            //    return View();
            //}
            _productProvider.RemoveCategory(model);
            return RedirectToAction("Index");

        }


        public ActionResult Details(int id)
        {
            var model = _productProvider.GetCategoryDetails(id);
            return View(model);
        }
        
       // [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _productProvider.EditCategory(id);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryItemProdViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productProvider.EditCategory(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception)
            {
                return View();
            }

        }
    }
}