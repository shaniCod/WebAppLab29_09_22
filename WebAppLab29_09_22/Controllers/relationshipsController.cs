using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppLab29_09_22.Models;

namespace WebAppLab29_09_22.Controllers
{
    public class relationshipsController : Controller
    {
        private ClasslectureEntities db = new ClasslectureEntities();

        // GET: relationships
        public ActionResult Index()
        {
            var relationships = db.relationships.Include(r => r.Student).Include(r => r.Teacher);
            return View(relationships.ToList());
        }

        // GET: relationships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            relationship relationship = db.relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }
            return View(relationship);
        }

        // GET: relationships/Create
        public ActionResult Create()
        {
            ViewBag.SID = new SelectList(db.Students, "SID", "FirstName");
            ViewBag.TID = new SelectList(db.Teachers, "TID", "FirstName");
            return View();
        }

        // POST: relationships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RID,SID,TID")] relationship relationship)
        {
            if (ModelState.IsValid)
            {
                db.relationships.Add(relationship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SID = new SelectList(db.Students, "SID", "FirstName", relationship.SID);
            ViewBag.TID = new SelectList(db.Teachers, "TID", "FirstName", relationship.TID);
            return View(relationship);
        }

        // GET: relationships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            relationship relationship = db.relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }
            ViewBag.SID = new SelectList(db.Students, "SID", "FirstName", relationship.SID);
            ViewBag.TID = new SelectList(db.Teachers, "TID", "FirstName", relationship.TID);
            return View(relationship);
        }

        // POST: relationships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RID,SID,TID")] relationship relationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SID = new SelectList(db.Students, "SID", "FirstName", relationship.SID);
            ViewBag.TID = new SelectList(db.Teachers, "TID", "FirstName", relationship.TID);
            return View(relationship);
        }

        // GET: relationships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            relationship relationship = db.relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }
            return View(relationship);
        }

        // POST: relationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            relationship relationship = db.relationships.Find(id);
            db.relationships.Remove(relationship);
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
