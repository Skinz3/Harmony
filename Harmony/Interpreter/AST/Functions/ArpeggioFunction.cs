using Antlr4.Runtime;
using Harmony.Interpreter.AST.Statements;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Functions
{
    public enum StrumTypeEnum
    {
        unknown,
        forward,
        backward,
        bidirectional,
    }
    public class ArpeggioFunction : Function
    {
        private StrumTypeEnum Type
        {
            get;
            set;
        }

        public ArpeggioFunction(IEntity parent, ParserRuleContext context, StrumTypeEnum type) : base(parent, context)
        {
            this.Type = type;
        }

        protected override void Execute(ref float time, List<SheetNote> notes)
        {
            if (notes.Count == 1)
            {
                return;
            }
            if (Type == StrumTypeEnum.backward)
            {
                float totalDuration = Parent.GetLeftDuration();

                float noteDuration = totalDuration / notes.Count;

                var inputNotes = notes.ToArray().Reverse().ToArray();

                var firstNote = inputNotes.First();

                for (int i = 0; i < inputNotes.Length; i++)
                {
                    inputNotes[i].Start = firstNote.Start + noteDuration * i;
                    inputNotes[i].End = inputNotes[i].Start + noteDuration;

                }
            }
            if (Type == StrumTypeEnum.forward)
            {
                float totalDuration = Parent.GetLeftDuration();

                float noteDuration = totalDuration / notes.Count;

                var firstNote = notes.First();

                for (int i = 0; i < notes.Count; i++)
                {
                    notes[i].Start = firstNote.Start + noteDuration * i;
                    notes[i].End = notes[i].Start + noteDuration;

                }
            }
            if (Type == StrumTypeEnum.bidirectional)
            {
                var inputNotes = notes.ToArray();

                float totalDuration = Parent.GetLeftDuration();


                int resultNotesCount = notes.Count + (inputNotes.Length - 2);

                float noteDuration = (totalDuration / resultNotesCount);

                for (int i = 0; i < inputNotes.Length; i++)
                {
                    inputNotes[i].Start += noteDuration * i;
                    inputNotes[i].End = inputNotes[i].Start + noteDuration;
                }

                var offsetStart = notes.Last().End;

                inputNotes = inputNotes.Reverse().ToArray();

                for (int i = 1; i < inputNotes.Length - 1; i++)
                {
                    float start = offsetStart + noteDuration * (i - 1);
                    float end = start + noteDuration;

                    SheetNote note = new SheetNote(inputNotes[i].Number, start, end, inputNotes[i].Velocity, this);
                    notes.Add(note);
                }
            }
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
