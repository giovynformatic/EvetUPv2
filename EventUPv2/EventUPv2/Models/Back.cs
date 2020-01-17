using System;
using System.Collections.Generic;
using System.Text;

namespace EventUPv2.Models

{
    public class BackList<T>
    {

        public Boolean success { get; set; }
        public List<T> data { get; set; }
        public BackList(Boolean success, List<T> data)
        {
            this.success = success;
            this.data = data;
        }

    }
    public class Back<T>
    {

        public Boolean success { get; set; }
        public T data { get; set; }
    }
}