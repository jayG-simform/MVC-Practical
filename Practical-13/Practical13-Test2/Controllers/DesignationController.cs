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
    public class DesignationController : Controller
    {
        // GET: Designation
        private CompanyDBContext db = new CompanyDBContext();
        public async Task<ActionResult> Index()
        {
            return View(await db.designations.ToListAsync());
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Designation des = await db.designations.FindAsync(id);
            if (des == null)
            {
                return View("Error");
            }
            return View(des);
        }
        public ActionResult Create()
        {
            return View(new Designation());
        }
        [HttpPost]
        public ActionResult Create(Designation des)
        {
            if (ModelState.IsValid)
            {
                db.designations.Add(des);
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
            Designation des = db.designations.Find(id);
            return View(des);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Designation des = db.designations.Find(id);
            if (des != null)
            {
                db.designations.Remove(des);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var des = db.designations.SingleOrDefault(e => e.Id == id);
            var result = new Designation()
            {
                DesignationName = des.DesignationName,
                
            };
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Designation model)
        {
            var des = new Designation()
            {
                Id = model.Id,
                DesignationName = model.DesignationName,
            };
            db.designations.AddOrUpdate(des);
            db.SaveChanges();
            TempData["error"] = "Record Updated!";
            return RedirectToAction("Index");
        }
    }
}