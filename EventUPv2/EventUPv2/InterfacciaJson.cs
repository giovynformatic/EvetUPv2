using Json.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EventUPv2
{
    class InterfacciaJson
    {
        public String RegisterUserCode(User c)
        {
           
                string res= JsonConvert.SerializeObject(c, Newtonsoft.Json.Formatting.Indented);
             

            return res;
        }
        public String RegisterAdminCode(Admin a)
        {

            string res = JsonConvert.SerializeObject(a, Newtonsoft.Json.Formatting.Indented);


            return res;
        }
    }
}
