using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    class Elevator
    {

        private bool[] floorReady;
        private int currentFloor = 0;
        private int topFloor;
       public ElevatorStatus Status = ElevatorStatus.STOPPED;

        public Elevator(int _noOfFloors = 10)
        {
            floorReady = new bool[_noOfFloors + 1];
            topFloor = _noOfFloors;
        }

        private void Stop(int floor)
        {
            Status = ElevatorStatus.STOPPED;
            currentFloor = floor;
            floorReady[floor] = false;
            Console.WriteLine("Stopped at {0} floor", floor);
        }


        private void Ascend(int floor)
        {
            for(int i = currentFloor; i <= topFloor; i++)
            {
                if (floorReady[i])
                {
                    Stop(floor);
                    break;
                }
                else
                {
                    Console.WriteLine("Moving upside. Now in {0} floor", i);
                    Status = ElevatorStatus.UP;
                }

            }
            Status = ElevatorStatus.STOPPED;
            Console.WriteLine("Waiting...");
        }

        private void Descend(int floor)
        {
            for (int i = currentFloor; i >= 0; i--)
            {
                if (floorReady[i])
                {
                    Stop(floor);
                    break;
                }
                else
                {
                    Console.WriteLine("Moving downside. Now in {0} floor", i);
                    Status = ElevatorStatus.DOWN;
                }
            }
            Status = ElevatorStatus.STOPPED;
            Console.WriteLine("Waiting...");
        }

        private void Stayput(int floor)
        {
            floorReady[floor] = false;
            Console.WriteLine("That is your current Floor. Thanks you");
        }


        public void FloorPressd(int floor)
        {
            if(floor > topFloor)
            {
                Console.WriteLine("We only have {0} floors",topFloor);
                return;
            }

            floorReady[floor] = true;

            switch(Status)
            {
                case ElevatorStatus.UP:
                    //do somethig
                    Ascend(floor);
                    break;
                case ElevatorStatus.DOWN:
                    //Do some other thing
                    Descend(floor);
                    break;
                case ElevatorStatus.STOPPED:
                    //DO some more thing
                    if (currentFloor < floor)
                        Ascend(floor);
                    else if (currentFloor == floor)
                        Stayput(floor);
                    else
                        Descend(floor);
                    break;
                default:
                    //Do  nothing
                    break;
            }

        }
    }
}
