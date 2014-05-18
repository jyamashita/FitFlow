using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitFlow.Areas.Flow.Models.Views
{
    public class ProcessMineModel
    {
        public int ProcessInstanceId { get; set; }

        public string ProcessName { get; set; }

        public string ProcessCategory { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public List<TaskInfo> TaskInfoList { get; set; }

        public class TaskInfo {

            public string TaskName { get; set; }

            public string TaskAssigneeName { get; set; }
        }
    }
}