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
    abstract public class BaseStartEndModel : BaseModel
    {
        [Key, Column(Order = 98, TypeName = "Date")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column(Order = 99, TypeName = "Date")]
        [Required]
        public DateTime EndDate { get; set; }
    }
}
