using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.IDE.Rendering
{
    public abstract class Renderer
    {
        private uint FrameRateLimit
        {
            get;
            set;
        }
        public RenderWindow Window
        {
            get;
            private set;
        }

        public abstract Color ClearColor
        {
            get;
        }

        private ContextSettings Settings;

        public Renderer(IntPtr handle, ContextSettings settings, uint frameRateLimit = 60)
        {
            this.Settings = settings;
            this.FrameRateLimit = frameRateLimit;
            this.Window = new RenderWindow(handle, this.Settings);
            Initialize();
            BindEvents();
        }

        public void RecreateWindow(IntPtr handle)
        {
            Window.Close();
            Window = new RenderWindow(handle, this.Settings);
            BindEvents();
            Initialize();
        }

        public void Initialize()
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

        public abstract void BindEvents();


    }
}
