﻿using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.GUI.SFML
{
    public abstract class Renderer
    {
        public const uint FrameRateLimit = 60;

        protected RenderWindow Window
        {
            get;
            private set;
        }

        public abstract Color ClearColor
        {
            get;
        }

        public Renderer(VideoMode mode, string title, Styles styles = Styles.Default)
        {
            ContextSettings settings = new ContextSettings();
            settings.AntialiasingLevel = 7;

            this.Window = new RenderWindow(mode, title, styles, settings);
            Initialize();
        }
        public Renderer(IntPtr handle)
        {
            ContextSettings settings = new ContextSettings();
            settings.AntialiasingLevel = 7;


            this.Window = new RenderWindow(handle, settings);
            Initialize();
        }

        private void Initialize()
        {
            Window.SetFramerateLimit(FrameRateLimit);
        }

        public void Display()
        {
            Window.SetActive();

            while (Window.IsOpen)
            {
                Loop();
            }
        }
        public void Loop()
        {
            Window.Clear(ClearColor);
            Window.DispatchEvents();
            Draw();
            Window.Display();
        }

        public abstract void Draw();

        public RenderWindow GetWindow()
        {
            return this.Window;
        }

    }
}
