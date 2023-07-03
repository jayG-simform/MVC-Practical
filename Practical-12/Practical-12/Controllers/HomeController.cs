using Practical_12.Models;
using Practical_12.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Practical_12.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDAL dal = new EmployeeDAL();
        public ActionResult Index()
        {
            var Data = dal.GetUser();
            return View(Data);
        }
        public ActionResult Create()
        {
            return View(new Employee());
        }
        [HttpPost]
        public ActionResult Create(Employee emp) 
        {
            if (ModelState.IsValid)
            {
                dal.InsertEmp(emp);
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
            dal.DefaultUser();
            return RedirectToAction("Index");
        }

        public ActionResult FirstNameToSQL()
        {
            var data = dal.FirstNameToSQL();
            return RedirectToAction("Index",data);
        }

        public ActionResult MiddleNameTOI() 
        {
            var data = dal.MiddleNameTOI();
            return RedirectToAction("Index", data);
        }
        public ActionResult DeleteValue2()
        {
            var data = dal.DeleteValue2();
            return RedirectToAction("Index", data);
        }
        public ActionResult DeleteAll()
        {
           dal.DeleteAll();
           return RedirectToAction("Index");
        }
    }
}