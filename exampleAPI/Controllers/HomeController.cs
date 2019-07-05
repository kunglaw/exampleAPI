using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exampleAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Title = "Test Page";
            ViewBag.Name = "Aries Dimas Yudhistira";

            ViewBag.me = "Dimas";

            return View();
        }

        public ActionResult Hello()
        {
            return View();
        }
    }
}
