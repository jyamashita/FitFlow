using ActivitiClient.RestClients;
using FitFlow.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitFlow.Areas.Flow.Controllers
{
    public class ProcessDefinitionsController : Controller
    {
        //
        // GET: /Flow/ProcessDefinitions/
        public ActionResult Index()
        {
            var client = new ActivitiRestClient(Settings.Default.ActivitiRestUrl, "kermit", "kermit");
            var list = client.ProcessDefinitions.List(latest: true, suspended: false, size: 15);
            return View(list);
        }

        public RedirectToRouteResult Start(string id)
        {
            var client = new ActivitiRestClient(Settings.Default.ActivitiRestUrl, "kermit", "kermit");
            client.ProcessInstances.Start(id);
            return RedirectToAction("Update", "Forms", new { processDefinitionId = id });
        }
	}
}