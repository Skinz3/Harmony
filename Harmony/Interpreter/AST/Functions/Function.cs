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

        /*
         * The amount of duration the function add to the expression
         */
        public abstract float GetDuration();

        /*
         * expr2.GetRightDuration() =  expr1.[expr2.expr3.expr4]
         *
         */
        public float GetRightDuration()
        {
            if (this is ArpeggioFunction)
            {

            }
            float result = GetDuration();

            if (TargetFunction != null)
            {
                result += TargetFunction.GetRightDuration();
            }
            return result;
        }
        /*
         * expr2.GetLeftDuration =  [expr1.expr2].expr3.expr4
         *
         */
        public float GetLeftDuration()
        {
            return GetDuration() + Parent.GetLeftDuration();
        }

        protected Statement GetParentStatement()
        {
            IEntity parent = Parent;

            while (!(parent is Statement))
            {
                parent = ((Function)parent).Parent;
            }

            return (Statement)parent;
        }
    }
}
