using System.Collections.Generic;
using dr.Application.Contract.User;
using Microsoft.AspNetCore.Mvc;

namespace dr.WebUi.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserApplication _userApplication;

        public AdminController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult User(UserSearchModel model)
        {
            var users = _userApplication.Search(model);
            return View(users);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult CreateUser(UserCreateModel model)
        {
            var result = _userApplication.Create(model);
            return View("User");
        }
    }
}
