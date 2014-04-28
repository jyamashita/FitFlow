using FitFlow.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitFlow.Models
{
    public class Belong : BaseModel
    {
        [Key, Column(Order = 1)]
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        [Key, Column(Order = 3, TypeName = "Date")]
        [Required]
        public DateTime ApplyFrom { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "Date")]
        public DateTime ApplyTo { get; set; }

        [Required]
        [Column(Order = 5)]
        public int DutyType { get; set; }
    }
}
