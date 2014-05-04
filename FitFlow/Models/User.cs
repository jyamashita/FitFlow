using FitFlow.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Xml.Linq;

namespace FitFlow.Models
{
    public class User : BaseLogicalDeleteModel
    {
        /// <summary>
        /// ポータル、Activiti共通ID
        /// </summary>
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// ハッシュ化パスワード(ポータル用)
        /// </summary>
        [Column(Order = 2)]
        public string Password { get; set; }

        [Column(Order = 100)]
        [Required]
        public string CreateUserId { get; set; }

        [Column(Order = 101)]
        [Required]
        public DateTime CreateDateTime { get; set; }

        [Column(Order = 102)]
        public string UpdateUserId { get; set; }

        [Column(Order = 104)]
        public DateTime? UpdateDateTime { get; set; }
    }
}
