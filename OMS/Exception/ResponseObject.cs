using OMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Exception
{
    public class ResponseObject
    {
        public IEnumerable<Orders> data;
        public bool success;
        public string error = string.Empty;
        public int statusCode;

        public ResponseObject(bool success, string error, int statusCode, IEnumerable<Orders> data)
        {
            this.success = success;
            this.error = error;
            this.statusCode = statusCode;
            this.data = data;
        }
    }
}
