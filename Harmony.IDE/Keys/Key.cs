using Harmony.IDE.Rendering;
using Harmony.Notes;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.IDE.Keys
{
    public class Key : IDrawable
    {
        public Note Note
        {
            get;
            private set;
        }
        public RectangleShape Rectangle
        {
            get;
            private set;
        }
        private RectangleShape AdditionalRectangle
        {
            get;
            set;
        }
        private Text Text
        {
            get;
            set;
        }
        public bool DrawMetadata
        {
            get;
            set;
        }
        public Key(Note note, Vector2f position)
        {
            this.Note = note;
            this.Rectangle = new RectangleShape();
            this.Rectangle.Position = position;

            Rectangle.Size = note.Sharp ? Constants.BlackSize : Constants.WhiteSize;
            Rectangle.FillColor = note.Sharp ? Constants.BlackKeyColor : Constants.WhiteKeyColor;
            Rectangle.OutlineColor = Color.Black;
            Rectangle.OutlineThickness = 0.9f;

            if (Note.Sharp)
            {
                AdditionalRectangle = new RectangleShape();
                AdditionalRectangle.Size = new Vector2f(Rectangle.Size.X, Rectangle.Size.Y / 2f);
                AdditionalRectangle.Position = Rectangle.Position;
                AdditionalRectangle.FillColor = new Color((byte)(Constants.BlackKeyColor.R + Constants.BlackKeyLightDelta)
            , (byte)(Constants.BlackKeyColor.G + Constants.BlackKeyLightDelta), (byte)(Constants.BlackKeyColor.B + Constants.BlackKeyLightDelta));
            }


            Text = new Text(Note.ToString(), Constants.Font, 12);
            Text.Position = this.Rectangle.Position + new Vector2f(2, +50);

            if (Note.Sharp)
            {
                Text.Rotation = 180 + 90;
                Text.FillColor = Color.White;
            }
            else
            {
                Text.FillColor = Color.Black;
                Text.Position += new Vector2f(8, +60);
            }
        }

        public void Draw(RenderWindow window)
        {

            window.Draw(Rectangle);

            if (AdditionalRectangle != null)
            {
                window.Draw(AdditionalRectangle);
            }

            if (DrawMetadata)
            {
                window.Draw(Text);
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

            if (AdditionalRectangle != null)
            {
                AdditionalRectangle.FillColor = new Color((byte)(color.R + Constants.BlackKeyLightDelta), (byte)(color.G + Constants.BlackKeyLightDelta), (byte)(color.B + Constants.BlackKeyLightDelta));
            }
        }
        public void UnFill()
        {
            if (Note.Sharp)
            {
                Rectangle.FillColor = Constants.BlackKeyColor;
                AdditionalRectangle.FillColor = new Color((byte)(Constants.BlackKeyColor.R + Constants.BlackKeyLightDelta)
            , (byte)(Constants.BlackKeyColor.G + Constants.BlackKeyLightDelta), (byte)(Constants.BlackKeyColor.B + Constants.BlackKeyLightDelta));

            }
            else
            {
                Rectangle.FillColor = Constants.WhiteKeyColor;
            }
        }


    }
}
