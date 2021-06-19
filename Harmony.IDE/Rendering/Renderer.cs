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
            protected set;
        }

        public abstract Color ClearColor
        {
            get;
        }

        protected ContextSettings Settings;

        public Renderer(IntPtr handle, ContextSettings settings, uint frameRateLimit)
        {
            this.Settings = settings;
            this.FrameRateLimit = frameRateLimit;
            this.Window = new RenderWindow(handle, this.Settings);
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
    }
}
