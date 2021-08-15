using Harmony.Interpreter.AST;
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
            set;
        }
        public float Start
        {
            get;
            set;
        }
        public float End
        {
            get;
            set;
        }

        public IEntity Entity
        {
            get;
            set;
        }

        public float Duration => End - Start;

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

        public bool Pedal
        {
            get;
            set;
        }
        public SheetNote(int number, float start, float end, float velocity, IEntity entity = null, bool pedal = false)
        {
            this.Pedal = pedal;
            this.Note = NotesManager.GetNote(number);
            this.Number = number;
            this.Start = start;
            this.End = end;
            this.Velocity = velocity;
            this.Entity = entity;
        }
    }
}
