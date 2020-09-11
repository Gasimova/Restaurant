using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminPanel.Filter
{
    public class Logout:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Loginner"] == null)
            {
                filterContext.Result = new RedirectResult("~/AdminPanel/Home");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}