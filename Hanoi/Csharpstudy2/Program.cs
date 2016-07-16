using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpstudy2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("n을 입력하세요");
            string input=Console.ReadLine();
            int n = Convert.ToInt32(input);
            Hanoi hanoi = new Hanoi(n);
            hanoi.Run();
        }
    }
}
