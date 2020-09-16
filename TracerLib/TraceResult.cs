using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLib
{
    public class TraceResult
    {
        private readonly List<ThreadInfo> ts;

        public TraceResult(List<ThreadInfo> ts)
        {
            this.ts = ts;
        }

        public List<ThreadInfo> Ts => ts;
    }
}
