using Harmony.IDE.Keys;
using Harmony.IDE.Rendering;
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
        public HarmonyRenderer(IntPtr handle, ContextSettings settings) : base(handle, settings)
        {
            this.Keyboard = new PianoKeyboard(Window, new Vector2f(0, Window.Size.Y));
        }

        public override Color ClearColor => new Color(48, 48, 54);

        public static Font Font
        {
            get;
            internal set;
        }

        public override void Draw()
        {
            Keyboard.Draw(Window);
        }
        private void MouseWheelScrolled(object sender, MouseWheelScrollEventArgs e)
        {
            var view = this.Window.GetView();

            float delta = e.Delta * 20;

            if (delta < 0)
            {
                if (view.Center.Y + (view.Size.Y/2) - delta>  this.Keyboard.Position.Y + PianoKeyboard.WhiteSize.Y)
                {
                    return;
                }
            }

            view.Center = new Vector2f(view.Center.X, view.Center.Y - delta);
            Window.SetView(view);
        }

        public override void BindEvents()
        {
            this.Window.MouseWheelScrolled += MouseWheelScrolled;
        }


    }
}
