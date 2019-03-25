using Json.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EventUPv2
{
    class JsonInterfaceUser
    {
        public String RegisterCode(User c)
        {
           
                string res= JsonConvert.SerializeObject(c, Newtonsoft.Json.Formatting.Indented);
             

            return res;
        }

    }
}
