using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerLib;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Tracer tracer = new Tracer();
            Cool cool = new Cool(tracer);
            cool.Fast();
            TraceResult traceResult = tracer.GetTraceResult();
            Serializer serializer = new Serializer();
            serializer.ToJSON(traceResult);

        }
    }
}
