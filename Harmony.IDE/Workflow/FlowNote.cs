using Harmony.DP;
using Harmony.IDE.Keys;
using Harmony.IDE.Rendering;
using Harmony.Sheets;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.IDE.Workflow
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

        public bool Played
        {
            get;
            set;
        }
        public bool Disposed
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

            Vector2f rectangleSize = new Vector2f();
            float radius = 0;
            uint ptCount = 0;

            if (!sharp)
            {
                rectangleSize = new Vector2f(Constants.BlackSize.X, sizeY);
                radius = 3;
                ptCount = 10;

            }
            else
            {
                rectangleSize = new Vector2f(Constants.BlackSize.X, sizeY);
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
                this.Shape.Position += new Vector2f(Constants.BlackSize.X / 2f, 0);
            }

            Unfill();
            this.Shape.OutlineThickness = 1f;
            this.Shape.OutlineColor = Color.Transparent;
        }
        public void Unfill()
        {
            if (!SheetNote.Note.Sharp)
            {
                this.Shape.FillColor = new Color(97, 147, 237);
            }
            else
            {
                this.Shape.FillColor = new Color(68, 105, 171);
            }
        }
        [WIP("use delta time")]
        public void Step(float speed)
        {
            Shape.Position += new Vector2f(0, speed);
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(Shape);

            /*Text text = new Text("Y : " + Shape.Position.Y, Constants.Font,8);
            text.Position = new Vector2f(Shape.Position.X, Shape.Position.Y);
            window.Draw(text); */
        }

        public bool IsVisible(float viewTop, float viewBottom)
        {
            var top2 = Shape.Position.Y;
            var bottom2 = Shape.Position.Y + Shape.Size.Y;

            return top2 < viewTop && bottom2 > viewBottom;
        }
    }
}
