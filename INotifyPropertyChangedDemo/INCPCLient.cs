using INotifyPropertyChangedDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotifyPropertyChangedDemo
{
    public class INCPCLient 
    {
        public INCPCLient()
        {
            //Default constructor
        }
        public void SampelMetofOfINCPCLient()
        {
            INPCSource icnp = new INPCSource();
            icnp.SampleMethod("asdjaskd");
        }
    }
}
