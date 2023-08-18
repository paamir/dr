using System.Diagnostics;
using dr.Application.Contract.User;
using dr.WebUi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dr.WebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserApplication _userApplication; 
        public HomeController(ILogger<HomeController> logger, IUserApplication userApplication)
        {
            _logger = logger;
            _userApplication = userApplication;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            _userApplication.Create(new UserCreateModel
            {
                Mobile = "amirdd",
                Password = "aldk",
                Email = "skalddf",
                Name = "amirs",
                RoleId = 2
            });
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
