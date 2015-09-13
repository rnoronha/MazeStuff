using MazeGenerator.other;
using System;

namespace MazeGenerator.maze.generator
{
    class Generator<T> where T : struct
    {
        public static Maze<T> Generate(int width, int height, T open, T wall)
        {
            MazeBuilder<T> builder = new MazeBuilder<T>(width, height);

            Random r = new Random();
            Point start = new Point(r.Next(width), r.Next(height));
            
            return builder.ToMaze();
        }
    }
}
