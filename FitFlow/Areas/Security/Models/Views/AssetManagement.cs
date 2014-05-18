using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitFlow.Areas.Security.Models.Views
{
    public class AssetManagement
    {
        public string SearchNameDsp { get; set; }

        [Display(Name = "氏名")]
        public string SearchName { get; set; }

        public string SearchDepartmentDsp { get; set; }

        [Display(Name = "所属")]
        public string SearchDepartment { get; set; }

        public int SearchUsertType { get; set; }

        [Display(Name = "ﾊｰﾄﾞｳｪｱ名称")]
        [StringLength(100)]
        public string SearchHardwearName { get; set; }
    }
}