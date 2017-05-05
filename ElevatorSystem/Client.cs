using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    class Client
    {
        static void Main(string [] args)
        {
            const string QUIT = "q";
            string input = string.Empty;
            int floor ;

            Console.WriteLine("Press 'q' to Quit out of system");
            Console.WriteLine("\n\n");

            Elevator elevator = new Elevator();

            while (QUIT != input)
            {
                Console.WriteLine("Press which floor you want to go");

                input = Console.ReadLine();
                if(int.TryParse(input, out floor))
                {
                    elevator.FloorPressd(floor);
                }
                else if(input == QUIT)
                {
                    Console.WriteLine("Not you're exiting the system");
                }
                else
                {
                    Console.WriteLine("Enter valid floor number");
                }                
            }
        }
    }
}
