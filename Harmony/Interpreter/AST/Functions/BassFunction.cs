using Antlr4.Runtime;
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
    public class BassFunction : Function
    {
        public BassFunction(IEntity parent, ParserRuleContext context) : base(parent, context)
        {
        }

        protected override void Execute(ref float time, List<SheetNote> notes)
        {
            var sheetNote = notes.FirstOrDefault();

            Note note = NotesManager.AddTone(sheetNote.Note, -6);

            notes.Add(new SheetNote(note.Number, sheetNote.Start, sheetNote.End, sheetNote.Velocity, this));
        }

        public override float GetDuration()
        {
            return 0f;
        }

        public override void Prepare()
        {

        }
    }
}
