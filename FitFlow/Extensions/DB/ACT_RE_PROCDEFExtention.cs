using FitFlow.Models.Activiti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitFlow.Extensions.DB
{
    public static class ACT_RE_PROCDEFExtention
    {
        public static int ProcessId(this ACT_RE_PROCDEF @this)
        {
            return int.Parse(@this.ID_.Split(':')[2]);
        }
    }
}