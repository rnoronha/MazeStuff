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
            var maze = Generator.Generate(30, 39);

            Console.WriteLine(maze.toCellGrid('.', '#'));
            Console.ReadLine();
        }
    }
}
