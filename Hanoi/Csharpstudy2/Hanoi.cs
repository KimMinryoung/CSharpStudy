using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpstudy2
{
    public class Hanoi
    {
        private HanoiTower[] towers;
        public int NumOfDisks { get; private set; }
        public int Turns { get; private set; }

        public Hanoi(int numOfDisks)
        {
            Turns = 0;
            NumOfDisks = numOfDisks;
            towers = new HanoiTower[3];
            for (int i = 0; i < 3; i++)
                towers[i] = new HanoiTower(numOfDisks);
            towers[0].InsertAllDisks();
            Draw();
        }
        public void Run()
        {
            ExecuteTurn(NumOfDisks, towers[0], towers[2], towers[1]);
        }
        private void ExecuteTurn(int n, HanoiTower source, HanoiTower via, HanoiTower dest)
        {
            if (n == 1)
            {
                dest.InsertDisk(source.RemoveDisk());
                Turns++;
                Draw();
                return;
            }
            ExecuteTurn(n - 1, source, dest, via);
            ExecuteTurn(1, source, via, dest);
            ExecuteTurn(n - 1, via, source, dest);
        }
        public void Draw()
        {
            Console.WriteLine("제" + Turns + "회");
            for (int i = NumOfDisks - 1; i >= 0; i--)
            {
                foreach (HanoiTower tower in towers)
                {
                    PrintSingleDisk(tower.Disks[i]);
                    Console.Write("   ");
                }
                Console.WriteLine();
            }
        }
        private void PrintSingleDisk(int diskSize)
        {
            for (int j = 1; j <= NumOfDisks; j++)
            {
                Console.Write(diskSize + j > NumOfDisks ? "*" : " ");
            }
            Console.Write("│");
            for (int j = 1; j <= NumOfDisks; j++)
            {
                Console.Write(diskSize - j >= 0 ? "*" : " ");
            }
            Console.Write("   ");
        }
    }
}
