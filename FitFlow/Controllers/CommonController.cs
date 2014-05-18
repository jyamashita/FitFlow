using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitFlow.Models;
using FitFlow.Extensions;
using FitFlow.Models.Base;
using FitFlow.Constants;
using FitFlow.Models.Views;

namespace FitFlow.Controllers
{
    public class CommonController : BaseController
    {
        //
        // GET: /Common/
        public ActionResult Menu()
        {
            var myProcessCnt = base.Dbc.UnCompletedProcess.Where(p => p.StartUser == LoginUser.Id).Count();

            var myTaskCnt = base.Dbc.UnCompletedTask.Where(t => t.TaskAssignee == LoginUser.Id).Count();

            var dataList = base.Dbc.Menus.Where(m => m.DeleteFlg == DeleteFlg.Off).OrderBy(m => m.Order).ToList();

            return View(new MenuModel { 
                MyTaskCnt = myTaskCnt,
                MyProcessCnt = myProcessCnt,
                MenuList = dataList
            });
        }
	}
}