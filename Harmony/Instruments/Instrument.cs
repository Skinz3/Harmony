using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Instruments
{
    public class Instrument
    {
        public List<InstrumentNote> Notes
        {
            get;
            private set;
        }
        public string Name
        {
            get;
            set;
        }

        public InstrumentNote GetNote(string name)
        {
            return Notes.FirstOrDefault(x => x.Name == name);
        }
        public Instrument()
        {
            this.Notes = new List<InstrumentNote>();
        }
    }
    public class InstrumentNote
    {
        public string Name
        {
            get;
            set;
        }
        public string WavFile
        {
            get;
            set;
        }
    }
}
