using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Tower tower = new Tower(4,"A", "B");
            tower.TowerSolve(6, "A", "C", "B");
            Console.WriteLine("Total number of steps are {0}", tower.initialCount);
        }
    }
}
