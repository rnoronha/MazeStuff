using MazeGenerator.other;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeGenerator.maze.generator
{
    class Generator<T> where T : struct
    {
        public static Maze Generate(int width, int height, T open, T wall)
        {
            return null;
            /*
            Random r = new Random();
            Point start = new Point(r.Next(width), r.Next(height));

            List<Point> lookee = new List<Point>();

            lookee.Add(start);

            while(lookee.Count > 0)
            {
                int index = r.Next(lookee.Count);
                Point current = lookee[index];
                lookee.RemoveAt(index);

                if(m[current].val.HasValue)
                {
                    continue;
                }

                var adj = m.CardinalAdjacent(current);

                //If there's at least two walls cardinally adjacent to this one, it can't be open
                if(adj.Count(c => c.val.HasValue && c.val.Value.Equals(open)) >= 2)
                {
                    m[current] = new Cell<T?>(current, wall);
                } 
                else
                {
                    m[current] = new Cell<T?>(current, open);
                }

                lookee.AddRange(from cell in adj where !cell.val.HasValue select cell.loc);
            }
            
            return builder.Build();
            */
        }
    }
}
