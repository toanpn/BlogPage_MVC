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
using PagedList;

namespace BlogPageMVC.Controllers
{
    [CustomAuthorize(Roles = "admin")]
    public class CategoriesController : Controller
    {
        private dbBlogEntities db = new dbBlogEntities();

        // GET: Tags
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index(int? page)
        {
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageCount = db.tbCategories.Count() / pageSize + 1;
            return View(db.tbCategories.OrderByDescending(x => x.Views).ToPagedList(pageNumber, pageSize).ToList());
        }

        [AllowAnonymous]
        public string GetCategoriesJson()
        {
            var list = db.tbTags.Select(x => new { x.Name, x.Views, x.id }).ToList();
            return JsonConvert.SerializeObject(list);
        }
        // GET: Tags/Details/5
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCategory category = db.tbCategories.Find(id);
            if(category == null)
            {
                return HttpNotFound();
            }
            return View(category);
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
        public ActionResult Create(string name)
        {
            tbCategory t = new tbCategory()
            {
                Name = name,
                Views = 0
            };
            if(ModelState.IsValid)
            {
                db.tbCategories.Add(t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Tags/Edit/5
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCategory tbCategory = db.tbCategories.Find(id);
            if(tbCategory == null)
            {
                return HttpNotFound();
            }
            return View(tbCategory);
        }

        // POST: Tags/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string name)
        {
            if(ModelState.IsValid)
            {
                db.tbCategories.Find(id).Name = name;
                //db.Entry(tbTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Tags/Delete/5
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCategory tbCategory = db.tbCategories.Find(id);
            if(tbCategory == null)
            {
                return HttpNotFound();
            }
            return View(tbCategory);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbCategory tbCategory = db.tbCategories.Find(id);
            db.tbPost_Category.RemoveRange(db.tbPost_Category.Where(x => x.Category_id == id));
            db.tbCategories.Remove(tbCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
