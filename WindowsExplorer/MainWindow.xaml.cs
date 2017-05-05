using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WindowsExplorer
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new DirectoryStructureViewModel();
        }

        #endregion


    }
}
