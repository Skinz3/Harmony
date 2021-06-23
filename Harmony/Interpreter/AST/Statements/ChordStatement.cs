using Antlr4.Runtime;
using Harmony.Chords;
using Harmony.Notes;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Statements
{
    public class ChordStatement : Statement
    {
        private Chord Chord
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

        public ChordStatement(Unit statement, ParserRuleContext context, Chord chord, float duration, float velocity, int octave) : base(statement, context)
        {
            this.Chord = chord;
            this.Duration = GetTimeSeconds(duration);
            this.Velocity = velocity;
            this.Octave = octave;
        }
        public override List<SheetNote> Execute(ref float time)
        {
            List<SheetNote> result = new List<SheetNote>();

            IEnumerable<Note> notes = Chord.Notes;

            foreach (var note in notes)
            {
                result.Add(new SheetNote(note.Number, time, time + Duration, Velocity));
            }

            return result;
        }

        protected override float GetDuration()
        {
            return Duration;
        }
    }
}
