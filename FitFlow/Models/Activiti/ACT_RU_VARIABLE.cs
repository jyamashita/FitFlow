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
    
    public partial class ACT_RU_VARIABLE
    {
        public string ID_ { get; set; }
        public Nullable<int> REV_ { get; set; }
        public string TYPE_ { get; set; }
        public string NAME_ { get; set; }
        public string EXECUTION_ID_ { get; set; }
        public string PROC_INST_ID_ { get; set; }
        public string TASK_ID_ { get; set; }
        public string BYTEARRAY_ID_ { get; set; }
        public Nullable<double> DOUBLE_ { get; set; }
        public Nullable<decimal> LONG_ { get; set; }
        public string TEXT_ { get; set; }
        public string TEXT2_ { get; set; }
    
        public virtual ACT_GE_BYTEARRAY ACT_GE_BYTEARRAY { get; set; }
        public virtual ACT_RU_EXECUTION ACT_RU_EXECUTION { get; set; }
        public virtual ACT_RU_EXECUTION ACT_RU_EXECUTION1 { get; set; }
    }
}