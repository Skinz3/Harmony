using Harmony.DP;
using Harmony.Instruments;
using Harmony.Notes;
using Harmony.Sheets;
using SFML.Audio;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Audio
{
    [WIP("weird implementation...")]
    public class InstrumentPlayer
    {
        public const int SoundInstanceLimit = 256;

        public static int SoundsInstance = 0;

        public Instrument Instrument
        {
            get;
            private set;
        }

        private Dictionary<int, KeySound> KeySounds
        {
            get;
            set;
        }

        public bool SustainPedal
        {
            get;
            private set;
        }
        public InstrumentPlayer()
        {
            this.KeySounds = new Dictionary<int, KeySound>();
        }

        public void DefineInstrument(Instrument instrument)
        {
            foreach (var keySound in KeySounds.Values)
            {
                keySound.Dispose();
            }

            KeySounds.Clear();

            this.Instrument = instrument;

            foreach (var noteSound in Instrument.Notes)
            {
                SoundBuffer buffer = new SoundBuffer(noteSound.WavFile);

                Sound sound = new Sound();
                SoundsInstance++;

                sound.SoundBuffer = buffer;

                Note note = NotesManager.GetNote(noteSound.Name);
                KeySound keySound = new KeySound(sound, note);
                KeySounds.Add(note.Number, keySound);
            }
        }
        public void Play(int keyNumber, float volume)
        {
            KeySounds[keyNumber].Play(volume);
        }

        public void Update()
        {
            foreach (var keySound in KeySounds.Values)
            {
                keySound.Update(SustainPedal);
            }
        }
        public void Stop()
        {
            foreach (var sound in KeySounds)
            {
                sound.Value.Stop();
            }
        }

        public void End(Note note)
        {
            KeySounds[note.Number].End();
        }
    }

    public class KeySound : IDisposable
    {
        public Sound MainSound
        {
            get;
            set;
        }
        public List<Sound> AuxiliarSounds
        {
            get;
            set;
        }

        private Note Note
        {
            get;
            set;
        }

        private Sound SoundStopping
        {
            get;
            set;
        }
        public KeySound(Sound sound, Note note)
        {
            this.MainSound = sound;
            this.AuxiliarSounds = new List<Sound>();
            this.Note = note;
        }
        [WIP]
        public void Update(bool pedal)
        {
            foreach (var sound in AuxiliarSounds.Where(x => x.Status != SoundStatus.Playing).ToArray())
            {
                sound.Dispose();
                AuxiliarSounds.Remove(sound);
                if (SoundStopping == sound)
                {
                    SoundStopping = null;
                }
                InstrumentPlayer.SoundsInstance--;
            }

            if (SoundStopping != null)
            {
                const float speed = 1.8f;

                const float speed2 = 0.4f;

                if (SoundStopping.Volume > 20f)
                {
                    SoundStopping.Volume -= speed;

                   
                }
                else
                {
                    SoundStopping.Volume -= speed2;

                    if (SoundStopping.Volume <= speed2)
                    {
                        SoundStopping.Volume = 0;
                        SoundStopping = null;
                    }
                }
            }
        }
        public void Play(float volume)
        {
            foreach (var sound in AuxiliarSounds.ToArray())
            {
                sound.Volume = 0;
            }
            if (SoundStopping != null)
            {
                SoundStopping.Volume = 0;
            }

            SoundStopping = null;
            MainSound.Volume = 0;

            Sound result = null;

            if (MainSound.Status == SoundStatus.Stopped || InstrumentPlayer.SoundsInstance == InstrumentPlayer.SoundInstanceLimit)
            {
                result = MainSound;
            }
            else
            {
                result = new Sound(MainSound.SoundBuffer);
                InstrumentPlayer.SoundsInstance++;
                AuxiliarSounds.Add(result);
            }

            result.Volume = volume;
            result.PlayingOffset = Time.Zero;
            result.Play();
        }


        public void Dispose()
        {
            MainSound.Dispose();

            foreach (var sound in AuxiliarSounds)
            {
                sound.Dispose();
                InstrumentPlayer.SoundsInstance--;
            }

        }

        public void End()
        {
            if (MainSound.Volume > 0 && MainSound.Status == SoundStatus.Playing)
            {
                this.SoundStopping = MainSound;
            }
            else
            {
                this.SoundStopping = AuxiliarSounds.FirstOrDefault(x => x.Status == SoundStatus.Playing && x.Volume > 0);
            }

        }
        public void Stop()
        {
            MainSound.Stop();

            foreach (var sound in AuxiliarSounds)
            {
                sound.Stop();
            }

        }
    }
}
