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
    public class Menu : BaseModel
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }

        [Column(Order = 2)]
        public string Category { get; set; }

        [Column(Order = 3)]
        public string Name { get; set; }

        [Column(Order = 4)]
        public string URL { get; set; }

        [Column(Order = 5)]
        public string Icon { get; set; }

        [Column(Order = 6)]
        public int? Order { get; set; }
    }
}
