using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler.Errors
{
    public class Error
    {
        public ErrorType Type
        {
            get;
            private set;
        }
       
        public string Message
        {
            get;
            set;
        }
        public Error(ErrorType type, string message)
        {
            this.Type = type;
            this.Message = message;
        }
        public override string ToString()
        {
            return Message;
        }
    }
}
