using Harmony.IDE.Keys;
using Harmony.IDE.Rendering;
using Harmony.IDE.Workflow;
using Harmony.Sheets;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.IDE
{
    public class HarmonyRenderer : Renderer
    {
        public PianoKeyboard Keyboard
        {
            get;
            set;
        }
        public FlowCamera Camera
        {
            get;
            private set;
        }
        public Flow Flow
        {
            get;
            private set;
        }

        public HarmonyRenderer(IntPtr handle, ContextSettings settings) : base(handle, settings, Constants.FramerateLimit)
        {
            this.Keyboard = new PianoKeyboard(new Vector2f(Constants.BlackSize.X, Window.Size.Y));
            this.Flow = new Flow(Keyboard);
            this.Camera = new FlowCamera(Window.GetView(), Keyboard.Position, Flow);
            Keyboard.OnKeyPressed += OnKeyPressed;
        }

        private void OnKeyPressed(Key key)
        {
            Keyboard.InstrumentPlayer.Play(key.Note.Number, 100f);
        }

        public override Color ClearColor => new Color(63, 63, 70);

        public override void Draw()
        {
            Flow.Draw(Window);
            Keyboard.Draw(Window);
        }
        private void MouseWheelScrolled(object sender, MouseWheelScrollEventArgs e)
        {
            Camera.Scroll(e.Delta);
            Window.SetView(Camera.View);
        }

        public void Load(Sheet sheet)
        {
            this.Keyboard.UnselectAll();
            this.Flow.Load(sheet); 
        }

        public void RecreateWindow(IntPtr handle)
        {
            Window.Close();
            Window = new RenderWindow(handle, this.Settings);
            Camera.View = Window.GetView();
            this.Window.MouseWheelScrolled += MouseWheelScrolled;
            this.Window.MouseButtonPressed += Keyboard.OnMouseButtonPressed;
            Initialize();
            Camera.Restore();
            Window.SetView(Camera.View);
        }
      
    }
}
