using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class Writer
    {
        public void ToWrite(string serializedObj, TextWriter textWriter)
        {
            textWriter.Write(serializedObj);
            textWriter.FlushAsync();
        }
    }
}
