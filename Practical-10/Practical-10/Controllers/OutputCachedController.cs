using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10.Controllers
{
    public class OutputCachedController : Controller
    {
        [OutputCache(Duration = 300)]
        public ActionResult Index()
        {
            ViewBag.CurrentDate = DateTime.Now;
            return View();
        }
    }
}