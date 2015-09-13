using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.maze.generator
{
    class Generator<T> where T : struct
    {
        public static Maze<T> Generate(int width, int height, T open, T wall)
        {
            MazeBuilder<T> builder = new MazeBuilder<T>(width, height);

            Random r = new Random();
            builder.Maze.ForEach((i, j) => r.Next(2) == 1 ? open : wall);
            
            return builder.ToMaze();
        }
    }
}
