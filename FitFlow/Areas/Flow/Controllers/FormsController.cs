using ActivitiClient.Models;
using ActivitiClient.Models.Bpmn;
using ActivitiClient.RestClients;
using FitFlow.Areas.Flow.Models;
using FitFlow.Areas.Flow.Models.Views;
using FitFlow.Controllers;
using FitFlow.Service;
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
            var processDefinitionId = string.Format("{0}:{1}:{2}", key, version, processId);
            var model = base.Client.ProcessDefinitions.GetResourcedata(processDefinitionId);
            var processComplement = base.Dbc.ProcessComplements.Find(processDefinitionId);

            return View(new ProcessStartModel {
                ProcessName = model.Name,
                StartTask = model.StartEvent[0],
                ProcessComplements = FitFlowUtil.XmlToModel<ProcessComplement>(processComplement.Resource)
            });
        }

        //
        // GET: /Flow/Forms/Approve
        [HttpGet]
        public ActionResult Approve(int taskId)
        {
            var form = base.Client.Forms.Get(taskId);
            var task = base.Client.Tasks.Get(taskId);
            var def = base.Client.ProcessDefinitions.Get(task.ProcessDefinitionId);
            var processComplement = base.Dbc.ProcessComplements.Find(def.Id);

            var formModel = new FormModel {
                Form = form,
                Task = task,
                ProcessDefinition = def,
                ProcessComplements = FitFlowUtil.XmlToModel<ProcessComplement>(processComplement.Resource)
            };
            return View(formModel);
        }

        //
        // GET: /Flow/Forms/Detail
        [HttpGet]
        public ActionResult Detail(int processInstanceId)
        {
            var history = base.Client.History.Get(processInstanceId);

            List<ActivitiClient.Models.Bpmn.FormProperty> formProperties = null;
            var form = base.Client.Forms.Get(processDefinitionId: history.ProcessDefinitionId);
            var model = base.Client.ProcessDefinitions.GetResourcedata(history.ProcessDefinitionId);
            var processComplement = base.Dbc.ProcessComplements.Find(history.ProcessDefinitionId);

            // 未完了
            if (history.DeleteReason == null) {
                var variables = base.Client.ProcessInstances.Variables(processInstanceId);
                formProperties = model.StartEvent[0].DetailFormProperties(variables);
            }
            // 完了
            else {
                var variableInstance = base.Client.History.VariableInstances(processInstanceId);
                var variables = variableInstance.Select(v => v.Variable).ToList();
                formProperties = model.StartEvent[0].DetailFormProperties(variables);
            }
            var def = base.Client.ProcessDefinitions.Get(history.ProcessDefinitionId);

            var formModel = new ProcessDetailModel {
                History = history,
                FormProperties = formProperties,
                ProcessDefinition = def,
                ProcessComplements = FitFlowUtil.XmlToModel<ProcessComplement>(processComplement.Resource)
            };
            return View(formModel);
        }
	}
}