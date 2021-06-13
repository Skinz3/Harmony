﻿using Piano.Keys;
using Piano.SFML;
using Piano.Workflow;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano.Rendering
{
    public class PianoRenderer : Renderer
    {
        private const string FontName = "font.ttf";
        public static Font Font;

        public PianoKeyboard Keyboard
        {
            get;
            private set;
        }
        public Flow Flow
        {
            get;
            private set;
        }
        private RectangleShape Footer
        {
            get;
            set;
        }
        public PianoRenderer(IntPtr handle) : base(handle)
        {
            this.Keyboard = new PianoKeyboard(Window, new Vector2f(0, 680));
            Font = new Font(FontName);
            this.Flow = new Flow(Keyboard);

            Footer = new RectangleShape();
            Footer.Size = new Vector2f(Window.Size.X, Window.Size.Y);
            Footer.FillColor = Color.White;
            Footer.Position = new Vector2f(0, 811);
        }

        public override Color ClearColor => Color.White;

        public override void Draw()
        {
            Flow.Draw(Window);
            Keyboard.Draw(Window);
            Window.Draw(Footer);

        }


    }
}
