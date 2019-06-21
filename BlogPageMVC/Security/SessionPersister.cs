using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPageMVC.Security
{
    public static class SessionPersister
    {
        static string userNameSesiconVar = "userName";

        public static string UserName
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[userNameSesiconVar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[userNameSesiconVar] = value;
            }
        }
    }
}