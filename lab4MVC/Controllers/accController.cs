using lab4MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab4MVC.Controllers
{
    public class accController : Controller
    {
        Entity db = new Entity();
        // GET: acc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login(string turl) {
            ViewBag.turl = turl;

            return View();
                }
        [HttpPost]
        public ActionResult login(login up,string  turl)
        {
            student s = db.Students.FirstOrDefault(a => a.username == up.username && a.password == up.password);
            if (s == null) {
                ModelState.AddModelError("", "username or password is not correct");
                 return View(up);
            }
            else
            {
                Session["user"] = s.username;
                if (turl != null) {
                    return Redirect(turl);
              }
                else
                {
                    
                    return RedirectToAction("details", "student", new { id = s.id });
                }
            }

           
        }
        public ActionResult logout(login up, string returnurl)
        {
            Session.Clear();
            return RedirectToAction("login");
        }

        }
}