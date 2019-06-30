using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogPageMVC.Models;
using BlogPageMVC.Security;

namespace BlogPageMVC.Controllers
{
    [CustomAuthorize(Roles = "admin")]
    public class CategoriesController : Controller
    {
        private dbBlogEntities db = new dbBlogEntities();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.tbCategories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCategory tbCategory = db.tbCategories.Find(id);
            if (tbCategory == null)
            {
                return HttpNotFound();
            }
            return View(tbCategory);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Views")] tbCategory tbCategory)
        {
            if (ModelState.IsValid)
            {
                db.tbCategories.Add(tbCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbCategory);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCategory tbCategory = db.tbCategories.Find(id);
            if (tbCategory == null)
            {
                return HttpNotFound();
            }
            return View(tbCategory);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Views")] tbCategory tbCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbCategory);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCategory tbCategory = db.tbCategories.Find(id);
            if (tbCategory == null)
            {
                return HttpNotFound();
            }
            return View(tbCategory);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {

            tbCategory tbCategory = db.tbCategories.Find(id);
            db.tbPost_Category.RemoveRange(db.tbPost_Category.Where(x => x.Category_id == id));
            db.tbCategories.Remove(tbCategory);
            db.SaveChanges();
            return RedirectToAction("Index");

            } catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
