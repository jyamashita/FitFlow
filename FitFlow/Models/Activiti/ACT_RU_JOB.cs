//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitFlow.Models.Activiti
{
    using System;
    using System.Collections.Generic;
    
    public partial class ACT_RU_JOB
    {
        public string ID_ { get; set; }
        public Nullable<int> REV_ { get; set; }
        public string TYPE_ { get; set; }
        public Nullable<System.DateTime> LOCK_EXP_TIME_ { get; set; }
        public string LOCK_OWNER_ { get; set; }
        public Nullable<bool> EXCLUSIVE_ { get; set; }
        public string EXECUTION_ID_ { get; set; }
        public string PROCESS_INSTANCE_ID_ { get; set; }
        public string PROC_DEF_ID_ { get; set; }
        public Nullable<int> RETRIES_ { get; set; }
        public string EXCEPTION_STACK_ID_ { get; set; }
        public string EXCEPTION_MSG_ { get; set; }
        public Nullable<System.DateTime> DUEDATE_ { get; set; }
        public string REPEAT_ { get; set; }
        public string HANDLER_TYPE_ { get; set; }
        public string HANDLER_CFG_ { get; set; }
        public string TENANT_ID_ { get; set; }
    
        public virtual ACT_GE_BYTEARRAY ACT_GE_BYTEARRAY { get; set; }
    }
}
