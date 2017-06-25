#region MS Directive(s)
using System;
using System.Windows.Input;
#endregion

namespace WPFSongsLibrary.Commands
{
    /// <summary>
    /// Relay Command 
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class RelayCommand : ICommand
    {
        #region Constructor(s)
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public RelayCommand(Action action)
        {
            this.action = action;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="func">The function.</param>
        public RelayCommand(Action action, Func<bool> func)
        {
            this.action = action;
            this.func = func;
        }

        #endregion

        #region Event
        public event EventHandler CanExecuteChanged= delegate { };
        #endregion

        #region Public Method(s)        
        /// <summary>
        /// Determines whether this instance can execute the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (func != null)
            {
                return func();
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public void Execute(object parameter)
        {
            action();
        }
        #endregion

        #region Field(s)

        /// <summary>
        /// The action
        /// </summary>
        private Action action;

        /// <summary>
        /// The function
        /// </summary>
        private Func<bool> func;
        #endregion
    }
}
