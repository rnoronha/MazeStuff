using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.other
{
    struct Point
    {
        int X { get; }
        int Y { get; }

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
