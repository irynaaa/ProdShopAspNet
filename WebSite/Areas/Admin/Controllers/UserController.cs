using BLL.Abstract;
using BLL.ViewModels;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserProvider _userProvider;

        public UserController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }
        // GET: Admin/User
        public ActionResult Index(int? page)
        {
            IEnumerable<SelectRoleViewModel> rolesList = new List<SelectRoleViewModel>();
            rolesList = _userProvider.GetSelectRoles();
            ViewBag.CategoryId = new SelectList(rolesList, "Id", "Name");


            var model = _userProvider.GetUsers()/*.OrderBy(i => i.Id)*/;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(_userProvider.GetUsers()/*.OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize)*/);
        }

        [HttpPost]
        public ActionResult Index(int? page, int? userId)
        {
            IEnumerable<SelectRoleViewModel> rolesList = new List<SelectRoleViewModel>();
            rolesList = _userProvider.GetSelectRoles();
            ViewBag.CategoryId = new SelectList(rolesList, "Id", "Name");
            var model = _userProvider.GetUsers()/*.OrderBy(i => i.Id)*/;

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //if (userId != null)
           //     return View(_userProvider.GetUsers().Where(user => user.CategoryId == categoryId).OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize));
           // else
                return View(_userProvider.GetUsers()/*.OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize)*/);
        }


        [HttpPost]
        public ContentResult DeleteUserRole(int userId, int roleId)
        {
            string json = "";
            int rez = _userProvider.DeleteUserRole(userId, roleId);
            json = JsonConvert.SerializeObject(new
            {
                rez = rez
            });
            return Content(json, "application/json");
        }
    }

}