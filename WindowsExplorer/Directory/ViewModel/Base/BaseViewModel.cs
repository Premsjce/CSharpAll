using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsExplorer
{
    /// <summary>
    /// A Base view model that fires the property changed event as and when needed
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
