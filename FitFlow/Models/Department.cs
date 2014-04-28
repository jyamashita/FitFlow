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
        public int Id { get; set; }

        [Column(Order = 2)]
        public int ParentId { get; set; }

        [Column(Order = 3)]
        public string Name { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "Date")]
        public DateTime ApplyFrom { get; set; }

        [Required]
        [Column(Order = 5, TypeName = "Date")]
        public DateTime ApplyTo { get; set; }
    }
}
