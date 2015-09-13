using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.maze
{
    class MazeBuilder<T> where T : struct
    {
        private Maze<T?> maze;

        public MazeBuilder(int width, int height)
        {
            maze = new Maze<T?>(width, height);
        }

        public Maze<T> ToMaze()
        {
            if (!Complete) throw new InvalidOperationException("Maze is not completely built");

            T[,] result = new T[maze.Width, maze.Height];

            maze.ForEach((i, j, val) => result[i, j] = val.Value);

            return new Maze<T>(result);
        }

        public bool Complete
        {
            get
            {
                return maze.All(v => v.HasValue);
            }
        }

        public Maze<T?> Maze
        {
            get
            {
                return maze;
            }
        }
    }
}
