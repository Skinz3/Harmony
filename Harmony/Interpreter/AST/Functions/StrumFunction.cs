using Antlr4.Runtime;
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
        private float Offset
        {
            get;
            set;
        }
        public StrumFunction(IEntity parent, ParserRuleContext context, float offset) : base(parent, context)
        {
            this.Offset = GetParentStatement().GetTimeSeconds(offset) / 100f;
        }

        public override float GetDuration()
        {
            return 0;
        }

        public override void Prepare()
        {

        }

        protected override void Execute(ref float time, List<SheetNote> notes)
        {
            float delta = 0;

            foreach (var note in notes)
            {
                note.Start += delta;

                delta += Offset;
            }


        }
    }
}
