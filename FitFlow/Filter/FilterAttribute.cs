using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitFlow.Filter
{
    public class vd : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            response.ClearHeaders();

            response.AppendHeader("Cache-Control", "private, no-cache, no-store, must-revalidate, max-stale=0, post-check=0, pre-check=0");
            response.AppendHeader("Pragma", "no-cache");
            response.AppendHeader("Expires", "-1");
        }
    }
}