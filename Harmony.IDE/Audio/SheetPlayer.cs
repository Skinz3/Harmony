using Harmony.DP;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.IDE.Audio
{
    public class SheetPlayer
    {
        public Sheet Sheet
        {
            get;
            private set;
        }
        public bool Paused
        {
            get;
            private set;
        }
        private float Position
        {
            get;
            set;
        }
        private InstrumentPlayer InstrumentPlayer
        {
            get;
            set;
        }
        public List<SheetNote> Notes
        {
            get;
            set;
        }
        public SheetPlayer(InstrumentPlayer instrumentPlayer)
        {
            this.InstrumentPlayer = instrumentPlayer;
        }

        public void Play()
        {
            Paused = false;
        }
        public void Load(Sheet sheet)
        {
            this.Sheet = sheet;
            this.Notes = Sheet.Notes.ToList();
            this.Position = 0;
            this.Paused = true;
        }

        public void Update()
        {
            if (Paused)
            {
                return;
            }
            if (Sheet != null)
            {
                Position += (1 / 60f) * (Sheet.Tempo / 60f);

                var notes = Notes.FindAll(x => x.Start <= Position);

                foreach (var note in notes.ToArray())
                {
                    InstrumentPlayer.Play(note.Number, note.Velocity);
                    Notes.Remove(note);
                }
            }
        }

        public void Pause()
        {
            Paused = true;
        }
    }
}
