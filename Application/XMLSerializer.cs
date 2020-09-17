using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TracerLib;

namespace Application
{
    class XMLSerializer : ISerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(traceResult.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, traceResult);
                return textWriter.ToString();
            }
        }
    }
}
