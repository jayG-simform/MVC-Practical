using Practical_12.Models;
using Practical_12.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_12.Controllers
{
    public class Test3Controller : Controller
    {
        TestEmployee db = new TestEmployee();
        public ActionResult Index()
        {
            var data = db.GetUser();
            return View(data);
        }
        public ActionResult Query1()
        {
            db.InsertDesignation();
            TempData["Message"] = "Insert Designation data";
            return RedirectToAction("Index");
        }
        public ActionResult Query_1()
        {
            db.InsertEmployee();
            TempData["Message"] = "Insert Employee data";
            return RedirectToAction("Index");
        }
        public ActionResult Query2()
        {
            var data = db.CountEmpByDesignation();
            return View(data);
        }
        public ActionResult Query3()
        {
            var data = db.Query3();
            return View(data);
        }
        public ActionResult Query4()
        {
            //db.CreateView();
            var data = db.FetchTheEmployeePerDesignations();
            return View(data);
        }
        public ActionResult Query5()
        {
            db.CreateTheStoreProcedureForInsertInDesignationTable();
            TempData["Message"] = "Created successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Query6()
        {
            db.CreateTheStoreProcedureForInsertInEmployeeTable();
            TempData["Message"] = "Created successfully";
            return RedirectToAction("Index");   
        }
        public ActionResult Query7()
        {
            var data = db.DesignationWhichHaveMoreThanOneEmployee();
            return View(data);
        }
        public ActionResult Query8()
        {
            var data = db.CreateStoredProcedureAndWhichGivesSortDatabyDOB();
            return View(data);
        }
        public ActionResult Query9()
        {
            var data = db.CreateStoredProcedureAndWhichGivesSortDatabyFirstName();
            return View(data);
        }
        public ActionResult Query10()
        {
            db.CreateClustredIndex();
            return RedirectToAction("Index");   
        }
        public ActionResult Query11()
        {
            var data = db.EmployeeMaxSalary();
            return View(data);
        }

    }
}