using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sokoba
{
    public class Grid<T>
    {
        protected T[,] data;

        public int Width { get; set; }
        public int Height { get; set; }
        public bool[,] Void { get; set; }

        public Grid(int width, int height)
        {
            data = new T[width, height];
            Void = new bool[width, height];
            Width = width;
            Height = height;
        }

        public Grid(int width, int height, T value) : this(width, height)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    data[i, j] = value;
                }
            }
        }

        public T GetValue(int x, int y)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
                return data[x, y];
            else
            {
                Console.WriteLine("범위 밖으로 넘어갔다");
                return default(T);
            }
        }

        public void SetValue(int x, int y, T value)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
                data[x, y] = value;
            else
                Console.WriteLine("범위 밖");
        }

        public bool Moveable(int x,int y,T cannotGo)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height && !EqualityComparer<T>.Default.Equals(data[x, y], cannotGo);
        }

        public void Print()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Console.Write(data[x, y] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
