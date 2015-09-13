using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.maze
{
    class Maze<T>
    {
        protected T[,] array;

        public Maze(int width, int height)
        {
            if (width <= 0 || width <= 0) throw new ArgumentOutOfRangeException("Width and height should be greater than zero");

            array = new T[width, height];
        }

        public Maze(T[,] array)
        {
            this.array = array;
        }

        public Maze<T> Adjacent(int x, int y)
        {
            T[,] results = new T[3,3];

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    results[i, j] = this[x + i, y + j];
                }
            }

            return new Maze<T>(results);
        }

        public void ForEach(Action<int, int, T> a)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    a(i, j, this[i, j]);
                }
            }
        }

        public void ForEach(Func<int, int, T> a)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    this[i, j] = a(i, j);
                }
            }
        }

        public void ForEach(Action<T> a)
        {
            ForEach((i, j, v) => a(v));
        }

        public bool All(Func<T, bool> f)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if(!f(array[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    var str = "?";
                    var tmp = this[i, j];
                    if (tmp.Equals(default(T)))
                    {
                        str = tmp.ToString();
                    }
                    sb.Append(str);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        /// <summary>
        /// We assume that the maze wraps around
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public T this[int x, int y]
        {
            get
            {
                x = x % Width;
                y = y % Height;

                return array[x, y];
            }

            set
            {
                x = x % Width;
                y = y % Height;

                array[x, y] = value;
            }
        }

        public int Width
        {
            get
            {
                return array.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return array.GetLength(1);
            }
        }
    }
}
