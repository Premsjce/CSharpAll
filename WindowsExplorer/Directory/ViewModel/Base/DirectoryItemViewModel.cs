using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WindowsExplorer
{
    /// <summary>
    /// View model for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryViewModel"/> class.
        /// default Costrutor
        /// </summary>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            this.FullPath = fullPath;
            this.Type = type;
            this.ExpandCommand = new RelayCommand(Expand);
            this.Collapse();
        }
        #endregion

        #region Properties
        /// <summary>
        /// full valid path for the item.
        /// </summary>
        /// <value>
        /// The full path.
        /// </value>
        public string FullPath { get; set; }

        /// <summary>
        /// The type of the item.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// Name of the Directory item
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return this.Type == DirectoryItemType.DRIVE ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath);
            }
        }

        /// <summary>
        /// List of childres contained inside this item.
        /// </summary>
        /// <value>
        /// The childrens.
        /// </value>
        public ObservableCollection<DirectoryItemViewModel> Childrens { get; set; }

        /// <summary>
        /// Indicates if the item can be expanded
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can expand; otherwise, <c>false</c>.
        /// </value>
        public bool CanExpand
        {
            get
            {
                return this.Type != DirectoryItemType.FILE;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether current item is expanded or not.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is expanded; otherwise, <c>false</c>.
        /// </value>
        public bool IsExpanded
        {
            get
            {
                return Childrens?.Count(file => file != null) > 0;
            }
            set
            {
                //If UI tells us to Expand
                if (value == true)
                    //Find all children
                    Expand();
                else
                    //Collapse and clear child items
                    Collapse();
            }
        }

        #endregion

        #region Public Commands
        public ICommand ExpandCommand { get; set; }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Collapses the items and clears all the children items.
        /// Adding a dummy item to show the expanded iconif required
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void Collapse()
        {
            //Clear childrens
            this.Childrens = new ObservableCollection<DirectoryItemViewModel>();

            //Show the expanded icon if we are not a file
            if (this.Type != DirectoryItemType.FILE)
                this.Childrens.Add(null);
        }

        #endregion

        #region Expand method
        
        /// <summary>
        /// Expands this directory and finds all the childrens.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void Expand()
        {
            if (this.Type == DirectoryItemType.FILE)
                return;

            //Find all childers
            //Solution 1
            //var childrens = new ObservableCollection<DirectoryItemViewModel>();
            //List<DiretoryItem> items = DirectoryStructure.GetDirectoryContents(this.FullPath);
            //ObservableCollection<DirectoryItemViewModel> collection = new ObservableCollection<DirectoryItemViewModel>();
            //collection = items.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)) as ObservableCollection<DirectoryItemViewModel>;
            //this.Childrens = collection;

            //Solution 2
            //this.Childrens = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetDirectoryContents(FullPath).Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));

            //Solution3
            var children = DirectoryStructure.GetDirectoryContents(this.FullPath);
            this.Childrens = new ObservableCollection<DirectoryItemViewModel>(
                                children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }
        #endregion



    }
}
