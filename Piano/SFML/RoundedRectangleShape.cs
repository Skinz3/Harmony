using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano.SFML
{
    public class RoundedRectangleShape : Shape
    {
        public Vector2f Size
        {
            get;
            private set;
        }
        private float Radius
        {
            get;
            set;
        }
        private uint CornerPointCount
        {
            get;
            set;
        }
        public RoundedRectangleShape(Vector2f size, float radius, uint cornerPointCount)
        {
            this.Size = size;
            this.Radius = radius;
            this.CornerPointCount = cornerPointCount;
        }
        public override Vector2f GetPoint(uint index)
        {
            if (index >= CornerPointCount * 4)
                return new Vector2f();

            double deltaAngle = 90.0d / (CornerPointCount - 1);
            Vector2f center = new Vector2f();
            uint centerIndex = index / CornerPointCount;
            const double pi = 3.141592654f;

            switch (centerIndex)
            {
                case 0: center.X = Size.X - Radius; center.Y = Radius; break;
                case 1: center.X = Radius; center.Y = Radius; break;
                case 2: center.X = Radius; center.Y = Size.Y - Radius; break;
                case 3: center.X = Size.X - Radius; center.Y = Size.Y - Radius; break;
            }

            return new Vector2f(Radius * (float)Math.Cos(deltaAngle * (index - centerIndex) * pi / 180) + center.X,
                                -Radius * (float)Math.Sin(deltaAngle * (index - centerIndex) * pi / 180) + center.Y);
        }

        public override uint GetPointCount()
        {
            return CornerPointCount * 4;
        }
    }
}
