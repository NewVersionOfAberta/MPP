using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TracerLib;

namespace Application
{
    class Program
    {
        const string DEF_FILE_NAME = "serialize.txt";
        const string DEF_FILE_NAME_JSON = "json_serialize.txt";

        static Tracer tracer = new Tracer();


        public static void Count()
        {
            Cool cool = new Cool(tracer);
            cool.Long();
            TraceResult traceResult = tracer.GetTraceResult();
           
        }

        static void Main(string[] args)
        {

            Thread myThread = new Thread(new ThreadStart(Count));
            myThread.Start();

            Cool cool = new Cool(tracer);
            cool.Long();
            TraceResult traceResult = tracer.GetTraceResult();

            Seeker seeker = new Seeker(tracer);
            seeker.StartTest();

            var xMLSerializer = new XMLSerializer();
            var jSONSerializer = new JSONSerializer();

            var writer = new Writer();

            string xml = xMLSerializer.Serialize(traceResult);
            string json = jSONSerializer.Serialize(traceResult);
            
            writer.ToWrite(xml, new StreamWriter(DEF_FILE_NAME));
            writer.ToWrite(json, new StreamWriter(DEF_FILE_NAME_JSON));

            writer.ToWrite(json, Console.Out);
            writer.ToWrite(xml, Console.Out);

            Console.ReadKey();
        }
    }
}
