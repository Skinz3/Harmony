using Harmony.Interpreter.AST.Statements;
using Harmony.Notes;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Functions
{
    public abstract class Function
    {
        protected Statement Parent
        {
            get;
            set;
        }

        public Function(Statement parent)
        {
            this.Parent = parent;
        }

        public abstract void Apply(List<SheetNote> notes);

        public abstract void Prepare();


    }
}
