using ActivitiClient.RestClients;
using ActivitiClient.Extensions;
using FitFlow.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitFlow.Areas.Flow.Controllers
{
    public class TasksController : Controller
    {
        //
        // GET: /Flow/Tasks/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Flow/Tasks/Action
        public RedirectToRouteResult Action(FormCollection form)
        {
            var client = new ActivitiRestClient(Settings.Default.ActivitiRestUrl, "kermit", "kermit");
            var process = client.ProcessDefinitions.GetResourcedata(form.Get("processDefinitionId"));
            client.Tasks.Post(form.Get("taskId").ToInt(), RestClientBase.Action.complete, process.Extract(form));
            return RedirectToAction("Index", "Process");
        }
	}
}