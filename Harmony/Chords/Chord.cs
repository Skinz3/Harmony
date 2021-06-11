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
            set;
        }
        public IEnumerable<Note> Notes
        {
            get;
            set;
        }
       
        public override string ToString()
        {
            return Name;
        }
    }
}
