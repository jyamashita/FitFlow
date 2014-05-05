using FitFlow.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitFlow.Areas.Security.Controllers
{
    public class SecurityAssessmentController : BaseController
    {
        //
        // GET: /Security/SecurityAssessment/
        public ActionResult Index()
        {
            return View();
        }
	}
}