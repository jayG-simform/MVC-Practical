using Practical13_Test2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Practical13_Test2.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyDBContext db = new CompanyDBContext();
        public async Task<ActionResult> Index()
        {
            var emp = db.employees.Include(e => e.Designation);
            return View(await emp.ToListAsync());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var employees = db.employees.Include(e => e.Designation).ToList();
            var emp = employees.ToList().Find(i => i.Id == id);
            if (emp == null)
            {
                return View("Error");
            }
            return View(emp);
        }
        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(db.designations, "Id", "DesignationName");
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
            return View(emp);
        }
        public ActionResult Delete(int? id)
        {
            var employees = db.employees.Include(e => e.Designation).ToList();
            var emp = employees.ToList().Find(i => i.Id == id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee emp = db.employees.Find(id);
            if (emp != null)
            {
                db.employees.Remove(emp);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var employees = db.employees.Include(e => e.Designation).ToList();
            var emp = employees.ToList().Find(i => i.Id == id);
            if (emp == null)
            {
                return View("Error");
            }
            ViewBag.DesignationID = new SelectList(db.designations, "Id", "DesignationName", emp.DesignationID);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                TempData["error"] = "Record Updated!";
                return RedirectToAction("Index");
            }
            ViewBag.DesignationID = new SelectList(db.designations, "Id", "DesignationName", model.DesignationID);
            return View(model);
        }

        public ActionResult Linq1()
        {
            var linq = (from e in db.employees
                      join des in db.designations
                      on e.DesignationID equals des.Id
                      select new EmpDesg
                      {
                          Emp = e, Desg= des
                      }).ToList();

            return View(linq);
        }
        public ActionResult Linq2()
        {
            var linq = db.employees
                       .GroupBy(e => e.Designation.DesignationName)
                       .Select(g => new EmpCount(){ Designations = g.Key, Empcount = g.Count() }).ToList();

            return View(linq);
        }
    }
}