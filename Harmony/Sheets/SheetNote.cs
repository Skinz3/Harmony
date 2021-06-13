using Harmony.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Sheets
{
    public class SheetNote
    {
        public int Number
        {
            get;
            private set;
        }
        public float Start
        {
            get;
            private set;
        }
        public float End
        {
            get;
            private set;
        }
        public float Velocity
        {
            get;
            private set;
        }

        public Note Note
        {
            get;
            set;
        }

        public SheetNote(int number, float start, float end, float velocity)
        {
            this.Note = NotesManager.GetNote(number);
            this.Number = number;
            this.Start = start;
            this.End = end;
            this.Velocity = velocity;
        }
    }
}
