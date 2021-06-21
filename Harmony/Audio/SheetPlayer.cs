using Harmony.DP;
using Harmony.Sheets;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Audio
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
        public InstrumentPlayer InstrumentPlayer
        {
            get;
            private set;
        }
        public List<SheetNote> Notes
        {
            get;
            set;
        }
        public List<SheetNote> PlayingNotes
        {
            get;
            set;
        }
        public Clock Clock
        {
            get;
            private set;
        }
        public SheetPlayer(InstrumentPlayer instrumentPlayer)
        {
            this.InstrumentPlayer = instrumentPlayer;
            this.Clock = new Clock();
            PlayingNotes = new List<SheetNote>();
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
            Pause();
        }

        public void Update()
        {
            var deltaTime = Clock.ElapsedTime.AsSeconds();

            InstrumentPlayer.Update();

            Clock.Restart();

            if (Paused)
            {
                return;
            }

            if (Sheet != null)
            {
                Position += (float)(deltaTime * (Sheet.Tempo / 60d));

                var notes = Notes.FindAll(x => x.Start <= Position);

                foreach (var playingNote in PlayingNotes.ToArray())
                {
                    if (playingNote.End < Position)
                    {
                        PlayingNotes.Remove(playingNote);
                        InstrumentPlayer.End(playingNote.Note);
                    }
                }

                foreach (var note in notes.ToArray())
                {
                    InstrumentPlayer.Play(note.Number, note.Velocity);
                    Notes.Remove(note);
                    PlayingNotes.Add(note);
                }

              
            }
        }

        public void Pause()
        {
            Paused = true;
            StopSounds();
        }

        private void StopSounds()
        {
            InstrumentPlayer.Stop();
        }
    }
}
