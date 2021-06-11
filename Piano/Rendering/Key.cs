using Harmony.Notes;
using Piano.SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano.Rendering
{
    public class Key : IDrawable
    {
        private const bool UseRoundedRectangles = false;

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
        public Key(Note note, Vector2f position, Vector2f size)
        {
            string soundPath = note.Number + ".wav";

            if (File.Exists(soundPath))
            {
                SoundBuffer buffer = new SoundBuffer(soundPath);
                this.Sound = new Sound();
                this.Sound.SoundBuffer = buffer;
            }

            this.Note = note;

            if (UseRoundedRectangles)
            {
                if (note.Sharp)
                {
                    this.Rectangle = new RoundedRectangle(size, 5, 10);
                }
                else
                {
                    this.Rectangle = new RoundedRectangle(size, 10, 20);
                }
            }
            else
            {
                this.Rectangle = new RectangleShape(size);
            }



            this.Rectangle.Position = position;

            if (note.Sharp)
            {
                Rectangle.FillColor = PianoKeyboard.BlackColor;
            }
            else
            {
                Rectangle.FillColor = PianoKeyboard.WhiteColor;
            }

            Rectangle.OutlineColor = Color.Black;
            Rectangle.OutlineThickness = 0.9f;

        }

        public void Draw(RenderWindow window)
        {
            Text text = new Text(Note.ToString(), PianoRenderer.font, 12);
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

        public void Play()
        {
            Sound?.Play();
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
                Rectangle.FillColor = PianoKeyboard.BlackColor;
            }
            else
            {
                Rectangle.FillColor = PianoKeyboard.WhiteColor;
            }
        }

    }
}
