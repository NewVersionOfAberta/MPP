using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;

namespace TracerLib
{

    public class Tracer : ITracer
    {
        private const string EX_MESS_NO_START = "Use Tracer.StopTrace() without Tracer.StartTrace()";
        private const string EX_MESS_NO_THREAD = "No Tracer.StartTrace() was called in this thread";
        private const string EX_MESS_NO_THIS_METHOD = "Tracer.StopTrace() call is invalid";


        ConcurrentDictionary<int, StackThreadInfo> cdIdStack = new ConcurrentDictionary<int, StackThreadInfo>();

        List<ThreadInfo> threadInfos = new List<ThreadInfo>();
        
        
        private TraceResult CalculateTime()
        {
            
            foreach (ThreadInfo threadInfo in threadInfos)
            {
                double totalTime = 0;
                foreach (MethodInfo methodInfo in threadInfo.Methods)
                {
                    totalTime += methodInfo.Time;
                }
                threadInfo.Time = totalTime;
            }

            return new TraceResult(threadInfos);
        }

        public TraceResult GetTraceResult()
        {
            return CalculateTime();
        }

        private void AddToList(StackThreadInfo threadInfos, MethodInfo methodInfo)
        {
            StackMethodsInfo parentMethod;
            Stack<StackMethodsInfo> methodInfos = threadInfos.Stack;
            if (methodInfos.Count > 0)
            {
                parentMethod = methodInfos.Pop();
                MethodInfo method = parentMethod.MethodInfo;
                if (method.Methods == null)
                {
                    method.Methods = new List<MethodInfo>();
                }
                method.Methods.Add(methodInfo);
                methodInfos.Push(parentMethod);
            }
            else
            {
                ThreadInfo threadInfo = threadInfos.ThreadInfo;
                if (threadInfo.Methods == null)
                {
                    threadInfo.Methods = new List<MethodInfo>();
                }
                threadInfo.Methods.Add(methodInfo);
                
            }
        }

        public void StartTrace()
        {
            var curTime = DateTime.Now;
            int id = Thread.CurrentThread.ManagedThreadId;
            StackFrame frame = new StackFrame(1);
            MethodBase method = frame.GetMethod();
            var stackInfo = new StackMethodsInfo(curTime, method);
            StackThreadInfo stackThreadInfo;

            Stack<StackMethodsInfo> curStack; 

            MethodInfo methodInfo = new MethodInfo(method.Name, method.DeclaringType.FullName, null);
            stackInfo.MethodInfo = methodInfo;


            if (cdIdStack.ContainsKey(id))
            {
                cdIdStack.TryGetValue(id, out stackThreadInfo);
                curStack = stackThreadInfo.Stack;

            }
            else
            {
                curStack = new Stack<StackMethodsInfo>();
                ThreadInfo threadInfo = new ThreadInfo(id);
                stackThreadInfo = new StackThreadInfo(threadInfo, curStack);
                cdIdStack.TryAdd(id, stackThreadInfo);
                threadInfos.Add(threadInfo);
            }
            AddToList(stackThreadInfo, methodInfo);
            
            curStack.Push(stackInfo);
        }

        private void ValidateMethod(MethodBase expectedBase, MethodBase actualBase)
        {
            if (expectedBase != actualBase) 
            {
                throw new TraceException(EX_MESS_NO_THIS_METHOD);
            }
        }

        public void StopTrace()
        {
            DateTime time = DateTime.Now;
            int id = Thread.CurrentThread.ManagedThreadId;

            StackThreadInfo stackThreadInfo;
            
            if (!cdIdStack.TryGetValue(id, out stackThreadInfo))
            {
                throw new TraceException(EX_MESS_NO_THREAD);
            }

            Stack<StackMethodsInfo> stackMethods = stackThreadInfo.Stack;

            if (stackMethods.Count > 0)
            {
                StackMethodsInfo stackMethodsInfo = stackMethods.Pop();
                StackFrame frame = new StackFrame(1);
                ValidateMethod(stackMethodsInfo.MethodBase, frame.GetMethod());

                stackMethodsInfo.MethodInfo.Time = (time - stackMethodsInfo.StartTime).TotalMilliseconds;

            }
            else
            {
                throw new TraceException(EX_MESS_NO_START);
            }
            

        }
    }
}
