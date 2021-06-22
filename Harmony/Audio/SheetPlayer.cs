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
        public float Position
        {
            get;
            private set;
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
                float delta = (float)(deltaTime * (Sheet.Tempo / 60d));
                Position += delta;

                if (Position >= Sheet.TotalDuration)
                {
                    Position = Sheet.TotalDuration;
                    Pause();
                    return;
                }

                var notes = Notes.FindAll(x => x.Start <= Position);

                foreach (var playingNote in PlayingNotes.ToArray())
                {
                    if (playingNote.End < Position)
                    {
                        PlayingNotes.Remove(playingNote);
                        InstrumentPlayer.End(playingNote.Number);
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
            PlayingNotes.Clear();
        }

        private void StopSounds()
        {
            PlayingNotes.Clear();
            InstrumentPlayer.Stop();
        }

        public void Snap(float value)
        {
            StopSounds();
            this.Notes = Sheet.Notes.Where(x => x.Start >= value).ToList();
            this.PlayingNotes.Clear();
            this.Position = value;
        }
    }
}
