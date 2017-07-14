using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinodSession
{
    public class Driver
    {
        public void  Drive(ICar car)
        {
            car.Accelerate();
            car.ApplyBrake();
            car.TurnHandle();
            car.GetSpeed();
        }
    }
}
