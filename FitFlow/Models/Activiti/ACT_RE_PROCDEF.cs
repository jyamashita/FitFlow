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
    
    public partial class ACT_RE_PROCDEF
    {
        public ACT_RE_PROCDEF()
        {
            this.ACT_RU_IDENTITYLINK = new HashSet<ACT_RU_IDENTITYLINK>();
            this.ACT_RU_EXECUTION = new HashSet<ACT_RU_EXECUTION>();
            this.ACT_RU_TASK = new HashSet<ACT_RU_TASK>();
        }
    
        public string ID_ { get; set; }
        public Nullable<int> REV_ { get; set; }
        public string CATEGORY_ { get; set; }
        public string NAME_ { get; set; }
        public string KEY_ { get; set; }
        public int VERSION_ { get; set; }
        public string DEPLOYMENT_ID_ { get; set; }
        public string RESOURCE_NAME_ { get; set; }
        public string DGRM_RESOURCE_NAME_ { get; set; }
        public string DESCRIPTION_ { get; set; }
        public Nullable<byte> HAS_START_FORM_KEY_ { get; set; }
        public Nullable<byte> SUSPENSION_STATE_ { get; set; }
        public string TENANT_ID_ { get; set; }
    
        public virtual ICollection<ACT_RU_IDENTITYLINK> ACT_RU_IDENTITYLINK { get; set; }
        public virtual ICollection<ACT_RU_EXECUTION> ACT_RU_EXECUTION { get; set; }
        public virtual ICollection<ACT_RU_TASK> ACT_RU_TASK { get; set; }
    }
}
