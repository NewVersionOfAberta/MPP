using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLib
{
    public class TraceResult
    {
        private readonly List<ThreadInfo> threads;

        public TraceResult() { }

        public TraceResult(List<ThreadInfo> threads)
        {
            this.threads = threads;
        }

        public List<ThreadInfo> Threads => threads;
    }
}
