using Harmony.Notes;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Harmony.GUI.Rendering;
using Harmony.GUI.SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.GUI.Keys
{
    public class Key : IDrawable
    {
        public Note Note
        {
            get;
            private set;
        }
        public Shape Rectangle
        {
            get;
            private set;
        }
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

        public Key(Note note, Vector2f position, Vector2f size)
        {
            this.Note = note;
            this.Rectangle = new RectangleShape(size);
            this.Rectangle.Position = position;
            Rectangle.FillColor = note.Sharp ? Constants.BlackKeyColor : Constants.WhiteKeyColor;
            Rectangle.OutlineColor = Color.Black;
            Rectangle.OutlineThickness = 0.9f;


        }

        public void SetSound(string path)
        {
            SoundBuffer buffer = new SoundBuffer(File.ReadAllBytes(path));
            Sound = new Sound(buffer);
            Sound2 = new Sound(buffer);
        }
        public void Draw(RenderWindow window)
        {
            Text text = new Text(Note.ToString(), PianoRenderer.Font, 12);
            text.Position = this.Rectangle.Position + new Vector2f(2, +50);

            if (Note.Sharp)
            {
                text.Rotation = 180 + 90;
                text.FillColor = Color.White;
            }
            else
            {
                text.FillColor = Color.Black;
                text.Position += new Vector2f(8, +60);
            }
            window.Draw(Rectangle);
            window.Draw(text);

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
        public void DestroySound()
        {
            if (Sound != null)
            {
                Sound.SoundBuffer.Dispose();
                Sound.Dispose();
                Sound2.Dispose();
            }
        }
        public void Stop()
        {

        }
        public bool Contains(Vector2f point)
        {
            return Rectangle.GetGlobalBounds().Contains(point.X, point.Y);
        }
        public void Fill(Color color)
        {
            Rectangle.FillColor = color;
        }
        public void UnFill()
        {
            if (Note.Sharp)
            {
                Rectangle.FillColor = Constants.BlackKeyColor;
            }
            else
            {
                Rectangle.FillColor = Constants.WhiteKeyColor;
            }
        }


    }
}
