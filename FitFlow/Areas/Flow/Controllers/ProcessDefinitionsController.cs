using ActivitiClient.RestClients;
using FitFlow.Controllers;
using FitFlow.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitFlow.Areas.Flow.Controllers
{
    public class ProcessDefinitionsController : BaseController
    {
        //
        // GET: /Flow/ProcessDefinitions/
        public ActionResult Index()
        {
            //var list = base.Client.ProcessDefinitions.List(latest: true, suspended: false, size: 15);
            var list = (from def in ADbc.ACT_RE_PROCDEF
                         from newdef in ADbc.ACT_RE_PROCDEF.GroupBy(d => d.KEY_)
                            .Select(g => new { Key = g.Key, Version = g.Max(m => m.VERSION_) })
                         where    def.KEY_ == newdef.Key
                               && def.VERSION_ == newdef.Version
                               && def.SUSPENSION_STATE_ == 1
                         select def).ToList();

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