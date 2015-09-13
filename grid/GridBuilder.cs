using MazeGenerator.other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.maze
{
    class GridBuilder<T> where T : struct
    {
        private Grid<T?> grid;

        public GridBuilder(int width, int height)
        {
            grid = new Grid<T?>(width, height);
        }

        public Grid<T> Build()
        {
            if (!Complete) throw new InvalidOperationException("Maze is not completely built");

            Cell<T>[,] result = new Cell<T>[grid.Width, grid.Height];

            grid.ForEach((i, j, cell) => result[i, j] = new Cell<T>(new Point(i, j), cell.val.Value));

            return new Grid<T>(result);
        }

        public bool Complete
        {
            get
            {
                return grid.All(v => v.val.HasValue);
            }
        }

        public Grid<T?> Grid
        {
            get
            {
                return grid;
            }
        }
    }
}
