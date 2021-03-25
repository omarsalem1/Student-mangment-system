using lab4MVC.filters;
using lab4MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab4MVC.Controllers
{ 
    [Auth]
    [HandleError]
    public class studentController : Controller
    {
       
        // GET: student
        Entity e = new Entity();
        public ActionResult Index()
        {
            //string usr = Session["user"]?.ToString();
            //if (usr != null) { 
            return View(e.Students.ToList<student>());/*}*/
            //else
            //{
               
            //    return RedirectToAction("login", "acc",new { turl = "/student/index" });
            //}
        }
        [HttpGet]
        public ActionResult create()
        {
            ViewBag.s = new SelectList(e.Departments.ToList<department>(), "dept_id", "dept_name");
            return View();
        }
        [HttpPost]
        public ActionResult create(student s)
        {
            if (ModelState.IsValid) {
            e.Students.Add(s);
            e.SaveChanges();

            return RedirectToAction("index");
            }
            ViewBag.s = new SelectList(e.Departments.ToList<department>(), "dept_id", "dept_name",s.Dept_id);
            return View(s);
        }
        public ActionResult checkun(string username,int? id)
        {
            student std=e.Students.FirstOrDefault(s => s.username == username);
            
            if (std == null )
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            if (id != null)
            {
                student si = e.Students.FirstOrDefault(s => s.id == id);
                if (si.username == username)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);

                }
                else { return Json(false, JsonRequestBehavior.AllowGet); }

            }
            else {  return Json(false, JsonRequestBehavior.AllowGet);}
            
            

           
        }
        public ActionResult details(int id)
        {
            student std = e.Students.FirstOrDefault(s => s.id == id);
            return PartialView(std);
        }
        public ActionResult edit(int id)
        {
            student std = e.Students.FirstOrDefault(s => s.id == id);
            std.co_password = std.password;
            ViewBag.s = new SelectList(e.Departments.ToList<department>(), "dept_id", "dept_name", std.Dept_id);
            return View(std);
        }
        [HttpPost]
        public ActionResult edit(student std)
        {
            if (ModelState.IsValid) { 
            student oldstd = e.Students.FirstOrDefault(s => s.id == std.id);
            oldstd.name = std.name;
            oldstd.age = std.age;
            oldstd.Dept_id = std.Dept_id;
            oldstd.email = std.email;
            oldstd.password = std.password;
                oldstd.co_password = std.co_password;
            oldstd.username = std.username;
                e.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.s = new SelectList(e.Departments.ToList<department>(), "dept_id", "dept_name", std.Dept_id);
            return View(std);

        }
        public ActionResult delete(int id)
        {
            student std = e.Students.FirstOrDefault(s => s.id == id);
            e.Students.Remove(std);
            e.SaveChanges();
          return  RedirectToAction("index");

        }
        }
}