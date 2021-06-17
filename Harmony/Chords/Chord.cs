using Harmony.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Chords
{
    public class Chord
    {
        public string Name
        {
            get;
            private set;
        }
        public int Octave
        {
            get;
            private set;
        }
        public IEnumerable<Note> Notes
        {
            get;
            private set;
        }

        public Chord(string name, int octave, IEnumerable<Note> notes)
        {
            this.Name = name;
            this.Octave = octave;
            this.Notes = notes;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
