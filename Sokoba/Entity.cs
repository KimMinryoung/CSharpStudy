using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoba
{
    class Entity
    {
        public enum Type {player,bomb};
        Type type;
        public int X { get; set; }
        public int Y { get; set; }
        public Entity(Type type,int x,int y)
        {
            this.type = (Type)type;
            X = x;
            Y = y;
        }
        public bool Hit(ConsoleKey direction,Map<Game.TileType> map,Game.TileType cannotGo,Game.TileType HOLE,List<Entity> bombs)//hit당한 후 움직일 수 있으면 오브젝트를 움직이고, hit당한 오브젝트가 움직였는지를 bool값으로 return한다
        {
            int x1 = X, y1 = Y;//출발점의 x,y
            int x2 = x1, y2 = y1;//도착점의 x,y
            if (direction == ConsoleKey.UpArrow) { y2 = y1 - 1; }
            else if (direction == ConsoleKey.DownArrow) { y2 = y1 + 1; }
            else if (direction == ConsoleKey.LeftArrow) { x2 = x1 - 1; }
            else if (direction == ConsoleKey.RightArrow) { x2 = x1 + 1; }
            if(!map.Moveable(x2, y2,cannotGo))
                return false;
            foreach(Entity bomb in bombs)
            {
                if (x2 == bomb.X && y2 == bomb.Y)
                {
                    return false;
                }
            }
            X = x2;
            Y = y2;
            return true;
        }
    }
}
