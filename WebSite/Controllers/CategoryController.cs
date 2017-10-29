using BLL.Abstract;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
   // [Authorize]
    public class CategoryController : Controller
    {
        private readonly IProductProvider _productProvider;
        public CategoryController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }
        // GET: Category
       // [AllowAnonymous]
        public ActionResult Index()
        {
            var model = _productProvider.GetCategories();
            return View(model);
        }
      
        public ActionResult Details(int id)
        {
            var model = _productProvider.GetCategoryDetails(id);
            if (model==null) return HttpNotFound();
            return View(model);
        }
        
     
    }
}