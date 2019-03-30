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
    public class tbPostsController : Controller
    {
        private dbBlogEntities db = new dbBlogEntities();

        // GET: tbPosts
        public async Task<ActionResult> Index()
        {
            return View(await db.tbPosts.ToListAsync());
        }

        // GET: tbPosts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPost tbPost = await db.tbPosts.FindAsync(id);
            if (tbPost == null)
            {
                return HttpNotFound();
            }
            return View(tbPost);
        }

        // GET: tbPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Tittle,Url,ShortContent,Content,Views,Shares,DateCreate,DatePublish,Visiable,Comments")] tbPost tbPost)
        {
            if (ModelState.IsValid)
            {
                db.tbPosts.Add(tbPost);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbPost);
        }

        // GET: tbPosts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPost tbPost = await db.tbPosts.FindAsync(id);
            if (tbPost == null)
            {
                return HttpNotFound();
            }
            return View(tbPost);
        }

        // POST: tbPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Tittle,Url,ShortContent,Content,Views,Shares,DateCreate,DatePublish,Visiable,Comments")] tbPost tbPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbPost).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbPost);
        }

        // GET: tbPosts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPost tbPost = await db.tbPosts.FindAsync(id);
            if (tbPost == null)
            {
                return HttpNotFound();
            }
            return View(tbPost);
        }

        // POST: tbPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbPost tbPost = await db.tbPosts.FindAsync(id);
            db.tbPosts.Remove(tbPost);
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
