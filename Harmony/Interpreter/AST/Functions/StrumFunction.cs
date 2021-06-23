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
    
        public StrumFunction(Statement parent) : base(parent)
        {
             
        }

        public override void Apply(ref float time, Statement statement, List<SheetNote> notes)
        {
            float totalDuration = statement.GetTotalDuration();

            float noteDuration = totalDuration / notes.Count;

            for (int i = 0; i < notes.Count; i++)
            {
                notes[i].Start += noteDuration * i;
            }
        }

        public override float GetAdditionalDuration()
        {
            return 0f;
        }

        public override void Prepare()
        {

        }
    }
}
