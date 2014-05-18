using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitFlow.Areas.Flow.Models.Views
{
    public class MyTaskModel
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public int ProcessInstanceId { get; set; }

        public string ProcessName { get; set; }

        public string Assignee { get; set; }

        public DateTime AssignDateTime { get; set; }

        public string Description { get; set; }

        public string Initiator { get; set; }
    }
}