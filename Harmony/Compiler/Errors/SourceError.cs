using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler.Errors
{
    public class SourceError : Error
    {
        public SourceError(ErrorType type, int line, int charPositionInLine, string message) : base(type, message)
        {
            Line = line;
            CharPositionInLine = charPositionInLine;
        }

        public int Line
        {
            get;
            set;
        }
        public int CharPositionInLine
        {
            get;
            set;
        }
        public override string ToString()
        {
            return Line + ":" + CharPositionInLine + " " + Message;
        }
    }
}
