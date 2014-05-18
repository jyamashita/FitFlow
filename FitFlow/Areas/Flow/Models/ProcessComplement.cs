using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace FitFlow.Areas.Flow.Models
{
    [XmlRoot("definitions")]
    public class ProcessComplement
    {
        [XmlElement("complement")]
        public List<Complement> Complements { get; set; }
    }
}