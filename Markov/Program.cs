using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markov
{
    class Program
    {
        static void Main(string[] args)
        {
            MarkovText markovText = new MarkovText("text.txt");
            markovText.Run(50);
        }
    }
}
