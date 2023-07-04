using Practical_14.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace Practical_14.Controllers
{
    public class HomeController : Controller
    {
        DbEntities db = new DbEntities();
        public ActionResult Index(int? i)   
        {
            return View(db.Employees.ToList().ToPagedList(i ?? 1,10));
        }
        public JsonResult SearchEmployee(string search,int? i)
        {
            if (search == "")
            {
                return Json(db.Employees.ToList().ToPagedList(i ?? 1, 10));
            }
            return Json(db.Employees.Where(e => e.Name.ToLower().StartsWith(search.ToLower()) || search == null), JsonRequestBehavior.AllowGet);
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
                db.Employees.Add(emp);
                db.SaveChanges();
                TempData["Message"] = "Record Added!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "Empty filed can't Submit";
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int? id)
        {
            Employee employee = db.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Employee employee = db.Employees.Find(id);
            return View(employee);
        }
        public ActionResult Edit(int id)
        {
            var emp = db.Employees.SingleOrDefault(e => e.Id == id);
            var result = new Employee()
            {
                Name = emp.Name,
                DOB = emp.DOB,
                Age = emp.Age
            };
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            db.Employees.AddOrUpdate(model);
            db.SaveChanges();
            TempData["error"] = "Record Updated!";
            return RedirectToAction("Index");
        }
    }
}