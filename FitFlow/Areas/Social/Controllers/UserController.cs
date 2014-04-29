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
    public class UserController : Controller
    {
        //
        // GET: /Social/User/
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
        // GET: /Social/User/
        public ActionResult List(string search)
        {
            using (var dbc = new FitFlowContext()) {
                var json = new {
                    data = dbc.Users.Join(dbc.Belongs, u => u.Id, b => b.UserId, (u, b) => new { u.Id, u.Name, DepartmentId = b.DepartmentId, DepartmentName = b.Department.Name })
                        .Where(u => u.Name.Contains(search))
                        .ToArray()
                        .Select(u => new[] { u.DepartmentId.ToString(), u.DepartmentName, u.Id.ToString(), u.Name }),
                    head = new[] { "DepartmentId", "組織名", "UserId", "氏名" },
                };
                //var json = new {
                //    data = dbc.Users.Join(dbc.Belongs, u => u.Id, b => b.UserId, (u, b) => new { u.Id, u.Name, DepartmentId = b.DepartmentId, DepartmentName = b.Department.Name })
                //        .Where(u => u.Name.Contains(search))
                //        .ToArray()
                //        .Select(u => new {
                //            DepartmentId = u.DepartmentId.ToString(),
                //            組織名 = u.DepartmentName,
                //            UserId = u.Id.ToString(),
                //            氏名 = u.Name,
                //            string.Empty
                //        }),
                //    head = new[] { "DepartmentId", "組織名", "UserId", "氏名", string.Empty }
                //};
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }
	}
}