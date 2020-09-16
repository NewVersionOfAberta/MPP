using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TracerLib;

namespace Application
{
    class Cool
    {
        int counter = 10;
        Tracer tracer;

        public Cool(Tracer tracer)
        {
            this.tracer = tracer;
        }

        public int Counter { get => counter; set => counter = value; }

        public void Long()
        {
            tracer.StartTrace();
            Fast();
            Fast();
            Thread.Sleep(100);
            tracer.StopTrace();
        }

        public void Fast()
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
    }
}
