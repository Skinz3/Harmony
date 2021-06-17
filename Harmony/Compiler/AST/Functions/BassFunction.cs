using Harmony.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler.AST.Functions
{
    public class BassFunction
    {
        private Note Note
        {
            get;
            set;
        }
        public BassFunction(Note note)
        {
            this.Note = note;
        }
    }
}
