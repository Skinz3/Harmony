using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Notes
{
    public class Note
    {
        public NoteId Id
        {
            get;
            private set;
        }
        public int Number
        {
            get;
            private set;
        }
        public int Octave
        {
            get;
            private set;
        }

        public string Symbol => Id.ToString().Replace("Sharp", "#");

        public bool Sharp => Symbol.Contains("#");

        public Note(NoteId noteEnum, int octave, int number)
        {
            this.Id = noteEnum;
            this.Octave = octave;
            this.Number = number;
        }
        public override string ToString()
        {
            return Symbol + Octave;
        }
    }
}
