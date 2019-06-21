using BlogPageMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BlogPageMVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private dbBlogEntities db = new dbBlogEntities();
        
        public ActionResult Index(int? page)
       {
            //int pageNumber = (page ?? 1);

            ViewBag.ListCategory = db.tbCategories.OrderByDescending(x => x.Views).Take(10).ToList();
            return View(db.tbPosts.ToList());
        }

        public ActionResult Tag(int _id)
        {
            //// get all tag by post id
            //var results = db.tbPosts.SelectMany(n => n.tbPost_Tag)
            //                  .Where(c => c.Post_id == _id).ToList();

            //// get all post by tag id
            var results = db.tbPosts.Where(p => p.tbPost_Tag.Any(c => c.Tag_id == _id)).ToList();
            ViewBag.isCrawByTag = true;
            ViewBag.tagName = db.tbTags.FirstOrDefault(x => x.id == _id).Name;

            ViewBag.ListCategory = db.tbCategories.OrderByDescending(x => x.Views).Take(10).ToList();

            return View("Index", results);
        }

        public ActionResult Category(int _id)
        {
            //// get all category by post id
            //var results = db.tbPosts.SelectMany(n => n.tbPost_Tag)
            //                  .Where(c => c.Post_id == _id).ToList();

            //// get all post by category id
            var results = db.tbPosts.Where(p => p.tbPost_Category.Any(c => c.Category_id == _id)).ToList();
            ViewBag.isCrawByTag = true;
            ViewBag.tagName = db.tbCategories.FirstOrDefault(x => x.id == _id).Name;

            ViewBag.ListCategory = db.tbCategories.OrderByDescending(x => x.Views).Take(10).ToList();

            return View("Index", results);
        }
    }
}