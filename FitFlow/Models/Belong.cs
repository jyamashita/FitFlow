using FitFlow.Constants;
using FitFlow.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitFlow.Models
{
    public class Belong : BaseStartEndModel
    {
        [Key, Column(Order = 1)]
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Department")]
        public string DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        /// <summary>
        /// '1'：リーダ、'0':メンバー
        /// </summary>
        [Column(Order = 3)]
        [Required]
        [Range(0, 1)]
        public Role Role { get; set; }

        /// <summary>
        /// '1'：本務、'0'：兼務
        /// </summary>
        [Required]
        [Column(Order = 4)]
        [Range(0,1)]
        public Duty Duty { get; set; }
    }
}
