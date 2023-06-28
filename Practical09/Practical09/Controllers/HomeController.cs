using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical09.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Test1()
        {
            ViewBag.Message = "Hello world";
            return View();
        }

        public ActionResult Test2()
        {
            ViewBag.Message = "Hello world";

            return View();
        }

        public ActionResult Test3()
        {
            ViewBag.Message = "Hello world";

            return View();
        }
    }
}