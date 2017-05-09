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

namespace DependencyPropoertyDemo
{
    /// <summary>
    /// Interaction logic for CustomUserControl.xaml
    /// </summary>
    public partial class CustomUserControl : UserControl
    {
        public CustomUserControl()
        {
            InitializeComponent();
        }


        public string SetText
        {
            get
            {
                return GetValue(SetTextProperty) as string;
            }
            set
            {
                SetValue(SetTextProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for SetText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetTextProperty =
            DependencyProperty.Register("SetText", typeof(string), typeof(CustomUserControl), 
                new PropertyMetadata("", new PropertyChangedCallback(OnSetTextChanged)));

        private static void OnSetTextChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            CustomUserControl custControl = depObj as CustomUserControl;
            custControl.OnSetTextChanged(args);
        }

        private void OnSetTextChanged(DependencyPropertyChangedEventArgs args)
        {
            tbTest.Text = args.NewValue.ToString();
        }
    }
}
