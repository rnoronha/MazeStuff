using MazeGenerator.other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.maze
{
    class Maze
    {
        public readonly Grid<Room, List<Wall>> Rooms;

        public Maze(int width, int height)
        {
            Rooms = new Grid<Room, List<Wall>>(width, height);

            /* Item1 is North, Item2 is East. Therefore, and since the grids wrap, for a wall at i, j: 
             ** North is [i, j].Item1
             ** East is [i, j].Item2
             ** South is [i, j - 1].Item1
             ** West is [i - 1, j].Item2
             */
            var northEastWalls = new Grid<Cell<Tuple<Wall, Wall>>, Tuple<Wall, Wall>>(width, height);

            northEastWalls.ForEach((i, j) => Cell.Create(new Point(i, j), Tuple.Create(new Wall(), new Wall())));

            Rooms.ForEach((i, j) => new Room(new Point(i, j), 
                                             new List<Wall>() { northEastWalls[i, j].val.Item1,
                                                                northEastWalls[i, j].val.Item2,
                                                                northEastWalls[i, j - 1].val.Item1,
                                                                northEastWalls[i - 1, j].val.Item2 }
                                             ));


            northEastWalls.ForEach((t) =>
            {
                if(t.Item1.Neighbors.Count != 2)
                {
                    throw new ArgumentException();
                }
                if (t.Item2.Neighbors.Count != 2)
                {
                    throw new ArgumentException();
                }
            });

        }

    }
}
