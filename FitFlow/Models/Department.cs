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
    public class Department : BaseModel
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string Id { get; set; }

        [Column(Order = 2)]
        public string ParentId { get; set; }

        [Column(Order = 3)]
        [Required]
        public int Level { get; set; }
    }
}
