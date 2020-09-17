using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TracerLib
{
    class StackMethodsInfo
    {
        DateTime startTime;
        MethodBase methodBase;
        MethodInfo methodInfo;

        public StackMethodsInfo(DateTime startTime, MethodBase methodBase)
        {
            this.startTime = startTime;
            this.methodBase = methodBase;
        }

        public MethodInfo MethodInfo { get => methodInfo; set => methodInfo = value; }
        public DateTime StartTime { get => startTime;}
        public MethodBase MethodBase { get => methodBase;  }
    }

    
}
