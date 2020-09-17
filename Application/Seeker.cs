using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TracerLib;

namespace Application
{
    public class Seeker
    {
        Tracer tracer;

        public Seeker(Tracer tracer)
        {
            this.tracer = tracer;
        }

        public void Test()
        {
            tracer.StartTrace();
            Thread.Sleep(1);
            tracer.StopTrace();
        }

        private void Parallel()
        {
            tracer.StartTrace();
            Cool cool = new Cool(tracer);
            cool.Fast();
            cool.Long();
            tracer.StopTrace();
        }

        public void StartTest()
        {
            tracer.StartTrace();
            Thread.Sleep(1);
            Test();
            Thread thread = new Thread(new ThreadStart(Parallel));
            thread.Start();
            tracer.StopTrace();
        }

    }
}
