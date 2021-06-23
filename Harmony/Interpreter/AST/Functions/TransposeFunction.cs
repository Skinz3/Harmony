using Antlr4.Runtime;
using Harmony.Interpreter.AST.Statements;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Functions
{
    public class TransposeFunction : Function
    {
        private int Delta
        {
            get;
            set;
        }

        public TransposeFunction(IEntity parent, ParserRuleContext context, int delta) : base(parent, context)
        {
            this.Delta = delta;
        }



        public override void Prepare()
        {

        }

        public override float GetDuration()
        {
            return 0f;
        }

        protected override void Execute(ref float time, List<SheetNote> notes)
        {
            foreach (var note in notes)
            {
                note.Number += Delta;
            }
        }
    }
}
