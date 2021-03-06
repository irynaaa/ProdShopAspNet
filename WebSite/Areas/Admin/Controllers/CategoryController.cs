﻿using System;
using BLL.Abstract;
using BLL.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        private readonly IProductProvider _productProvider;
        public CategoryController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }
        // GET: Category
        [AllowAnonymous]
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
            if (!ModelState.IsValid)
            {
                var viewModel = new AddCategoryProdViewModel
                {
                    Name = category.Name,
                    Published = category.Published
                };
                return View("Add", viewModel);
            }
            _productProvider.AddCategory(category);
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Remove(int id)
        {
            var model = _productProvider.RemoveCategory(id);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Remove(CategoryItemProdViewModel model)
        {
            _productProvider.RemoveCategory(model);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var model = _productProvider.GetCategoryDetails(id);
            if (model == null) return HttpNotFound();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _productProvider.EditCategory(id);

            return View(model);
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