using Student_Management_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management_Project.Controllers
{
    public class LoginController : Controller
    {
        Stdent_Management_SystemEntities db = new Stdent_Management_SystemEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User objchk)
        {
            if (ModelState.IsValid)
            {
                using(Stdent_Management_SystemEntities db = new Stdent_Management_SystemEntities())
                {
                    var obj = db.Users.Where(a => a.UserName.Equals(objchk.UserName) && a.Password.Equals(objchk.Password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserId"] = obj.Id.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "UserName or Password is incorrect");
                    }
                }
            }
           
            return View(objchk);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return  RedirectToAction("Index", "Login");
            
        }
    }
}