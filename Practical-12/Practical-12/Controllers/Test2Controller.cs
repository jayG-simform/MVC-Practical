using Practical_12.Models;
using Practical_12.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_12.Controllers
{
    public class Test2Controller : Controller
    {
        TestEmp test = new TestEmp();
        public ActionResult Index()
        {
            var data = test.GetUser();
            return View(data);
        }
        public ActionResult Create()
        {
            return View(new Test2());
        }
        [HttpPost]
        public ActionResult Create(Test2 emp)
        {
            if (ModelState.IsValid)
            {
                test.InsertEmp(emp);
                TempData["Message"] = "Record Added!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "Empty filed can't Submit";
                return RedirectToAction("Index");
            }
        }
        public ActionResult InsertDefault()
        {
            test.DefaultUser();
            return RedirectToAction("Index");
        }
        public ActionResult TotalSalary()
        {
            var data = test.TotalSalary();
            TempData["Message"] = "Total Salary: " + data;
            return RedirectToAction("Index");
        }
        public ActionResult FindEmp()
        {
            var data = test.FindEmp();
            return View(data);
        }
        public ActionResult MiddleNameNull()
        {
            var data = test.MiddleNameNull();
            TempData["Message"] = $"Total {data} Employee having MiddleName is null";
            return RedirectToAction("Index");
        }
    }
}