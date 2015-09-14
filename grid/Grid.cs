using MazeGenerator.other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.maze
{
    class Grid<T, V> where T : Cell<V>
    {
        protected T[,] array;

        public Grid(int width, int height)
        {
            if (width <= 0 || height <= 0) throw new ArgumentOutOfRangeException("Width and height should be greater than zero");

            array = new T[width, height];

            for (int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    array[i, j] = Activator.CreateInstance(typeof(T), new object[] { new Point(i, j) }) as T;
                }
            }
        }

        public Grid(T[,] array)
        {
            this.array = array;
        }

        public List<T> CardinalAdjacent(Point p)
        {
            return CardinalAdjacent(p.X, p.Y);
        }

        public List<T> CardinalAdjacent(int x, int y)
        {
            var results = new List<T>();

            //This almost seems like a waste of a for loop
            for(int i = -1; i < 2; i += 2)
            {
                results.Add(this[i + x, y]);
                results.Add(this[x, i + y]);
            }

            return results;
        }

        public void ForEach(Action<Cell<V>> a)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    a(this[i, j]);
                }
            }
        }

        public void ForEach(Action<V> a)
        {
            ForEach((v) => a(v.val));
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

        public bool All(Func<Cell<V>, bool> f)
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
                    var tmp = this[i, j].val;
                    if (!tmp.Equals(default(T)))
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
                x = (x + Width) % Width;
                y = (y + Height) % Height;

                return array[x, y];
            }

            set
            {
                x = (x + Width) % Width;
                y = (y + Height) % Height;

                array[x, y] = value;
            }
        }
        
        public T this[Point p]
        {
            get { return this[p.X, p.Y]; }

            set { this[p.X, p.Y] = value; }
        }

        public int Width
        {
            get { return array.GetLength(0); }
        }

        public int Height
        {
            get { return array.GetLength(1); }
        }
    }
}
