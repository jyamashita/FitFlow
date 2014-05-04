using FitFlow.Models;
using FitFlow.Areas.Social.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitFlow.Models.FitFlow;

namespace FitFlow.Areas.Social.Controllers
{
    [FitFlowFilterAttribute]
    public class DepartmentController : Controller
    {
        //
        // GET: /Social/Department/
        public ActionResult Find(string id)
        {
            using (var dbc = new FitFlowEntities()) {
                var json = new {
                    data = dbc.GroupView.Where(d => d.Id == id).ToArray()
                        .Select(d => new[] { d.Id, d.Name }).Single(),
                    head = new[] { "DepartmentId", "組織名" }
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // GET: /Social/Department/
        public ActionResult List(string search)
        {
            using (var dbc = new FitFlowEntities()) {
                var json = new {
                    data = dbc.GroupView.Where(d => d.Name.Contains(search)).ToArray()
                        .Select(d => new[] { d.Id.ToString(), d.Name }),
                    head = new[] { "DepartmentId", "組織名" }
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }
	}
}