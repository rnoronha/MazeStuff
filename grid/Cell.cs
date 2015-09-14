using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.other
{
    class Cell<T>
    {
        public readonly Point loc;
        public readonly T val;

        public Cell(Point loc, T val)
        {
            this.loc = loc;
            this.val = val;
        }
    }

    class Cell
    {
        public static Cell<T> Create<T>(Point p, T val)
        {
            return new Cell<T>(p, val);
        }
    }
}
