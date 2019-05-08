using BlogPageMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BlogPageMVC.Controllers
{
    public class HomeController : Controller
    {
        private dbBlogEntities db = new dbBlogEntities();


        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            var a = db.tbPosts.ToList().ToPagedList(pageNumber, 1);
            return View(db.tbPosts.ToList().ToPagedList(pageNumber, 1));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}