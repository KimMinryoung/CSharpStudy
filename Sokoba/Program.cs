using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoba
{
    class Program
    {
        public enum TileType { CANNOTGO, EMPTY, HOLE };
        static void Main(string[] args)
        {
            Game game=new Game();
            Console.WriteLine("stage를 고르세요(1~90)");
            int stage = Convert.ToInt32(Console.ReadLine())-1;
            game.MainGame(stage);
        }
    }
}
