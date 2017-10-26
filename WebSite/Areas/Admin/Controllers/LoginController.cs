using BLL.Abstract;
using BLL.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountProvider _accountProvider;
        public LoginController(IAccountProvider accountProvider)
        {
            _accountProvider = accountProvider;
        }

        // GET: Admin/Login
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var status = _accountProvider.Login(model);
                if (status == StatusAccountViewModel.Succes)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                    ModelState.AddModelError("", "Data input error. User not found!");
            }
            return View(model);
        }

        #region AJAX
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ContentResult LoginPopup(LoginViewModel model)
        {
            string json = ""; int rez = 0; string message = "";
            // message = "Подумай ще!";
            if (ModelState.IsValid)
            {
                var status = _accountProvider.Login(model);
                if (status == StatusAccountViewModel.Succes)
                {
                    rez = 1;
                }
                else
                {
                    message = "Не тупи!";
                    rez = 2;
                }
            }
            json = JsonConvert.SerializeObject(new
            {
                rez = rez,
                message = message
            });
            return Content(json, "application/json");
        }
        #endregion

        public ActionResult Logout()
        {
            _accountProvider.Logout();
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}