using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoba
{
    public class Map<T>: Grid<T>
    {
        public int playerStartX, playerStartY;
        public List<int> bombStartXs, bombStartYs;
        public Map(int width,int height,T defaultValue) :base(width,height)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    data[i, j] = defaultValue;
                }
            }
            bombStartXs = new List<int>();
            bombStartYs = new List<int>();
        }
        public void mapInterpret(List<string> mapLines,T CANNOTGO,T EMPTY,T HOLE)
        {
            for(int y=0;y<mapLines.Count;y++)
            {
                bool inside=false;
                int x = 0;
                for(; x < mapLines[y].Length; x++)
                {
                    if (mapLines[y][x] == '#')
                    {
                        inside = true;
                        data[x, y] = CANNOTGO;
                        Void[x, y] = false;
                    }
                    else if (mapLines[y][x] == ' ')
                    {
                        if (inside)
                        {
                            data[x, y] = EMPTY;
                        }
                        else
                        {
                            data[x, y] = CANNOTGO;
                            Void[x, y] = true;
                        }
                    }
                    else if (mapLines[y][x] == '.')
                    {
                        data[x, y] = HOLE;
                    }
                    else if (mapLines[y][x] == '$')
                    {
                        data[x, y] = EMPTY;
                        bombStartXs.Add(x);
                        bombStartYs.Add(y);
                    }
                    else if (mapLines[y][x] == '@')
                    {
                        data[x, y] = EMPTY;
                        playerStartX=x;
                        playerStartY=y;
                    }
                }
                for (; x < Width; x++)
                {
                    data[x, y] = CANNOTGO;
                    Void[x, y] = true;
                }
            }
        }
    }
}
