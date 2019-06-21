using BlogPageMVC.Models;
using BlogPageMVC.Security;
using BlogPageMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogPageMVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(AccountViewModel avm)
        {
            AccountModel am = new AccountModel();
            if (string.IsNullOrEmpty(avm.account.Username) || string.IsNullOrEmpty(avm.account.PassWord) || am.Login(avm.account.Username, avm.account.PassWord) == null)
            {
                ViewBag.Error = "Tên đăng nhập hoặc password sai định dạng";
                return View("Index");
            }
            SessionPersister.UserName = avm.account.Username;
            return View("Success");
        }

        public ActionResult Logout()
        {
            SessionPersister.UserName = string.Empty;
            return RedirectToAction("Index");
        }
    }
}