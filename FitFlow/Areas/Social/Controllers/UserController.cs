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
    public class UserController : Controller
    {
        //
        // GET: /Social/User/
        public ActionResult Find(string search)
        {
            using (var dbc = new FitFlowEntities()) {
                var json = new {
                    data = dbc.UserView.Select(u => new { UserId = u.Id, Name = u.Name }).ToArray(),
                    head = new [] { "UserId", "Name" }
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // GET: /Social/User/
        public ActionResult List(string search)
        {
            using (var dbc = new FitFlowEntities()) {
                var json = new {
                    data =
                        (from usr in dbc.UserView
                         join blg in dbc.Belongs on usr.Id equals blg.UserId
                         join grp in dbc.GroupView on blg.DepartmentId equals grp.Id
                         where usr.Name.Contains(search)
                         select new { usr.Id, usr.Name, DepartmentId = grp.Id, DepartmentName = grp.Name })
                        .ToArray()
                        .Select(u => new[] { u.DepartmentId, u.DepartmentName, u.Id, u.Name }),
                    head = new[] { "DepartmentId", "組織名", "UserId", "氏名" },
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }
	}
}