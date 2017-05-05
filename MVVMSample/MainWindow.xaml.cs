using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ContactViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            ContactViewModel _contactvm = new ContactViewModel();
            _contactvm.LoadCotacts();
            ContactViewControlColumn1.DataContext = _contactvm;
            ContactViewControlColumn2.DataContext = _contactvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Model updated in tow ay binding");
        }
    }
}
