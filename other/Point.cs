using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.other
{
    struct Point
    {
        public readonly int X;
        public readonly int Y;

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public override bool Equals(object obj)
        {
            if(obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            Point other = (Point)obj;

            return other.X == this.X && other.Y == this.Y;
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        public static Point operator /(Point a, int over)
        {
            if (over == 0) throw new ArgumentOutOfRangeException("Can't divide by zero");

            return new Point(a.X / over, a.Y / over);
        }
    }
}
