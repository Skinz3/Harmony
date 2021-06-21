using Harmony.Interpreter.AST.Statements;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Functions
{
    public class StrumFunction : Function
    {
        private float Delta
        {
            get;
            set;
        }
        public StrumFunction(Statement parent, float delta) : base(parent)
        {
            this.Delta = parent.GetTimeSeconds(delta);
        }

        public override void Apply(List<SheetNote> notes)
        {
            float total = notes.Count * Delta;

            foreach (var note in notes)
            {
                note.Start -= total;
            }
            float offset = 0f;

            foreach (var note in notes)
            {
                note.Start += offset;
                offset += Delta;
            }
        }

        public override void Prepare()
        {

        }
    }
}
