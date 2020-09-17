using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerLib;

namespace Application
{
    interface ISerializer
    {
        string Serialize(TraceResult traceResult);
    }
}
