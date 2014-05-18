using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitFlow.Models.Exception
{
    public class FitFlowException : System.Exception
    {
        private string MessageCode { get; set; }

        private List<string> Fills { get; set; }

        public FitFlowException(string message) : base(message) { }

        public FitFlowException(string message, System.Exception ex) : base(message, ex) { }

        public FitFlowException(string message, params string[] fills) : base(message) { }
    }
}