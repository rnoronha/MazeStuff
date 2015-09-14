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
            var maze = Generator.Generate(10, 10);


            Console.WriteLine(maze.ToString());
            Console.ReadLine();
        }
    }
}
