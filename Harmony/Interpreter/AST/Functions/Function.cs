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
    public abstract class Function : IEntity
    {
        protected IEntity Parent
        {
            get;
            set;
        }
        public Function TargetFunction
        {
            get;
            set;
        }

        public Function(IEntity parent)
        {
            this.Parent = parent;
        }

        public void Apply(ref float time, List<SheetNote> notes)
        {
            Execute(ref time, notes);

            TargetFunction?.Apply(ref time, notes);
        }

        protected abstract void Execute(ref float time, List<SheetNote> notes);

        public abstract void Prepare();

        public abstract float GetDuration();

        public float GetTotalDuration()
        {
            return Parent.GetTotalDuration() + GetDuration();
        }
    }
}
