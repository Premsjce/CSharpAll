using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class ScientificCalculator
    {
        public int NumberOne { get; set; }
        public int NumberTwo { get; set; }

        public int Add()
        {
            //Simulate that some serious work is being done here such that it takes 2 Seconds
            Thread.Sleep(2000);
            return NumberOne + NumberTwo;
        }
    }
}
