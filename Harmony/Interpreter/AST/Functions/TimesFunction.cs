using Harmony.Interpreter.AST.Statements;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Functions
{
    public class TimesFunction : Function
    {
        public int Amount
        {
            get;
            set;
        }
        public TimesFunction(IEntity parent, int amount) : base(parent)
        {
            this.Amount = amount;
        }


        public override void Prepare()
        {

        }

        public override float GetDuration()
        {
            var result = Parent.GetLeftDuration() * (Amount - 1);
            return result;
        }

        protected override void Execute(ref float time, List<SheetNote> notes)
        {
            if (notes.Count == 0)
            {
                return;
            }

            var totalDuration = Parent.GetLeftDuration();

            var clonedNotes = notes.ToArray();

            float offset = totalDuration;

            for (int i = 1; i < Amount; i++)
            {
                foreach (var note in clonedNotes)
                {
                    SheetNote newNote = new SheetNote(note.Number, note.Start + offset, note.End + offset, note.Velocity);
                    notes.Add(newNote);
                }

                offset += totalDuration;
            }
        }
    }
}
