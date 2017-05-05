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

namespace ZZScratchWPFApp
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        Employee emp = new Employee()
        {
            Name = "Some Name",
            ID = 1,
            Age = 28,
            Title = "SSE"

        };

        public UserControl1()
        {
            InitializeComponent();
            this.DataContext = emp;

        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n Employee Name :" + emp.Name);
            sb.Append("\n Employee ID :" + emp.ID);
            sb.Append("\n Employee Age :" + emp.Age);
            sb.Append("\n Employee Title :" + emp.Title);
            MessageBox.Show(sb.ToString());
        }
    }
}
