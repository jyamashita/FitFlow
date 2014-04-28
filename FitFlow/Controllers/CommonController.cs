using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitFlow.Models;
using FitFlow.Extensions;
using FitFlow.Models.Base;

namespace FitFlow.Controllers
{
    public class CommonController : Controller
    {
        //
        // GET: /Common/
        public ActionResult Menu()
        {
            List<Menu> dataList = null;
            using (var dbc = new FitFlowContext()) {
                dataList = dbc.Menus.NotDeleted().OrderBy(m => m.Order).ToList();
            }
            return View(dataList);
        }
	}
}