using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Exception
{
    public class Response
    {
        public object data;
        public bool success;
        public string error = string.Empty;
        public int statusCode;


        public Response(bool success, string error, int statusCode, object data)
        {
            this.success = success;
            this.error = error;
            this.statusCode = statusCode;
            this.data = data;
        }


    }
}
