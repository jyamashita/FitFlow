using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Xml.Linq;

namespace FitFlow.Models.Base
{
    abstract public class BaseModel : BaseLogicalDeleteModel
    {
        [Column(Order=100)]
        [Required]
        [ForeignKey("CreateUser")]
        public string CreateUserId { get; set; }

        public virtual User CreateUser { get; set; }

        [Column(Order = 101)]
        [Required]
        public DateTime CreateDateTime { get; set; }

        [Column(Order = 102)]
        [ForeignKey("UpdateUser")]
        public string UpdateUserId { get; set; }

        [Column(Order = 103)]
        public virtual User UpdateUser { get; set; }

        [Column(Order = 104)]
        public DateTime? UpdateDateTime { get; set; }
    }
}
