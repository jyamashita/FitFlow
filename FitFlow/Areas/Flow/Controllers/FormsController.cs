using ActivitiClient.RestClients;
using FitFlow.Areas.Flow.Models.Views;
using FitFlow.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitFlow.Areas.Flow.Controllers
{
    public class FormsController : BaseController
    {
        //
        // GET: /Flow/Forms/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Flow/Forms/Start
        [HttpGet]
        public ActionResult Start(string key, int version, string processId)
        {
            var model = base.Client.ProcessDefinitions.GetResourcedata(string.Format("{0}:{1}:{2}", key, version, processId));
            return View(model);
        }

        //
        // GET: /Flow/Forms/Approve
        [HttpGet]
        public ActionResult Approve(int taskId)
        {
            var form = base.Client.Forms.Get(taskId);
            var task = base.Client.Tasks.Get(taskId);
            var def = base.Client.ProcessDefinitions.Get(task.ProcessDefinitionId);

            var formModel = new FormModel {
                Form = form,
                Task = task,
                ProcessDefinition = def
            };
            return View(formModel);
        }
	}
}