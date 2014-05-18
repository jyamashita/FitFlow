using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace FitFlow.Areas.Flow.Models
{
    public class Complement
    {
        [XmlAttribute("id")]
        public string Id {get; set;}

        [XmlElement("style")]
        public Style Style { get; set; }
    }
}