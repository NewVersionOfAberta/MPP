using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLib
{
    public class TraceException : Exception
    {
        

        public TraceException(string message)
        : base(message)
        { }
    }
}
