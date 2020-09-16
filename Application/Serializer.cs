
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application
{
    class Serializer
    {


        public void ToJSON(Object obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string jsonString;
            //TextWriter textWriter = new StringWriter();
            jsonString = JsonSerializer.Serialize(obj, options);
            Console.Write(jsonString);
            Console.ReadLine();
        }

    }
}
