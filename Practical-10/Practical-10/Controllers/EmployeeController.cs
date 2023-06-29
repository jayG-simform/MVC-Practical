using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult Index(string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}