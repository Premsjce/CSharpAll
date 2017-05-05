using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Client
    {
        static void Main(string[] args)
        {
            //Non Adaped chemical compound
            Compound unkown = new Compound("unknown");
            unkown.Display();

            //Adapted chemical compounds
            Compound water = new RichCompound("WATER");
            water.Display();

            Compound benzene = new RichCompound("BENZENE");
            benzene.Display();

            Compound ethanol = new RichCompound("ETHANOL");
            ethanol.Display();
        }
    }
}
