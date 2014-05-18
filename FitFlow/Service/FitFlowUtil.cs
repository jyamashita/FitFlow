using FitFlow.Models.FitFlow;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Xml.Serialization;

namespace FitFlow.Service
{
    public static class FitFlowUtil
    {
        public static void Transform(Action<FitFlowEntities> action)
        {
            using (var dbc = new FitFlowEntities()) {
                using (var tr = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted })) {
                    action(dbc);
                    tr.Complete();
                }
            }
        }

        public static string ModelToXml<T>(T model, Encoding encode = null)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new MemoryStream()) {
                serializer.Serialize(stream, model);
                if (encode == null) encode = Encoding.UTF8;
                return encode.GetString(stream.ToArray());
            }
        }

        public static T XmlToModel<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var sr = new StringReader(xml)) {
                return (T)serializer.Deserialize(sr);
            }
        }
    }
}