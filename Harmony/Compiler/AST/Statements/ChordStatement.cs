using Antlr4.Runtime;
using Harmony.Chords;
using Harmony.Notes;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler.AST.Statements
{
    public class ChordStatement : Statement
    {
        private Chord Chord
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
        private int Octave
        {
            get;
            set;
        }

        public ChordStatement(ParserRuleContext context, Chord chord, float start, float duration, float velocity, int octave) : base(context)
        {
            this.Chord = chord;
            this.Start = start;
            this.Duration = duration;
            this.Velocity = velocity;
            this.Octave = octave;
        }
        public override IEnumerable<SheetNote> GetNotes()
        {
            List<SheetNote> result = new List<SheetNote>();

            IEnumerable<Note> notes = Chord.Notes;

            foreach (var note in notes)
            {
                result.Add(new SheetNote(note.Number, Start, Start + Duration, Velocity));
            }

            return result;
        }


    }
}
