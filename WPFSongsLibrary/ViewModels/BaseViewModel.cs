
#region MS Directives
using System.ComponentModel;
#endregion

namespace WPFSongsLibrary.ViewModels
{
    /// <summary>
    /// Base View model whcih implements INotipropertyChanged Interface
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Event        
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Protected Method(s)        
        /// <summary>
        /// Raises event when the property changed.
        /// </summary>
        /// <param name="property">The property.</param>
        protected virtual void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion

    }
}
