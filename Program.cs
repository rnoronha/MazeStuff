using MazeGenerator.maze;
using MazeGenerator.maze.generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze<int> maze = Generator<int>.Generate(30, 79, 1, 2);


            Console.WriteLine(maze.ToString());
            Console.ReadLine();
        }
    }
}
