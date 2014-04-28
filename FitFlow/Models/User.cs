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
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }

        [Column(Order = 2)]
        [Required]
        public string Name { get; set; }

        [Column(Order = 3)]
        [Required]
        public string Alias { get; set; }

        [Column(Order = 4)]
        public string Domain { get; set; }

        [Column(Order = 100)]
        [Required]
        public int CreateUserId { get; set; }

        [Column(Order = 101)]
        [Required]
        public DateTime CreateDateTime { get; set; }

        [Column(Order = 102)]
        public int? UpdateUserId { get; set; }

        [Column(Order = 104)]
        public DateTime? UpdateDateTime { get; set; }
    }
}
