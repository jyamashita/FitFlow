using FitFlow.Areas.Flow.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FitFlow.Views.Helpers
{
    public class FormUtil
    {
        public static string AsValidStr(FormData form)
        {
            var prop = form.FormProperty;
            var validStr = new List<string>();

            // 共通
            if (prop.IsRequired) {
                validStr.Add("required");
            }
            else {
                validStr.Add("optional");
            }

            // 個別
            switch (prop.Type) {
                case ActivitiClient.Constants.Type.@string:
                    break;
                case ActivitiClient.Constants.Type.@long:
                    validStr.Add("custom[number]");
                    break;
                case ActivitiClient.Constants.Type.boolean:
                    break;
                case ActivitiClient.Constants.Type.date:
                    validStr.Add("custom[date]");
                    break;
                case ActivitiClient.Constants.Type.@enum:
                    break;
                case ActivitiClient.Constants.Type.user:
                    break;
                default:
                    break;
            }

            return string.Format("validate[{0}]", string.Join(",", validStr));
        }
    }
}