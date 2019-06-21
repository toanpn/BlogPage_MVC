using BlogPageMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPageMVC.ViewModel
{
    public class ViewModelBase
    {
        // thuộc tính <title>
        public string PageTitle { get; set; }

        protected dbBlogEntities db = new dbBlogEntities();
    }
}