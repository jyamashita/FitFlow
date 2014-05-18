using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace FitFlow.Areas.Flow.Models
{
    public class Style
    {
        /// <summary>
        /// 分母を保持（1/BlockSize）
        /// </summary>
        [XmlElement("blockSize")]
        public int BlockSize { get; set; }

        [XmlIgnore]
        public int CalcSize { get { return 2 / BlockSize; } }

        [XmlIgnore]
        public string SizeCss { get { return string.Format("col-md-{0}", ((12 / BlockSize) - (2 * CalcSize)).ToString()); } }
    }
}