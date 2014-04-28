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
    abstract public class BaseLogicalDeleteModel
    {
        [Column(Order = 105)]
        [Required]
        public int DeleteFlg { get; set; }
    }
}
