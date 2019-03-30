﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogPageMVC.Models;

namespace BlogPageMVC.Controllers
{
    public class tbCategoriesController : Controller
    {
        private dbBlogEntities db = new dbBlogEntities();

        // GET: tbCategories
        public ActionResult Index()
        {
            return View(db.tbCategories.ToList());
        }

        // GET: tbCategories/Details/5
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

        // GET: tbCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbCategories/Create
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

        // GET: tbCategories/Edit/5
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

        // POST: tbCategories/Edit/5
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

        // GET: tbCategories/Delete/5
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

        // POST: tbCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbCategory tbCategory = db.tbCategories.Find(id);
            db.tbCategories.Remove(tbCategory);
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