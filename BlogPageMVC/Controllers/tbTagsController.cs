using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogPageMVC.Models;

namespace BlogPageMVC.Controllers
{
    public class tbTagsController : Controller
    {
        private dbBlogEntities db = new dbBlogEntities();

        // GET: tbTags
        public async Task<ActionResult> Index()
        {
            return View(await db.tbTags.ToListAsync());
        }

        // GET: tbTags/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTag tbTag = await db.tbTags.FindAsync(id);
            if (tbTag == null)
            {
                return HttpNotFound();
            }
            return View(tbTag);
        }

        // GET: tbTags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Name,Views")] tbTag tbTag)
        {
            if (ModelState.IsValid)
            {
                db.tbTags.Add(tbTag);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbTag);
        }

        // GET: tbTags/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTag tbTag = await db.tbTags.FindAsync(id);
            if (tbTag == null)
            {
                return HttpNotFound();
            }
            return View(tbTag);
        }

        // POST: tbTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Name,Views")] tbTag tbTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbTag).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbTag);
        }

        // GET: tbTags/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTag tbTag = await db.tbTags.FindAsync(id);
            if (tbTag == null)
            {
                return HttpNotFound();
            }
            return View(tbTag);
        }

        // POST: tbTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbTag tbTag = await db.tbTags.FindAsync(id);
            db.tbTags.Remove(tbTag);
            await db.SaveChangesAsync();
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
