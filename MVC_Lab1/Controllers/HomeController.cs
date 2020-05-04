using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Lab1.Controllers
{

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if(user.Name != null && user.Email != null && user.Password != null)
            {
                ViewBag.Name = user.Name;
                return View("Welcome");
            }
            return View();
        }
    }
}