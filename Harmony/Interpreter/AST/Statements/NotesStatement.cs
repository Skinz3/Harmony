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
    public class NotesStatement : Statement
    {
        private float Duration
        {
            get;
            set;
        }
        private float Velocity
        {
            get;
            set;
        }
        private List<Note> Notes
        {
            get;
            set;
        }
        public NotesStatement(Unit parent, ParserRuleContext ruleContext, List<Note> notes, float duration, float velocity) : base(parent, ruleContext)
        {
            this.Duration = GetTimeSeconds(duration);
            this.Velocity = velocity;
            this.Notes = notes;
        }

        public override float GetDuration()
        {
            return Duration;
        }

        protected override List<SheetNote> Execute(ref float time)
        {
            List<SheetNote> results = new List<SheetNote>();

            foreach (var note in Notes)
            {
                SheetNote sheetNote = new SheetNote(note.Number, time, time + Duration, Velocity);
                results.Add(sheetNote);
            }

            return results;
        }
    }
}
