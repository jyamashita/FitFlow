using ActivitiClient.Models.Bpmn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitFlow.Areas.Flow.Models.Views
{
    /// <summary>
    /// FormData
    /// </summary>
    public class FormData
    {
        /// <summary>
        /// FormProperty
        /// </summary>
        public FormProperty FormProperty { get; set; }

        /// <summary>
        /// Complement
        /// </summary>
        public Complement Complement { get; set; }
    }
}