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
    
    public partial class UserView
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ActivitiPassword { get; set; }
        public string PictureId { get; set; }
        public string CreateUserId { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public string UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateDateTime { get; set; }
        public Constants.DeleteFlg DeleteFlg { get; set; }
    }
}
