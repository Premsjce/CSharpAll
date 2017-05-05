using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class CalculatorCommand : Command
    {
        private char _operator;
        private int operand;
        private Calculator calculator;

        public CalculatorCommand(char oprtr, int oprnd, Calculator clctr)
        {
            _operator = oprtr;
            operand = oprnd;
            calculator = clctr;
        }


        public override void Execute()
        {
            calculator.Operation(_operator, operand);
        }


        public override void UnExecute()
        {
            _operator = Undo(_operator);
            calculator.Operation(_operator, operand);
        }


        private char Undo(char _oprator)
        {
            switch(_operator)
            {
                case '+':
                    return '-';
                case '-':
                    return '+';
                case '*':
                    return '/';
                case '/':
                    return '*';
                default:
                    throw new ArgumentNullException();
            }
        }
    }
}
