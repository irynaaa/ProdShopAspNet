using BLL.Abstract;
using BLL.ViewModels;
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

       // [Authorize(Roles = "Admin,User")]
        public ActionResult Index(int? page)
        {
            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = _productProvider.GetSelectCategories();
            ViewBag.CategoryId = new SelectList(categoriesList,"Id","Name");


            var model = _productProvider.GetProducts().OrderBy(i=>i.Id);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
                return View(_productProvider.GetProducts().OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize));
        }

       
        [HttpPost]
        public ActionResult Index(int? page, int? categoryId)
        {
            IEnumerable<SelectItemViewModel> categoriesList = new List<SelectItemViewModel>();
            categoriesList = _productProvider.GetSelectCategories();
            ViewBag.CategoryId = new SelectList(categoriesList, "Id", "Name");
            var model = _productProvider.GetProducts().OrderBy(i => i.Id);
            
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (categoryId != null)
                return View(_productProvider.GetProducts().Where(prod => prod.CategoryId == categoryId).OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize));
            else
                return View(_productProvider.GetProducts().OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize));
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _productProvider.GetProductInfo(id);
            return View(model);
        }

    }
}