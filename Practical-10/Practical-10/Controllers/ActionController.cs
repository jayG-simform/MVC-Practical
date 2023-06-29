using Practical_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10.Controllers
{
    public class ActionController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ContentResult ContentResult()
        {
            return Content("<h1>This is Content result returned");
        }
        public FileResult FileContentResult()
        {
            return File(Url.Content("~/Web.config"), "Text");
        }
        public EmptyResult EmptyResult()
        {
            return new EmptyResult();
        }
        public ActionResult JavaScriptResult()
        {
            return View();
        }
        public JavaScriptResult JavaScriptResultDemo()
        {
            var msg = "alert('You are rendering JavaScript Result from Action Method.');";
            return new JavaScriptResult() { Script = msg };
        }
        public JsonResult JsonResult()
        {
            var employee = new Employee() { Id = 1, Name = "Jay"};
            return Json(employee, JsonRequestBehavior.AllowGet);
        }


    }
}