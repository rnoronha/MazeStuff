using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.maze
{
    /// <summary>
    /// This is a reference class so rooms can share them
    /// </summary>
    class Wall
    {
        public bool Carved { get; set; }
        public List<Room> Neighbors {
            get; set;
        }

        public Wall()
        {
            Neighbors = new List<Room>();
            Carved = false;
        }
    }
}
