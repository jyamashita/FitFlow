using ActivitiClient.Models.Bpmn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitFlow.Areas.Flow.Models.Views
{
    public class FormModel
    {
        public ActivitiClient.Models.Form Form { get; set; }

        public ActivitiClient.Models.Task Task { get; set; }

        public ActivitiClient.Models.ProcessDefinition ProcessDefinition { get; set; }
    }
}