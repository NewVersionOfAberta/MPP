using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TracerLib;

namespace TraserLib.Tests
{
    [TestClass]
    public class TracerLibTests
    {
        private Tracer tracer;

        [TestInitialize]
        public void SetUp()
        {
            tracer = new Tracer();
            
        }

        [TestMethod]
        public void GetTraceResult_sleep10_moreThan10()
        {
            double expected = 10;
            double actual;

            tracer.StartTrace();
            Thread.Sleep(10);
            tracer.StopTrace();

            TraceResult traceResult = tracer.GetTraceResult();
            actual = traceResult.Threads[0].Time;

            Assert.IsTrue(actual >= expected);

        }



        [TestMethod]
        public void GetTaceResult_2threads_2elemsInList()
        {
            int expected = 2;
            int actual;

            var thread = new Thread(new ThreadStart(() =>
            {
                tracer.StartTrace();
                Thread.Sleep(5);
                tracer.StopTrace();
            }));

            thread.Start();

            tracer.StartTrace();
            Thread.Sleep(10);
            tracer.StopTrace();

            actual = tracer.GetTraceResult().Threads.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTraceResult_methodsDepth3_3()
        {
            int expected = 3;
            int actual = 0;
            MethodInfo mInf = null;

            Action action2 = () =>
            {
                tracer.StartTrace();
                Thread.Sleep(5);
                tracer.StopTrace();
            };

            Action action1 = () =>
            {
                tracer.StartTrace();
                Thread.Sleep(10);
                action2();
                tracer.StopTrace();
            };

            tracer.StartTrace();
            action1();
            tracer.StopTrace();

            TraceResult traceResult = tracer.GetTraceResult();
            if (traceResult.Threads[0].Methods != null)
            {
                mInf = traceResult.Threads[0].Methods[0];
                actual++;
            }

            while (mInf != null)
            {
                if (mInf.Methods != null)
                {
                    mInf = mInf.Methods[0];
                    actual++;
                }
                else
                {
                    mInf = null;
                }
                    
            }

            Assert.AreEqual(expected, actual);
        }


    }
}
