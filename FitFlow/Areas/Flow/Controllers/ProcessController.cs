using FitFlow.Controllers;
using FitFlow.Models.FitFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitFlow.Areas.Flow.Controllers
{
    public class ProcessController : BaseController
    {
        //
        // GET: /Flow/ProcessModel/
        public ActionResult Mine()
        {
            //var mine = base.Dbc.RunProcess.Where(p => p.Initiator == LoginUser.Id).ToList();

            var mine = base.Dbc.UnCompletedProcess.ToList();
            return View(mine);
        }
	}
}