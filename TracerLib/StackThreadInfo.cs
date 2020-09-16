using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLib
{
    class StackThreadInfo
    {
        ThreadInfo threadInfo;
        Stack<StackMethodsInfo> stack;
       

        public StackThreadInfo(ThreadInfo threadInfo, Stack<StackMethodsInfo> stack)
        {
            this.threadInfo = threadInfo;
            this.stack = stack;
        }

        public ThreadInfo ThreadInfo { get => threadInfo; set => threadInfo = value; }
        public Stack<StackMethodsInfo> Stack { get => stack; set => stack = value; }
    }
}
