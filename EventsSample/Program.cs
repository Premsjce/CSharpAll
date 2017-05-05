using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var tower = new ClockTower();

            var john = new Person("Jhon", tower);
            var wick = new Person("wick", tower);
            tower.TimeFivePM();
            //tower.TimeSixAM();

        }
    }

    public class Person
    {
        private string _name;
        private ClockTower _tower;
        public Person(string name, ClockTower tower)
        {
            _name = name;
            _tower = tower;

            _tower.TimeEvent += (object sender, EventArgs args) => { Console.WriteLine("TIme event from asjjdnas from {0}", name); };
            //_tower.TimeEvent += _tower_Time;
        }

        private void _tower_Time()
        {
            Console.WriteLine("genenrated to _tower_time mwthos");
        }
    }

    public delegate void TimeEventHandler(object sender, EventArgs args);
    public class ClockTower
    {
        public event TimeEventHandler TimeEvent;
        public void TimeFivePM()
        {
            if (TimeEvent != null)
                TimeEvent(this, EventArgs.Empty);
        }

        public void TimeSixAM()
        {
            if (TimeEvent != null)
                TimeEvent(this, EventArgs.Empty);
        }
    }
}
