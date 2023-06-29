using Practical_11.Data;
using Practical_11.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Practical_11.Controllers
{
    public class HomeController : Controller
    {
     
        public ActionResult Index()
        {
            return View(EmployeeData.employees);
        }
         
        public ActionResult Delete(int? id)
        {
            var st = EmployeeData.employees.Find(e => e.Id == id);
            return View(st);
        }

        [HttpPost]
        public ActionResult Delete(Employee em)
        {
            var st = EmployeeData.employees.Find(e => e.Id == em.Id);
            EmployeeData.employees.Remove(st);

            TempData["Message"] = "Record Deleted!";
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View(new Employee());
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                int id = EmployeeData.employees.Count + 1;
                var emp = new Employee()
                {
                    Id = id,
                    Name = model.Name,
                    DOB = model.DOB,
                    Address = model.Address
                };
                EmployeeData.employees.Add(emp);
                TempData["Message"] = "Record Added!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "Empty filed can't Submit";
                return View(model);
            }
        }


        public ActionResult Edit(int id)
        {
            var emp = EmployeeData.employees.SingleOrDefault(e => e.Id == id);
            var result = new Employee()
            {
                Id = emp.Id,
                Name = emp.Name,
                DOB = emp.DOB,
                Address = emp.Address
            };
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id,Employee model)
        {
            var emp = EmployeeData.employees.Find(e => e.Id == id);
            emp.Name = model.Name;
            emp.DOB = model.DOB;
            emp.Address = model.Address;

            TempData["Message"] = "Record Updated!";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var emp = EmployeeData.employees.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }
    }
}