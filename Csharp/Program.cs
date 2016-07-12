using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    class Program
    {
        static void PrintSingleFloor(int n,int num)
        {
                for(int j=1;j<= n; j++)
                {
                    Console.Write(num + j > n ? "*" : " ");
                }
                Console.Write("│");
                for (int j = 1; j <= n; j++)
                {
                    Console.Write(num-j >= 0 ? "*" : " ");
                }
                Console.Write("   ");
        }
        static void PrintTowers(int n,int[] towerA,int[] towerB,int[] towerC)
        {
            int num;
            for(int i=n-1;i>=0;i--)
            {
                num = towerA[i];
                PrintSingleFloor(n, num);
                num = towerB[i];
                PrintSingleFloor(n, num);
                num = towerC[i];
                PrintSingleFloor(n, num);
                Console.WriteLine();
            }
        }
        static void Hanoi(int n,int[] towerA,int[] towerB,int[] towerC)
        {
            if (towerB[n - 1] != 0)
                return;
        }
        static void Main(string[] args)
        {
            int[] towerA = { 5, 4, 0, 0, 0 };
            int[] towerB = { 2, 1, 0, 0, 0 }; 
            int[] towerC = { 3, 0, 0, 0, 0 };
            PrintTowers(5, towerA, towerB, towerC);
        }
    }
}