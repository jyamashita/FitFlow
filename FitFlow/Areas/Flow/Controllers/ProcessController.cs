using FitFlow.Areas.Flow.Models.Views;
using FitFlow.Controllers;
using FitFlow.Models.FitFlow;
using FitFlow.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitFlow.Areas.Flow.Controllers
{
    public class ProcessController : BaseController
    {
        //
        // GET: /Flow/ProcessModel/
        public ActionResult Mine()
        {
            var unCompletedProcess = base.Dbc.UnCompletedProcess.Where(p => p.StartUser == LoginUser.Id).ToList();
            var unCompletedTask = base.Dbc.UnCompletedTask
                                   .Select(t => new {
                                       Key = t.ProcessInstanceId,
                                       Info = new { t.TaskName, t.TaskAssigneeName } }).ToList();
            var mine = (from process in unCompletedProcess
                        join task in unCompletedTask on process.ProcessInstanceId equals task.Key
                        group new ProcessMineModel.TaskInfo {
                            TaskName = task.Info.TaskName,
                            TaskAssigneeName = task.Info.TaskAssigneeName
                        } by new {
                            ProcessInstanceId = int.Parse(process.ProcessInstanceId),
                            ProcessCategory = process.Category,
                            ProcessName = process.ProcessName,
                            StartTime = process.StartTime,
                        } into grp
                        select new ProcessMineModel {
                            ProcessInstanceId = grp.Key.ProcessInstanceId,
                            ProcessCategory = grp.Key.ProcessCategory,
                            ProcessName = grp.Key.ProcessName,
                            StartTime = grp.Key.StartTime,
                            TaskInfoList = grp.ToList()
                        }).ToList();
            return View(mine);
        }
	}
}