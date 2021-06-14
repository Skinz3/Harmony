using Harmony.Extensions;
using Harmony.Sheets;
using NAudio.Midi;
using Harmony.GUI.Keys;
using Harmony.GUI.SFML;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.GUI.Workflow
{
    public class Flow : IDrawable
    {
        private RectangleShape Background
        {
            get;
            set;
        }
        private Vertex[] Lines
        {
            get;
            set;
        }

        public List<FlowNote> Notes
        {
            get;
            private set;
        }

        public const float SizeY = 680;

        public float PixelSpeed
        {
            get;
            set;
        } = 2f;

        private PianoKeyboard Keyboard
        {
            get;
            set;
        }
        public Sheet Sheet
        {
            get;
            private set;
        }

        public event Action<Sheet> OnSheetPlayed;

        public Flow(PianoKeyboard keyboard)
        {
            this.Background = new RectangleShape();
            this.Background.Position = new Vector2f(8, 0);
            this.Background.Size = new Vector2f(keyboard.GetSize().X, SizeY);
            this.Background.FillColor = Constants.BlackKeyColor;
            this.Keyboard = keyboard;
            this.Notes = new List<FlowNote>();
            CreateVertexes();
        }

        private void CreateVertexes()
        {
            Color color = new Color(120, 120, 120);

            List<Vertex> vertex = new List<Vertex>();
            for (int i = 1; i < 7 * 8; i += 4)
            {
                vertex.Add(new Vertex(new Vector2f(PianoKeyboard.WhiteSize.X * i + 9, 0), color));
                vertex.Add(new Vertex(new Vector2f(PianoKeyboard.WhiteSize.X * i + 9, SizeY), color));
            }

            this.Lines = vertex.ToArray();
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(Background);

            window.Draw(Lines.ToArray(), PrimitiveType.Lines);

            foreach (var note in Notes.FindAll(x => x.Shape.Position.Y + x.Shape.Size.Y > 0))
            {
                note.Draw(window);

            }



            foreach (var note in Notes.ToArray())
            {
                if (!note.Played && note.Shape.Position.Y + note.Shape.Size.Y > SizeY)
                {
                    var key = Keyboard.GetKey(note.SheetNote.Number);
                    Keyboard.SelectKey(key);
                    key.Play(note.SheetNote.Velocity);
                    note.Played = true;


                }
                if (note.Shape.Position.Y > SizeY)
                {
                    var key = Keyboard.GetKey(note.SheetNote.Number);
                    Keyboard.UnselectKey(key);
                    key.Stop();
                    Notes.Remove(note);
                }

                note.Step(PixelSpeed);

            }


        }

        public void AddNote(SheetNote sheetNote, float totalDuration)
        {
            var key = Keyboard.GetKey(sheetNote.Number);
            float ratio = sheetNote.Start / totalDuration;
            var totalPixelSize = PianoKeyboard.WhiteSize.Y * totalDuration;
            var posY = totalPixelSize * ratio - SizeY;
            var sizeY = (sheetNote.End - sheetNote.Start) * PianoKeyboard.WhiteSize.Y;
            Vector2f position = new Vector2f(key.Rectangle.Position.X, -posY);
            position -= new Vector2f(0, sizeY);
            FlowNote note = new FlowNote(sheetNote, key.Note.Sharp, position, sizeY);
            Notes.Add(note);

        }

        public void Play(Sheet sheet)
        {
            foreach (var note in sheet.Notes)
            {
                AddNote(note, sheet.TotalDuration);
            }

            this.Sheet = sheet;

            OnSheetPlayed?.Invoke(Sheet);
        }


    }
}
