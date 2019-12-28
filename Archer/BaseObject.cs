using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer
{
    abstract class BaseObject
    {
        public struct Vector
        {
            double xPosition;
            double yPosition;

            public Vector(int x, int y)
            {
                xPosition = x;
                yPosition = y;
            }
        }

        public Vector Position { get; private set; }
        public double Size { get; private set; }

        public BaseObject(Vector position, double size) : this(size)
        {
            Position = position;
        }

        public BaseObject(double size)
        {
            Size = size;
        }

        public void SetNewPosition(Vector position)
        {
            Position = position;
        }
    }
}
