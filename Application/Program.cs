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

        static Tracer tracer = new Tracer();


        public static void Count()
        {
            Cool cool = new Cool(tracer);
            cool.Long();
            TraceResult traceResult = tracer.GetTraceResult();
           
        }

        static void Main(string[] args)
        {


            //Thread myThread = new Thread(new ThreadStart(Count));
            //myThread.Start();

            //Cool cool = new Cool(tracer);
            //cool.Long();
            //TraceResult traceResult = tracer.GetTraceResult();

            var thread = new Thread(new ThreadStart(() =>
            {
                tracer.StartTrace();
                Thread.Sleep(10);
                tracer.StopTrace();
            }));

            thread.Start();

            tracer.StartTrace();
            Thread.Sleep(10);
            tracer.StopTrace();

            TraceResult traceResult = tracer.GetTraceResult();

            var xMLSerializer = new XMLSerializer();
            var writer = new Writer();
            writer.ToWrite(xMLSerializer.Serialize(traceResult), new StreamWriter(DEF_FILE_NAME));
            var jSONSerializer = new JSONSerializer();
            writer.ToWrite(jSONSerializer.Serialize(traceResult), Console.Out);
            Console.ReadKey();
        }
    }
}
