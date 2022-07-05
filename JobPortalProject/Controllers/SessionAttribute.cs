using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortalProject.Controllers
{
    public class SessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Id"] == null)
            {
                filterContext.Result = new RedirectResult("~\\Home\\Login");

            }
            base.OnActionExecuting(filterContext);
        }
    }
}