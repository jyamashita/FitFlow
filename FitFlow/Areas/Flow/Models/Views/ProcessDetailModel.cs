using ActivitiClient.Models.Bpmn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitFlow.Areas.Flow.Models.Views
{
    public class ProcessDetailModel
    {
        public ActivitiClient.Models.History History { get; set; }

        public List<FormProperty> FormProperties { get; set; }

        public ActivitiClient.Models.ProcessDefinition ProcessDefinition { get; set; }

        public ProcessComplement ProcessComplements { get; set; }

        public List<FormData> FormDatas
        {
            get
            {
                return (from props in FormProperties
                             from comple in ProcessComplements.Complements.Where(p => p.Id == props.Id).DefaultIfEmpty()
                             select new FormData {
                                 FormProperty = props,
                                 Complement = comple
                             }).ToList();
            }
        }
    }
}