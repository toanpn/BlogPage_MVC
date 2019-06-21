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
using Newtonsoft.Json;

namespace BlogPageMVC.Controllers
{
    [AllowAnonymous]
    public class TagsController : Controller
    {
        private dbBlogEntities db = new dbBlogEntities();

        // GET: Tags
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.tbTags.ToList());
        }

        [AllowAnonymous]
        public string GetTagsJson()
        {
            var list = db.tbTags.Select(x => new { x.Name, x.Views, x.id }).ToList();
            return JsonConvert.SerializeObject(list);
        }
        // GET: Tags/Details/5
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTag tbTag = db.tbTags.Find(id);
            if (tbTag == null)
            {
                return HttpNotFound();
            }
            return View(tbTag);
        }

        // GET: Tags/Create
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "id,Name,Views")] tbTag tbTag)
        {
            if (ModelState.IsValid)
            {
                db.tbTags.Add(tbTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbTag);
        }

        // GET: Tags/Edit/5
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTag tbTag = db.tbTags.Find(id);
            if (tbTag == null)
            {
                return HttpNotFound();
            }
            return View(tbTag);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Views")] tbTag tbTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbTag);
        }

        // GET: Tags/Delete/5
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTag tbTag = db.tbTags.Find(id);
            if (tbTag == null)
            {
                return HttpNotFound();
            }
            return View(tbTag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbTag tbTag = db.tbTags.Find(id);
            db.tbTags.Remove(tbTag);
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
