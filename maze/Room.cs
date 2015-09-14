using MazeGenerator.other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.maze
{
    class Room : Cell<List<Wall>>
    {
        public int VisitCount { get; set; }

        /// <summary>
        /// The walls adjacent to this room. Shared with other rooms. There's always 4. 
        /// order is Never Eat Soggy Worms: 
        /// 0: N
        /// 1: E
        /// 2: S
        /// 3: W
        /// </summary>
        public Room(Point p, List<Wall> walls) : base(p, walls)
        {
            var me = this;
            walls.ForEach(w => w.Neighbors.Add(me));
        }

        public Room(Point p) : base(p)
        {
        }
    }
}
