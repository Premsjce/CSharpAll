using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// This is Invoker Class
    /// </summary>
    class User
    {
        //initializers
        private Calculator calculator = new Calculator();
        private List<Command> _commands = new List<Command>();
        private int _current = 0;
 
        public void Compute(char _operator, int operand)
        {
            Command cmnd = new CalculatorCommand(_operator, operand, calculator);
            cmnd.Execute();

            //Add command to undo list
            _commands.Add(cmnd);
            _current++;
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n ---Undoing {0} levels", levels);
            //For Undo operations
            for (int i = 0;i< levels; i++)
            {
                if(_current > 0)
                {
                    Command cmnd = _commands[--_current] as Command;
                    cmnd.UnExecute();
                }
            }
        }

        public void Redo(int levels)
        {
            Console.WriteLine("\n ---Redoing {0} levels", levels);
            //For Redo operations
            for (int i = 0; i < levels; i++)
            {

                if (_current < _commands.Count)
                {
                    Command cmnd = _commands[_current++] as Command;
                    cmnd.Execute();
                }
            }
        }

    }
}
