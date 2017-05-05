using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowsExplorer
{
    /// <summary>
    /// A basic command that runs on an acion
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class RelayCommand : ICommand
    {
        #region Construtor        
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// Default Constructor
        /// </summary>
        public RelayCommand(Action _action)
        {
            this.action = _action;
        }

        #endregion

        #region Private Members

        /// <summary>
        /// The action to run
        /// </summary>
        private Action action;
        #endregion

        #region Public Events
        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// The event thats is fired when <see cref="CanExecute(object)"/> mehtod value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, args) => { };

        #endregion

        #region Command Methods

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// A Relay command can always execute
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// Executes the Command Action
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Execute(object parameter)
        {
            action();
        }

        #endregion
    }
}
