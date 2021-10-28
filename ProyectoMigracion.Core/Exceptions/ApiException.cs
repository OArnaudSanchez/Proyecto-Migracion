using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMigracion.Core.Exceptions
{
    public class ApiException : Exception
    {
        public int statusCode { get; set; }
        public string message { get; set; }

        public ApiException() { }

        public ApiException(string Message, int StatusCode) : base(Message)
        {
            this.message = Message;
            this.statusCode = StatusCode;
        }
    }
}
