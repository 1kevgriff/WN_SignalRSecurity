using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SecurityDemo.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SecurityDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        UserManager<ApplicationUser> _userManager;

        public HomeController() :
            this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {

        }

        public HomeController(UserManager<SecurityDemo.Web.Models.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //foreach (var role in _userManager.GetRoles(User.Identity.GetUserId()))
            //{
            //    Debug.WriteLine("User is in the {0} role", role);
            //}

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}