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

namespace RoutedEventsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor(s)
        
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Preview Key Down Event Handling in TUNNELLING Down Order


        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Window_PreviewKeyDown");
            //e.Handled = true;
        }

        private void StackPanel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("StackPanel_PreviewKeyDown");
            //e.Handled = true;
        }

        private void Grid1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Grid1_PreviewKeyDown");
            //e.Handled = true;
        }

        private void Button_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Button_PreviewKeyDown");
            //e.Handled = true;
        }

        #endregion

        #region Key Down Event Handling in BUBBLING UP Order

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Button_KeyDown");
            e.Handled = true;
        }

        private void Grid1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Grid1_KeyDown");
            //e.Handled = true;
        }

        private void StackPanel_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("StackPanel_KeyDown");
            //e.Handled = true;
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Window_KeyDown");
            //e.Handled = true;
        }

        #endregion

        #region Unwanted Event Handling

        private void texBox1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("texBox1_PreviewKeyDown");
            //e.Handled = true;
        }

        private void texBox1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("texBox1_KeyDown");
            //e.Handled = true;
        }

        #endregion

    }
}
