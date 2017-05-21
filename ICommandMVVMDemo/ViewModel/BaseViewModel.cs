#region MS Directives
using System.ComponentModel;
#endregion

namespace ICommandMVVMDemo.ViewModel
{
    /// <summary>
    /// Base Viewmodel class which implements INotifyPropertyChanged Interface
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Event(s)
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Protected Method(s)        
        protected virtual void OnPropertychanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
