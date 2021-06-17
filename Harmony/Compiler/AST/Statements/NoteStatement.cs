using Antlr4.Runtime;
using Harmony.Notes;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler.AST.Statements
{
    public class NoteStatement : Statement
    {
        private Note Note
        {
            get;
            set;
        }
        private float Start
        {
            get;
            set;
        }
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
        public NoteStatement(ParserRuleContext context, Note note, float start, float duration, float velocity) : base(context)
        {
            this.Note = note;
            this.Start = start;
            this.Duration = duration;
            this.Velocity = velocity;
        }

        public override IEnumerable<SheetNote> GetNotes()
        {
            return new SheetNote[1]
            {
                new SheetNote(Note.Number,Start,Start+Duration,Velocity),
            };
        }
    }
}
