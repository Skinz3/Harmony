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

        public TransposeFunction(Statement parent, int delta) : base(parent)
        {
            this.Delta = delta;
        }

        public override void Apply(ref float time, Statement statement, List<SheetNote> notes)
        {
            foreach (var note in notes)
            {
                note.Number += Delta;
            }
        }

        public override void Prepare()
        {
           
        }

        public override float GetAdditionalDuration()
        {
            return 0f;
        }
    }
}
