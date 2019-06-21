using BlogPageMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogPageMVC.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.UserName))
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                    (new { controller = "Account", action = "Index" }));
            else
            {
                AccountModel am = new AccountModel();
                CustomPrincipal mp = new CustomPrincipal(am.AccountFind(SessionPersister.UserName));
                if (!mp.IsInRole(Roles))
                    filterContext.Result = new RedirectToRouteResult(new
                        System.Web.Routing.RouteValueDictionary(new { controller = "AccessDenied", action = "Index" }));
            }
        }
    }
}