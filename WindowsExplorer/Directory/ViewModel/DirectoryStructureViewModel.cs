using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsExplorer
{
    /// <summary>
    /// View Model for the Main application Directory View
    /// </summary>
    /// <seealso cref="WindowsExplorer.BaseViewModel" />
    class DirectoryStructureViewModel : BaseViewModel
    {
        #region Properties

        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
        
        #endregion

        #region Constructor
        public DirectoryStructureViewModel()
        {
            //Get the logical drives
            var children = DirectoryStructure.GetLogicalDrives();
            var grandchildren = children.Select(drive => new DirectoryItemViewModel(drive.FullPath, drive.Type));

            //Create the tree view
            this.Items = new ObservableCollection<DirectoryItemViewModel>(grandchildren);

            
        }
        #endregion
    }

}
