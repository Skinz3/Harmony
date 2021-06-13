using Harmony.Sheets;
using Piano.Keys;
using Piano.Rendering;
using Piano.SFML;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano.Workflow
{
    public class FlowNote : IDrawable
    {
        public RoundedRectangleShape Shape
        {
            get;
            set;
        }
        public SheetNote SheetNote
        {
            get;
            set;
        }

        private Vertex[] Line
        {
            get;
            set;
        }
        public bool Played
        {
            get;
            set;
        }
        public float Duration
        {
            get;
            set;
        }
        public FlowNote(SheetNote note, bool sharp, Vector2f position, float sizeY)
        {
            if (sizeY < 0)
            {
                sizeY = 5;
            }
            this.SheetNote = note;
            this.Duration = note.End - note.Start;

            Vector2f rectangleSize = new Vector2f();
            float radius = 0;
            uint ptCount = 0;

            if (!sharp)
            {
                rectangleSize = new Vector2f(PianoKeyboard.BlackSize.X, sizeY);
                radius = 3;
                ptCount = 10;

            }
            else
            {
                rectangleSize = new Vector2f(PianoKeyboard.BlackSize.X, sizeY);
                radius = 3;
                ptCount = 10;
            }

            if (sizeY < radius)
            {
                radius = 2;
            }


            this.Shape = new RoundedRectangleShape(rectangleSize, radius, ptCount);

            this.Shape.Position = position;

            if (!sharp)
            {
                this.Shape.Position += new Vector2f(PianoKeyboard.BlackSize.X / 2f, 0);
            }

            if (!sharp)
            {
                this.Shape.FillColor = new Color(97, 147, 237);
            }
            else
            {
                this.Shape.FillColor = new Color(68, 105, 171);
            }
            this.Shape.OutlineThickness = 1f;
            this.Shape.OutlineColor = Color.Transparent;
        }
        public void Step(float speed)
        {
            if (Played)
                Duration -= (1 / 60f);

            Shape.Position += new Vector2f(0, speed);
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(Shape);
        }
    }
}
