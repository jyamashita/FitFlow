using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FitFlow.Controllers;
using FitFlow.Models.FitFlow;
using FitFlow.Extensions;
using FitFlow.Extensions.DB;
using FitFlow.Service;
using ActivitiClient.Models;
using FitFlow.Areas.Flow.Models;

namespace FitFlow.Areas.Flow.Controllers
{
    public class DeployController : BaseController
    {
        //
        // GET: /Flow/Deploy/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Flow/Deploy/Run
        [HttpPost]
        public RedirectToRouteResult Run(HttpPostedFileBase depfile)
        {
            try {
                var filename = Path.GetFileName(depfile.FileName);
                if (!filename.Contains(".fitflow.xml")) {
                    throw new Exception("ファイル名が不正です。");
                }
                var processKey = filename.Replace(".fitflow.xml", string.Empty);
                var processDefinitionId = base.ADbc.ACT_RE_PROCDEF.Where(d => d.KEY_ == processKey)
                    .OrderByDescending(d => d.VERSION_).Select(d => d.ID_).FirstOrDefault();

                if (processDefinitionId == null) {
                    throw new Exception("プロセスキーが見つかりません。");
                }
                var stream = new MemoryStream();
                depfile.InputStream.CopyTo(stream);
                var xml = Encoding.UTF8.GetString(stream.ToArray());
                var model = FitFlowUtil.XmlToModel<ProcessComplement>(xml);

                var ProcessComplements = new ProcessComplements {
                    ProcessDefinitionId = processDefinitionId,
                    ProcessKey = processKey,
                    Resource = FitFlowUtil.ModelToXml(model)
                };
                FitFlowUtil.Transform(dbc => {
                    var record = dbc.ProcessComplements.Find(processDefinitionId);
                    if (record == null) {
                        dbc.ProcessComplements.Add(ProcessComplements);
                    }
                    else {
                        record.Resource = ProcessComplements.Resource;
                    }
                    dbc.SaveChanges();
                });
                var deployment = new Deployment {
                    Name = filename,
                    DeploymentTime = DateTime.Now
                };
                TempData["Deployment"] = deployment;
            }
            catch(Exception ex) {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction("Index", "Deploy");
        }
        //
        // POST: /Flow/Deploy/Run
        [HttpPost]
        public RedirectToRouteResult Run2(HttpPostedFileBase depfile/*, string deployname*/)
        {
            var deployment = base.Client.Deployment.Create(depfile.InputStream, Path.GetFileName(depfile.FileName));

            TempData["Deployment"] = deployment;

            return RedirectToAction("Index", "Deploy");
        }
	}
}