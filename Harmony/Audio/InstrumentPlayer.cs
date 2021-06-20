using Harmony.Instruments;
using Harmony.Notes;
using Harmony.Sheets;
using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Audio
{
    public class InstrumentPlayer
    {
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
    }

    public class KeySound : IDisposable
    {
        private Sound Sound
        {
            get;
            set;
        }
        private Sound Sound2
        {
            get;
            set;
        }
        private Note Note
        {
            get;
            set;
        }

        public KeySound(Sound sound, Note note)
        {
            this.Sound = sound;
            this.Sound2 = new Sound(sound.SoundBuffer);
            this.Note = note;
        }

        public void Play(float volume)
        {
            if (Sound.Status == SoundStatus.Playing && Sound2.Status != SoundStatus.Playing)
            {
                Sound.Volume = 0;
                Sound2.Volume = volume;
                Sound2.Play();
            }
            else
            {
                Sound.Volume = volume;
                Sound.Play();
            }
        }

        public void Dispose()
        {
            Sound.SoundBuffer.Dispose();
            Sound.Dispose();
        }
    }
}
