using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLib
{
    public class MethodInfo
    {
        public string Name { get; set; }
        public string ClassName { get; set; }
        public TimeSpan Time { get; set; }
        public List<MethodInfo> Methods { get; set; }
        
        


        public MethodInfo(string name, string className,  List<MethodInfo> methods)
        {
            this.Name = name;
            this.ClassName = className;
            this.Methods = methods;
        }
    }

   
}
