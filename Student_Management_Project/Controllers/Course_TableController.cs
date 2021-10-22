using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Student_Management_Project.Models;

namespace Student_Management_Project.Controllers
{
    public class Course_TableController : Controller
    {
        private Stdent_Management_SystemEntities db = new Stdent_Management_SystemEntities();

        // GET: Course_Table
        public ActionResult Index()
        {
            return View(db.Course_Table.ToList());
        }

        // GET: Course_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Table course_Table = db.Course_Table.Find(id);
            if (course_Table == null)
            {
                return HttpNotFound();
            }
            return View(course_Table);
        }

        // GET: Course_Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Course,Duration")] Course_Table course_Table)
        {
            if (ModelState.IsValid)
            {
                db.Course_Table.Add(course_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course_Table);
        }

        // GET: Course_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Table course_Table = db.Course_Table.Find(id);
            if (course_Table == null)
            {
                return HttpNotFound();
            }
            return View(course_Table);
        }

        // POST: Course_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Course,Duration")] Course_Table course_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course_Table);
        }

        // GET: Course_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Table course_Table = db.Course_Table.Find(id);
            if (course_Table == null)
            {
                return HttpNotFound();
            }
            return View(course_Table);
        }

        // POST: Course_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course_Table course_Table = db.Course_Table.Find(id);
            db.Course_Table.Remove(course_Table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
