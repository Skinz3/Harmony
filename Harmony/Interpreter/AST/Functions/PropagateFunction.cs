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
    public class PropagateFunction : Function
    {
        private int Delta
        {
            get;
            set;
        }

        public PropagateFunction(Statement parent, int delta) : base(parent)
        {
            this.Delta = delta;
        }

        public override void Apply(List<SheetNote> notes)
        {
            for (int i = 1; i <= Delta; i++)
            {
                foreach (var sheetNote in notes.ToArray())
                {
                    var addedNote = NotesManager.AddTone(sheetNote.Note, 6 * i);

                    if (addedNote != null)
                    {
                        notes.Add(new SheetNote(addedNote.Number, sheetNote.Start, sheetNote.End, sheetNote.Velocity));
                    }
                }

            }
        }

        public override void Prepare()
        {

        }

    }
}
