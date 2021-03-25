using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab4MVC.filters;
using lab4MVC.Models;

namespace lab4MVC.Controllers
{[HandleError]
    [Auth]
    public class departmentController : Controller
    {
        // GET: department
        Entity e = new Entity();
        public ActionResult Index()
        {
            return View(e.Departments.ToList<department>());
        }
        public ActionResult create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult create(department d)
        {
            e.Departments.Add(d);
            e.SaveChanges();

            return RedirectToAction("index");
        }
        public ActionResult details(int id)
        {
            department dept = e.Departments.FirstOrDefault(s => s.dept_id == id);
            return PartialView(dept);
        }

    }
}