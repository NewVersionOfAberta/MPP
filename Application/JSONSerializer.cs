
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TracerLib;

namespace Application
{
    class JSONSerializer : ISerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IgnoreNullValues = true
            };
            
            return JsonSerializer.Serialize(traceResult, options);
           
        }

    }
}
