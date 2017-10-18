﻿using BLL.Abstract;
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
            int pageSize = 10;
            int pageNumber = (page ?? 1);

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
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddProductViewModel product)
        {
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

                };
                return View("Add", viewModel);
            }
            _productProvider.AddProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _productProvider.GetProductInfo(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductViewModel prodDel)
        {
            _productProvider.Delete(prodDel.Id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _productProvider.GetProductInfo(id);
            return View(model);
        }

    }
}