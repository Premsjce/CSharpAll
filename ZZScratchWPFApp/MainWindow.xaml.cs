using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

namespace ZZScratchWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button btn = new Button();
            btn.Height = 20;
            btn.Width = 100;
            btn.Content = "Dynamic";
            btn.Background = Brushes.Teal;
            StckPanel.Children.Add(btn);
            btn.Click += Btn_Click;
            btn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }


        static FrameworkPropertyMetadata metaData = new FrameworkPropertyMetadata
            ("Comes as Deafult",
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
            new PropertyChangedCallback(IsSpinning_PropertyChanged),
            new CoerceValueCallback(IsSpinning_CoerceValue),
            false, UpdateSourceTrigger.PropertyChanged);

        private static void IsSpinning_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static object IsSpinning_CoerceValue(DependencyObject d, object baseValue)
        {
            throw new NotImplementedException();
        }

        public static readonly DependencyProperty IsSpinningProperty =
            DependencyProperty.Register(
                "IsSpinning", 
                typeof(bool),
                typeof(MainWindow));

        public bool IsSpinnig
        {
            get
            {
                return (bool)GetValue(IsSpinningProperty);
            }
            set
            {
                SetValue(IsSpinningProperty, value);
            }
        }



        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked dynamically from Code bahind");
        }


        public string CustomDependency
        {
            get
            {
                return (string)GetValue(CustomDependencyProperty);
            }
            set
            {
                SetValue(CustomDependencyProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for CustomDependency.  
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomDependencyProperty =
            DependencyProperty.Register("CustomDependency", typeof(string), typeof(MainWindow), new PropertyMetadata(0));



    }
}
