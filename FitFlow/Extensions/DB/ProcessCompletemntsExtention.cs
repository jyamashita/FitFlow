using FitFlow.Areas.Flow.Models;
using FitFlow.Models.Activiti;
using FitFlow.Models.FitFlow;
using FitFlow.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace FitFlow.Extensions.DB
{
    public static class ProcessCompletemntsExtention
    {
        public static void SetResource(this ProcessComplements @this, ProcessComplement model)
        {
            @this.Resource = FitFlowUtil.ModelToXml(model);
        }

        public static ProcessComplement GetResource(this ProcessComplements @this)
        {
            return FitFlowUtil.XmlToModel<ProcessComplement>(@this.Resource);
        }
    }
}