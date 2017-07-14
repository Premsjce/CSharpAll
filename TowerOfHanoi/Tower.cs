using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    public class Tower : ITower
    {
        private int NoOfDiscs;
        private string DiskA;
        private string DiskB;
        private string DiskC;
        public int initialCount = 0;

        public Tower(int discs, string source, string destination)
        {
            this.NoOfDiscs = discs;

            switch(source)
            {
                case "DiskA":
                    DiskA = source;
                    break;

                case "DiskB":
                    DiskB = source;
                    break;

                case "DiskC":
                    DiskC = source;
                    break;
            }

            switch (source)
            {
                case "DiskA":
                    DiskA = source;
                    break;

                case "DiskB":
                    DiskB = source;
                    break;

                case "DiskC":
                    DiskC = source;
                    break;
            }
        }

        public void Solve()
        {
            //Do nothign
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void TowerSolve(int disks, string source, string destination, string temp)
        {
            if(disks == 1)
            {
                Console.WriteLine("Moving Disk from {0} to {1}", source, destination);
                initialCount += 1;

                return;
            }

            TowerSolve((disks - 1), source, temp,destination);
            Console.WriteLine("Moving Disk from {0} to {1}", source, destination);
            initialCount += 1;


            TowerSolve((disks - 1),temp, destination, source);

            

        }
    }
}

