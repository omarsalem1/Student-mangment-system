using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab4MVC.filters
{
    public class Auth : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string uname = filterContext.HttpContext.Session["user"]?.ToString();
            if (uname == null)
                filterContext.Result = new RedirectResult("/acc/login?turl="+filterContext.HttpContext.Request.Url);
        }
    }
}