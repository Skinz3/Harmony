using Antlr4.Runtime;
using Harmony.Notes;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Statements
{
    public class NoteStatement : Statement
    {
        private Note Note
        {
            get;
            set;
        }
        public float Duration
        {
            get;
            private set;
        }
        private float Velocity
        {
            get;
            set;
        }

        public NoteStatement(Unit parent, ParserRuleContext context, Note note, float duration, float velocity) : base(parent, context)
        {
            this.Note = note;
            this.Duration = GetTimeSeconds(duration);
            this.Velocity = velocity;
        }

        public override float GetDuration()
        {
            return Duration;
        }
        protected override List<SheetNote> Execute(ref float time)
        {
            var result = new SheetNote[1]
            {
                new SheetNote(Note.Number,time, time +Duration,Velocity),
            };

            return result.ToList();
        }
    }
}
