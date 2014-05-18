using ActivitiClient.Extensions;
using ActivitiClient.RestClients;
using FitFlow.Areas.Flow.Models.Views;
using FitFlow.Constants;
using FitFlow.Controllers;
using FitFlow.Extensions;
using System.Linq;
using System.Web.Mvc;

namespace FitFlow.Areas.Flow.Controllers
{
    public class TasksController : BaseController
    {
        //
        // GET: /Flow/Tasks/
        public ActionResult Index()
        {
            var taks = (
                from task in base.ADbc.ACT_RU_TASK.Where(t => t.ASSIGNEE_ == LoginUser.Id)
                join def in base.ADbc.ACT_RE_PROCDEF on task.PROC_DEF_ID_ equals def.ID_
                join ins in base.ADbc.ACT_HI_PROCINST on task.PROC_INST_ID_ equals ins.ID_
                join usr in base.ADbc.ACT_ID_USER on ins.START_USER_ID_ equals usr.ID_
                select new {
                    ProcessInstanceId = task.PROC_INST_ID_,
                    ProcessName = def.NAME_,
                    Assignee = task.ASSIGNEE_,
                    Description = task.DELEGATION_,
                    AssignDateTime = task.CREATE_TIME_.Value,
                    TaskId = task.ID_,
                    TaskName = task.NAME_,
                    InitiatorLastName = usr.LAST_,
                    InitiatorFirstName = usr.FIRST_
                }).ToList()
                .Select(task => new MyTaskModel{
                    ProcessInstanceId = int.Parse(task.ProcessInstanceId),
                    ProcessName = task.ProcessName,
                    TaskName = task.TaskName,
                    Assignee = task.Assignee,
                    Description = task.Description,
                    AssignDateTime = task.AssignDateTime,
                    TaskId = int.Parse(task.TaskId),
                    Initiator = string.Format("{0}　{1}", task.InitiatorLastName, task.InitiatorFirstName)
                }).ToList();

            return View(taks);
        }

        //
        // POST: /Flow/Tasks/Start
        [HttpPost]
        public RedirectToRouteResult Start(FormCollection form)
        {
            // BPMN定義取得
            var processDefinitionId = form.Get("processDefinitionId");
            var process = base.Client.ProcessDefinitions.GetResourcedata(processDefinitionId);

            // POSTパラメタよりフォーム値抽出
            var variables = process.Extract(form);

            // タスク実行時、システム固定付随情報設定
            var rootGroupLeader = base.Dbc.GroupLeaderView.First(g => g.ParentId == null);
            var executeDepartment = base.Dbc.Belongs.First(g => g.UserId == LoginUser.Id && g.Duty == Duty.Main).Departments;
            var groupLeaderView = base.Dbc.GroupLeaderView.First(b => b.Id == executeDepartment.Id);

            // 毎回作成
            var taskDefitionId = form.Get("taskDefitionId").Replace(":", string.Empty);
            variables.Add(string.Format("system_{0}_parentGroupLeader", taskDefitionId), groupLeaderView.ParentUserId);
            variables.Add(string.Format("system_{0}_groupLeader", taskDefitionId), groupLeaderView.UserId);

            // 申請時のみ
            variables.Add("system_rootGroupLeader", rootGroupLeader.UserId);
            variables.Add("system_groupLevel", executeDepartment.Level.ToString());

            // プロセス開始
            base.Client.ProcessInstances.Start(processDefinitionId, variables);

            // リダイレクト
            return RedirectToAction("Mine", "Process", new { Area = "Flow" });
        }

        //
        // POST: /Flow/Forms/Approve
        [HttpPost]
        public RedirectToRouteResult Action(FormCollection form)
        {
            // BPMN定義取得
            var processDefinitionId = form.Get("processDefinitionId");
            var process = base.Client.ProcessDefinitions.GetResourcedata(processDefinitionId);

            // POSTパラメタよりフォーム値抽出
            var variables = process.Extract(form);

            // タスク実行時、システム固定付随情報設定
            var executeBelong = base.Dbc.Belongs.Must(g => g.UserId == LoginUser.Id && g.Duty == Duty.Main);
            var groupLeaderView = base.Dbc.GroupLeaderView.FirstOrDefault(b => b.Id == executeBelong.DepartmentId);

            // 毎回作成
            var taskDefitionId = form.Get("taskDefitionId").Replace(":", string.Empty);
            variables.Add(string.Format("system_{0}_parentGroupLeader", taskDefitionId), groupLeaderView.Nvl(v => v.ParentUserId));
            variables.Add(string.Format("system_{0}_groupLeader", taskDefitionId), groupLeaderView.Nvl(v => v.UserId));

            // プロセス開始
            var taskId = form.Get("taskId");
            base.Client.Tasks.Post(taskId.ToInt(), RestClientBase.Action.complete, variables);

            // リダイレクト
            return RedirectToAction("Index", "Tasks", new { Area = "Flow" });
        }
	}
}