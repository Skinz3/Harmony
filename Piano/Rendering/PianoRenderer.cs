using Piano.SFML;
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
        public PianoKeyboard Keyboard
        {
            get;
            private set;
        }
       public static Font font;

        public PianoRenderer(IntPtr handle) : base(handle)
        {
            this.Keyboard = new PianoKeyboard(Window, new Vector2f(0, 680));
            font = new Font("font.ttf");
        }

        public override Color ClearColor => Color.White;

        public override void Draw()
        {
            Keyboard.Draw(Window);
        }


    }
}
