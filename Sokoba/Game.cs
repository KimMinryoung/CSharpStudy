using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoba
{
    class Game
    {
        public enum TileType { CANNOTGO, EMPTY, HOLE };
        List<Map<TileType>> maps=new List<Map<TileType>>();
        Map<TileType> map;
        List<Entity> bombs=new List<Entity>();
        Entity player;
        public Game()
        {
            System.IO.StreamReader mapFile = new System.IO.StreamReader("mapdata.txt");
            string line;
            while ((line = mapFile.ReadLine()) != null && (line.Length==0||line[0] == ';'))
            {
            }
            List<string> mapLines=new List<string>();
            mapLines.Add(line);
            int maxLength = line.Length;
            while ((line = mapFile.ReadLine()) != null)
            {
                while (line[0]!=';')
                {
                    if (line.Length > maxLength)
                        maxLength = line.Length;
                    mapLines.Add(line);
                    line = mapFile.ReadLine();
                }
                map = new Map<TileType>(maxLength,mapLines.Count,TileType.EMPTY);
                map.mapInterpret(mapLines,TileType.CANNOTGO,TileType.EMPTY,TileType.HOLE);
                maps.Add(map);
                mapLines=new List<string>();
                maxLength = 0;
                mapFile.ReadLine();
            }
            mapFile.Close();
        }
        public void MainGame(int stageNumber)
        {
            map=maps[stageNumber];
            player = new Entity(Entity.Type.player, map.playerStartX, map.playerStartY);
            for(int i = 0; i < map.bombStartXs.Count; i++)
            {
                bombs.Add(new Entity(Entity.Type.bomb,map.bombStartXs[i], map.bombStartYs[i]));
            }
            ConsoleKeyInfo key;
            while (true)
            {
                PrintScreen();
                bool end=true;
                foreach(Entity bomb in bombs)
                {
                    if (!(map.GetValue(bomb.X,bomb.Y)==TileType.HOLE))
                    {
                        end = false;
                        break;
                    }
                }
                if (end)
                    break;
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.RightArrow)
                    PlayerMove(key.Key);
            }
            Console.WriteLine("성공!");
            Console.ReadKey();
        }
        private void PlayerMove(ConsoleKey direction)
        {
            int x1=player.X, y1=player.Y;//출발점의 x,y
            int x2=x1, y2=y1;//도착점의 x,y
            if (direction == ConsoleKey.UpArrow) { y2 = y1 - 1; }
            else if (direction == ConsoleKey.DownArrow) { y2 = y1 + 1; }
            else if (direction == ConsoleKey.LeftArrow) { x2 = x1 - 1; }
            else if (direction == ConsoleKey.RightArrow) { x2 = x1 + 1;}
            if(map.Moveable(x2, y2, TileType.CANNOTGO))
            {
                foreach(Entity bomb in bombs)
                {
                    if (x2 == bomb.X && y2 == bomb.Y)
                    {
                        if (!bomb.Hit(direction,map,TileType.CANNOTGO,TileType.HOLE,bombs))
                            return;
                    }
                }
                player.X = x2;
                player.Y = y2;
            }
        }
        public void PrintScreen()
        {
            Console.Clear();
            for (int y = 0; y < map.Height; y++)
            {
                for(int x = 0; x < map.Width; x++)
                {
                    if (x == player.X && y == player.Y)
                    {
                        switch (map.GetValue(x, y))
                        {
                            case TileType.CANNOTGO: { Console.Write("?"); break; }//bug
                            case TileType.EMPTY: { Console.Write("★"); break; }
                            case TileType.HOLE: { Console.Write("＠"); break; }
                        }
                    }
                    else
                    {
                        bool isBomb = false;
                        foreach (Entity bomb in bombs)
                        {
                            if (x == bomb.X && y == bomb.Y)
                            {
                                switch (map.GetValue(x, y))
                                {
                                    case TileType.CANNOTGO: { Console.Write("?"); break; }//bug
                                    case TileType.EMPTY: { Console.Write("♡"); break; }
                                    case TileType.HOLE: { Console.Write("♥"); break; }
                                }
                                isBomb = true;
                                break;
                            }
                        }
                        if (!isBomb)
                        {
                            switch (map.GetValue(x, y))
                            {
                                case TileType.CANNOTGO: { Console.Write((map.Void[x,y])?"　":"■"); break; }
                                case TileType.EMPTY: { Console.Write("　"); break; }
                                case TileType.HOLE: { Console.Write("○"); break; }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
