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
        public BassFunction(Statement parent) : base(parent)
        {
        }

        public override void Apply(ref float time, Statement statement, List<SheetNote> notes)
        {
            var sheetNote = notes.FirstOrDefault();

            Note note = NotesManager.AddTone(sheetNote.Note, -6);

            notes.Add(new SheetNote(note.Number, sheetNote.Start, sheetNote.End, sheetNote.Velocity));

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
