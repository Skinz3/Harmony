using Harmony.DP;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.IDE
{
    class Constants
    {
        [WIP("black size X must be 2 times less then white size X ...")]
        public static readonly Vector2f BlackSize = new Vector2f(18, 80);

        public static readonly Vector2f WhiteSize = new Vector2f(36, 130);

        public static readonly Color BlackKeyColor = new Color(63, 63, 70);

        [WIP("byte overflow?")]
        public static readonly byte BlackKeyLightDelta = 10;

        public static readonly Color WhiteKeyColor = Color.White;

        public static readonly Color WhiteKeySelectedColor = new Color(100, 149, 237);

        public static readonly Color BlackKeySelectedColor = new Color(68, 105, 171);

        public static readonly Color KeyHoverColor = new Color(118, 167, 245);

        public const uint FramerateLimit = 60;

        [WIP("load from assembly?")]
        public static readonly Font Font = new Font("font.ttf");

        public const float FlowPixelTimeUnit = 150;

        public static readonly Color FlowLinesColor = new Color(48, 48, 54);
    }
}
