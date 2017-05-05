using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// The Receiver Class
    /// </summary>
    class Calculator
    {
        private int _current;

        public void Operation(char _operator, int operand)
        {
            switch (_operator)
            {
                case '+':
                    _current += operand;
                    break;
                case '-':
                    _current -= operand;
                    break;
                case '*':
                    _current *= operand;
                    break;
                case '/':
                    _current /= operand;
                    break;
                default:
                    break;
            }

            Console.WriteLine("Current value = {0,3} following {1} {2}", _current, _operator, operand);
        }
    }
}
