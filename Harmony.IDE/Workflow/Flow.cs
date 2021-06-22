using Harmony.Audio;
using Harmony.DP;
using Harmony.IDE.Keys;
using Harmony.IDE.Rendering;
using Harmony.Sheets;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.IDE.Workflow
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

        public float TotalPixelTime
        {
            get;
            set;
        } = 2000;

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
        public SheetPlayer SheetPlayer
        {
            get;
            private set;
        }
        public Vector2f Position => Background.Position;

        public event Action<Sheet> OnSheetPlayed;

        public Flow(PianoKeyboard keyboard)
        {
            this.SheetPlayer = new SheetPlayer(keyboard.InstrumentPlayer);
            this.Keyboard = keyboard;
            this.Notes = new List<FlowNote>();
            CreateBackground();
            CreateVertexes();
            UpdatePixelSpeed();
        }

        private void CreateBackground()
        {
            this.Background = new RectangleShape();
            this.Background.Position = new Vector2f(Keyboard.Position.X + (Constants.BlackSize.X / 2), Keyboard.Position.Y - TotalPixelTime);
            this.Background.Size = new Vector2f(Keyboard.GetSize().X, TotalPixelTime);
            this.Background.FillColor = Constants.BlackKeyColor;
        }

        public void Snap(float time)
        {
            bool wasPlaying = !SheetPlayer.Paused;

            this.Load(SheetPlayer.Sheet);


            SheetPlayer.Snap(time); 


            foreach (var note in Notes)
            {
                note.Shape.Position += new Vector2f(0, time * Constants.FlowPixelTimeUnit);
            }

            if (wasPlaying)
            {
                Play();
            }
        }

        private void CreateVertexes()
        {
            Color color = Constants.FlowLinesColor;

            List<Vertex> vertex = new List<Vertex>();

            for (int i = 1; i < 7 * 8; i += 4)
            {
                vertex.Add(new Vertex(new Vector2f(Position.X + Constants.WhiteSize.X * i + 9, Position.Y), color));
                vertex.Add(new Vertex(new Vector2f(Position.X + Constants.WhiteSize.X * i + 9, Position.Y + TotalPixelTime), color));
            }

            this.Lines = vertex.ToArray();
        }

        public void Play()
        {
            this.SheetPlayer.Play();
        }

        public void Pause()
        {
            this.SheetPlayer.Pause();
        }

        public void Draw(RenderWindow window)
        {
            UpdatePixelSpeed();

            SheetPlayer.Update();

            window.Draw(Background);

            window.Draw(Lines.ToArray(), PrimitiveType.Lines);

            View view = window.GetView();
            float viewTop = view.Center.Y + (view.Size.Y / 2);
            float viewBottom = view.Center.Y - (view.Size.Y / 2);

            foreach (var note in Notes.Where(x => x.IsVisible(viewTop, viewBottom)))
            {
                note.Draw(window);
            }

            if (SheetPlayer.Paused)
            {
                return;
            }

            foreach (var note in Notes.ToArray())
            {
                if (!note.Played && note.Shape.Position.Y + note.Shape.Size.Y > Keyboard.Position.Y)
                {
                    var key = Keyboard.GetKey(note.SheetNote.Number);
                    Keyboard.SelectKey(key);
                    note.Played = true;
                }
                if (note.Shape.Position.Y > Keyboard.Position.Y)
                {
                    var key = Keyboard.GetKey(note.SheetNote.Number);
                    Keyboard.UnselectKey(key);
                    key.Stop();
                    Notes.Remove(note);
                }

                note.Step(PixelSpeed);
            }
        }


        public void Load(Sheet sheet)
        {
            Keyboard.UnselectAll();
            this.SheetPlayer.Load(sheet);
            Notes.Clear();
            this.TotalPixelTime = Constants.FlowPixelTimeUnit * sheet.TotalDuration;
            CreateBackground();
            CreateVertexes();

            foreach (var note in sheet.Notes)
            {
                AddNote(note, sheet.TotalDuration);
            }

            UpdatePixelSpeed();

            OnSheetPlayed?.Invoke(sheet);
        }

        public void AddNote(SheetNote note, float totalDuration)
        {
            var sizeY = (note.End - note.Start) * Constants.FlowPixelTimeUnit;
            var key = Keyboard.GetKey(note.Number);
            float ratio = note.Start / totalDuration;
            var posY = Background.Position.Y + Background.Size.Y - sizeY;
            posY -= TotalPixelTime * ratio;
            Vector2f position = new Vector2f(key.Rectangle.Position.X, posY);
            FlowNote flowNote = new FlowNote(note, key.Note.Sharp, position, sizeY);
            Notes.Add(flowNote);
        }
        private void UpdatePixelSpeed()
        {
            var sheet = SheetPlayer.Sheet;

            int tempo = 60;

            if (sheet != null)
            {
                tempo = sheet.Tempo;
            }

            this.PixelSpeed = (tempo * Constants.FlowPixelTimeUnit * SheetPlayer.Clock.ElapsedTime.AsSeconds()) / 60f;
        }
    }
}
