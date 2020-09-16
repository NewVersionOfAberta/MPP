using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLib
{
    public class ThreadInfo
    {
        public int Id { get; set; }
        public string Time { get; set; }
        List<MethodInfo> methods = new List<MethodInfo>();

        public ThreadInfo(int id)
        {
            this.Id = id;
        }

        public List<MethodInfo> Methods { get => methods; set => methods = value; }
        
    }
}
