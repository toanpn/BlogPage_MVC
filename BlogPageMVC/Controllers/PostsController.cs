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
using BlogPageMVC.ViewModel;
using BlogPageMVC.Security;

namespace BlogPageMVC.Controllers
{
    public class PostsController : Controller
    {
        private dbBlogEntities db = new dbBlogEntities();

        // GET: Posts
        [AllowAnonymous]
        public async Task<ActionResult> Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPost tbPost = await db.tbPosts.FindAsync(id);
            inCreaseView(tbPost);
            if (tbPost == null)
            {
                return HttpNotFound();
            }
            PostViewModel viewModel = new PostViewModel(tbPost);

            return View(viewModel);
        }

        private void inCreaseView(tbPost post)
        {
            post.Views++;
            foreach(var i in db.tbCategories.Where(p => p.tbPost_Category.Any(c => c.Post_id == post.id)))
            {
                if(i.Views == null) i.Views = 0;
                i.Views++;
            }
            foreach(var i in db.tbTags.Where(p => p.tbPost_Tag.Any(c => c.Post_id == post.id)))
            {
                if(i.Views == null) i.Views = 0;
                i.Views++;
            }
            db.SaveChanges();
        }
        private IEnumerable<SelectListItem> GetListTags()
        {
            var res = db
                        .tbTags
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.id.ToString(),
                                    Text = "# " +   x.Name
                                });

            return new SelectList(res, "Value", "Text");
        }


        private IEnumerable<SelectListItem> GetListCategories()
        {
            var res = db
                        .tbCategories
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.id.ToString(),
                                    Text = "# " + x.Name
                                });
            return new SelectList(res, "Value", "Text");
        }

        // GET: Posts/Create
        [CustomAuthorize(Roles ="admin")]
        public ActionResult Create()
        {
            //var model = new EditPostViewModel { ListCategories = GetListCategories() };
            var model = new EditPostViewModel
            {
                SelectedListTagId = new[] { 1 },
                ListTag = GetListTags(),
                ListCategories = GetListCategories()
            };
            return View(model);
        }

        // POST: Posts/Create
        [CustomAuthorize(Roles = "admin")]
        [HttpPost, ValidateInput(false)]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EditPostViewModel post)
        {
            System.Diagnostics.Debug.WriteLine(post);
            post.ListCategories = GetListCategories();
            post.ListTag = GetListTags();
            if (ModelState.IsValid)
            {
                post.DatePublish = DateTime.Today;
                //post = DateTime.Today;
                post.Visiable = true;
                try
                {
                    tbPost p = new tbPost();
                    p.Content = post.Content;
                    p.DateCreate = post.DatePublish; //
                    p.DatePublish = post.DatePublish;
                    p.Shares = post.Shares;
                    p.ShortContent = post.ShortContent;
                    p.Tittle = post.Tittle;
                    p.Url = post.Url;
                    p.Views = post.Views;
                    p.Visiable = post.Visiable;
                    p.tbPost_Category = new List<tbPost_Category>();
                    p.tbPost_Category.Add(new tbPost_Category { Category_id = post.SelectedCategoryId });
                    p.tbPost_Tag = new List<tbPost_Tag>();
                    foreach(var tagId in post.SelectedListTagId)
                    {
                        p.tbPost_Tag.Add(new tbPost_Tag { Tag_id = tagId });
                    }
                    //p.tbPost_Tag = post.tbPost_Tag;
                    //p.tbPost_Category = 
                    db.tbPosts.Add(p);
                    await db.SaveChangesAsync();
                    //TempData["SuccessMessage"] = "Success";
                }
                catch (Exception e)
                {
                    throw e;
                }
                return RedirectToAction("Index", "Home");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        [CustomAuthorize(Roles = "admin")]
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

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "admin")]
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

        // GET: Posts/Delete/5
        [CustomAuthorize(Roles = "admin")]
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

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            tbPost tbPost = db.tbPosts.Find(id);
            db.tbPost_Category.RemoveRange(db.tbPost_Category.Where(x => x.Post_id == id));
            db.tbPost_Tag.RemoveRange(db.tbPost_Tag.Where(x => x.Post_id == id));
            db.tbPosts.Remove(tbPost);
            db.SaveChanges();
            return RedirectToAction("ManagerPost", "Home");
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
