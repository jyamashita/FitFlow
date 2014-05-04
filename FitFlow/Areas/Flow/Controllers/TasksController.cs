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

namespace FitFlow.Areas.Flow.Controllers
{
    public class TasksController : BaseController
    {
        //
        // GET: /Flow/Tasks/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Flow/Tasks/Action
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

            // 申請時のみ
            variables.Add("system_rootGroupLeader", rootGroupLeader.UserId);
            variables.Add("system_groupLevel", executeDepartment.Level.ToString());

            // プロセス開始
            base.Client.ProcessInstances.Start(processDefinitionId, variables);

            // リダイレクト
            return RedirectToAction("Index", "Process");
        }
	}
}