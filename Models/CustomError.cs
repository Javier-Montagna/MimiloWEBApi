using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ajuaresCubi.Models
{
    public class CustomError
    {
        public string message { get; private set; }
        public string source { get; private set; }

        public CustomError(string message, string source)
        {
            this.message = message;
            this.source = source;
        }
    }
}
