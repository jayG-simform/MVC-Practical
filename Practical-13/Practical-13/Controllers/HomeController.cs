using Practical_13.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Practical_13.Controllers
{
    public class HomeController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            var data = db.employees.ToList();
            return View(data);
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
                db.employees.Add(emp);
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
            Employee employee = db.employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee employee = db.employees.Find(id);
            if (employee != null)
            {
                db.employees.Remove(employee);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Employee employee = db.employees.Find(id);
            return View(employee);
        }
        public ActionResult Edit(int id)
        {
            var emp = db.employees.SingleOrDefault(e => e.Id == id);
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
            db.employees.AddOrUpdate(model);
            db.SaveChanges();
            TempData["error"] = "Record Updated!";
            return RedirectToAction("Index");
        }
    }
}