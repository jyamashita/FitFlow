using FitFlow.Models;
using FitFlow.Areas.Social.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitFlow.Areas.Social.Controllers
{
    [FitFlowFilterAttribute]
    public class DepartmentController : Controller
    {
        //
        // GET: /Social/Department/
        public ActionResult Find(string search)
        {
            using (var dbc = new FitFlowContext()) {
                var json = new {
                    data = dbc.Users.Select(u => new { Id = u.Id, Alias = u.Alias, Name = u.Name }).ToArray(),
                    head = new [] { "ID", "Alias", "Name" }
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }

        }

        //
        // GET: /Social/Department/
        public ActionResult List(string search)
        {
            using (var dbc = new FitFlowContext()) {
                var json = new {
                    data = dbc.Departments.Where(d => d.Name.Contains(search)).ToArray()
                        .Select(d => new[] { d.Id.ToString(), d.Name }),
                    head = new[] { "DepartmentId", "組織名" }
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }
	}
}