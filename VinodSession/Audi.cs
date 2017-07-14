using System;

namespace VinodSession
{
    public class Audi : ICar
    {
        public void Accelerate()
        {
            Console.WriteLine(this.GetType().Name + " car is accelrating");
        }

        public void ApplyBrake()
        {
            Console.WriteLine(this.GetType().Name + " car is applying Brake");
        }

        public void GetSpeed()
        {
            Console.WriteLine(this.GetType().Name + " car is catchig speed");
        }

        public void TurnHandle()
        {
            Console.WriteLine(this.GetType().Name + " car turn handle");
        }
    }
}
 