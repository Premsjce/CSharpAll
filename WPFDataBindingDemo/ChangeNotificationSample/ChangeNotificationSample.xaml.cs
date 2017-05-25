using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace WPFDataBindingDemo
{
    /// <summary>
    /// Interaction logic for ChangeNotificationSample.xaml
    /// </summary>
    public partial class ChangeNotificationSample : Window
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();

        public ChangeNotificationSample()
        {
            InitializeComponent();
            users.Add(new User() { Name= "Prem Kumar" });
            users.Add(new User() { Name = "Chethan Kumar" });
            users.Add(new User() { Name = "ManSingh" });

            lstboxUsers.ItemsSource = users;

        }


        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User() { Name = "Added a new User" });

        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if(lstboxUsers.SelectedItem != null)
            {
                (lstboxUsers.SelectedItem as User).Name = "Changes the User Name ;)";
            }

        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (lstboxUsers.SelectedItem != null)
            {
                users.Remove(lstboxUsers.SelectedItem as User);
            }
        }
    }
}
