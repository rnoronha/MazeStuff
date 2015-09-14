using MazeGenerator.other;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeGenerator.maze.generator
{
    class Generator
    {
        public static Maze Generate(int width, int height)
        {
            Random r = new Random();
            Point start = new Point(r.Next(width), r.Next(height));

            Maze m = new Maze(width, height);
            List<Room> lookee = new List<Room>();

            lookee.Add(m.Rooms[start]);

            // Implementation of the growing tree maze generation algorithm, with a random node selected every iteration.
            while(lookee.Count > 0)
            {
                int index = r.Next(lookee.Count);
                Room current = lookee[index];

                current.VisitCount++;

                //Out of all the walls available to us, pick the ones which have at least one unvisited neighbor
                var carvableWalls = from wall in current.val where wall.Neighbors.Count(room => room.VisitCount == 0) > 0 select wall;

                //If we have no carvable walls, remove us and continue
                if(!carvableWalls.Any())
                {
                    lookee.RemoveAt(index);
                    continue;
                }

                var toCarve = carvableWalls.RandomElement(r);
                toCarve.Carved = true;

                //We actually do want reference (in)equality here
                lookee.AddRange(from room in toCarve.Neighbors where room != current select room);
            }

            return m;
        }
    }

    static class RandomExtensions
    {
        /// <summary>
        /// a Skeet answer from http://stackoverflow.com/questions/648196/random-row-from-linq-to-sql/648240#648240
        /// Gets a  random element from an IEnumerable with uniform probability in O(N) time.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="rng"></param>
        /// <returns></returns>
        public static T RandomElement<T>(this IEnumerable<T> source,
                                 Random rng)
        {
            T current = default(T);
            int count = 0;
            foreach (T element in source)
            {
                count++;
                if (rng.Next(count) == 0)
                {
                    current = element;
                }
            }
            if (count == 0)
            {
                throw new InvalidOperationException("Sequence was empty");
            }
            return current;
        }
    }
}
