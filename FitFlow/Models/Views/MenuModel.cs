using FitFlow.Models.FitFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitFlow.Models.Views
{
    public class MenuModel
    {
        /// <summary>
        /// マイタスク件数
        /// </summary>
        public int MyTaskCnt { get; set; }

        /// <summary>
        /// 申請済件数
        /// </summary>
        public int MyProcessCnt { get; set; }

        /// <summary>
        /// メニューリスト
        /// </summary>
        public List<Menus> MenuList { get; set; }
    }
}