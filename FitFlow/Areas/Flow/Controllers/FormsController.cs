using ActivitiClient.RestClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitFlow.Areas.Flow.Controllers
{
    public class FormsController : Controller
    {
        //
        // GET: /Flow/Forms/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Flow/Forms/Start
        public ActionResult Start(string key, int version, string id)
        {
            var client = new ActivitiRestClient("http://localhost:8080/activiti-rest/service", "kermit", "kermit");
            var model = client.ProcessDefinitions.GetResourcedata(string.Format("{0}:{1}:{2}", key, version, id));
            return View(model);
        }

        //
        // GET: /Flow/Forms/Update
        public ActionResult Update()
        {
            return View();
        }
	}
}