using ActivitiClient.RestClients;
using ActivitiClient.Extensions;
using FitFlow.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitFlow.Controllers;
using FitFlow.Constants;
using FitFlow.Areas.Flow.Models.Views;
using System.Data.Entity.SqlServer;

namespace FitFlow.Areas.Flow.Controllers
{
    public class TasksController : BaseController
    {
        //
        // GET: /Flow/Tasks/
        public ActionResult Index()
        {
            var taks = base.ADbc.ACT_RU_TASK.Where(t => t.ASSIGNEE_ == LoginUser.Id)
                .Join(base.ADbc.ACT_RE_PROCDEF, t => t.PROC_DEF_ID_, d => d.ID_, (task, def) => new { task, def })
                .Select(set => new {
                    ProcessInstanceId = set.task.PROC_INST_ID_,
                    ProcessName = set.def.NAME_,
                    Assignee = set.task.ASSIGNEE_,
                    Description = set.task.DELEGATION_,
                    AssignDateTime = set.task.CREATE_TIME_.Value,
                    TaskId = set.task.ID_,
                    TaskName = set.task.NAME_,
                }).ToList()
                .Select(task => new MyTaskModel{
                    ProcessInstanceId = int.Parse(task.ProcessInstanceId),
                    ProcessName = task.ProcessName,
                    TaskName = task.TaskName,
                    Assignee = task.Assignee,
                    Description = task.Description,
                    AssignDateTime = task.AssignDateTime,
                    TaskId = int.Parse(task.TaskId)
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
            var taskDefitionId = form.Get("taskDefitionId");
            variables.Add(string.Format("system_{0}_parentGroupLeader", taskDefitionId), groupLeaderView.UserId);
            variables.Add(string.Format("system_{0}_groupLeader", taskDefitionId), groupLeaderView.ParentUserId);

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
            var rootGroupLeader = base.Dbc.GroupLeaderView.First(g => g.ParentId == null);
            var executeDepartment = base.Dbc.Belongs.First(g => g.UserId == LoginUser.Id && g.Duty == Duty.Main).Departments;
            var groupLeaderView = base.Dbc.GroupLeaderView.First(b => b.Id == executeDepartment.Id);

            // 毎回作成
            var taskDefitionId = form.Get("taskDefitionId");
            variables.Add(string.Format("system_{0}_parentGroupLeader", taskDefitionId), groupLeaderView.UserId);
            variables.Add(string.Format("system_{0}_groupLeader", taskDefitionId), groupLeaderView.ParentUserId);

            // プロセス開始
            var taskId = form.Get("taskId");
            base.Client.Tasks.Post(taskId.ToInt(), RestClientBase.Action.complete, variables);

            // リダイレクト
            return RedirectToAction("Index", "Tasks", new { Area = "Flow" });
        }
	}
}