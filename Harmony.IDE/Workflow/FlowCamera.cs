using Harmony.DP;
using Harmony.IDE.Keys;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.IDE.Workflow
{
    public class FlowCamera
    {
        private const float CameraSpeed = 20;

        public View View
        {
            get;
            set;
        }
        public float Y
        {
            get;
             set; // private
        }
        private Vector2f KeyboardPosition
        {
            get;
            set;
        }
        private Flow Flow
        {
            get;
            set;
        }
        public FlowCamera(View view, Vector2f keyboardPosition, Flow flow)
        {
            this.KeyboardPosition = keyboardPosition;
            this.Flow = flow;
            this.View = view;
        }
        [WIP("needs douteau (Math.log)")]
        public void Scroll(float scrollDelta)
        {
            float delta = scrollDelta * CameraSpeed;

            if (delta < 0)
            {
                if (View.Center.Y + (View.Size.Y / 2) - delta > this.KeyboardPosition.Y + Constants.WhiteSize.Y)
                {
                    return;
                }
            }

            if (delta > 0)
            {
                if (View.Center.Y - (View.Size.Y / 2) - delta < (KeyboardPosition.X + Constants.WhiteSize.Y) - Flow.TotalPixelTime)
                {
                    return;
                }

            }
            View.Center = new Vector2f(View.Center.X, View.Center.Y - delta);
            Y += delta;
        }


        public void Restore()
        {
            float v1 = KeyboardPosition.Y + (Constants.WhiteSize.Y);
            float v2 = v1 - View.Size.Y / 2;
            v2 -= Y;
            View.Center = new Vector2f(View.Center.X, v2);
        }
    }
}
