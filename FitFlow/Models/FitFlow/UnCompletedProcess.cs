//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitFlow.Models.FitFlow
{
    using System;
    using System.Collections.Generic;
    
    public partial class UnCompletedProcess
    {
        public string ProcessInstanceId { get; set; }
        public string ProcessKey { get; set; }
        public string ProcessDefnitionId { get; set; }
        public string Category { get; set; }
        public string ProcessName { get; set; }
        public string Initiator { get; set; }
        public string StartActionId { get; set; }
        public string EndActionId { get; set; }
        public System.DateTime StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
    }
}
